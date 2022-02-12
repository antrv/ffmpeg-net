using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.IO;
using Antrv.FFMpeg.Model.Processing;
using SkiaSharp;

namespace CameraFrame;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow: Window
{
    private CancellationTokenSource _source;

    public MainWindow()
    {
        InitializeComponent();

        _source = new CancellationTokenSource();
        ReadAsync(_source.Token);

        //using InputSource source = Utils.GetCameraSource();
        //using SKBitmap? bitmap = Utils.FrameFromSource(source);
        //if (bitmap != null)
        //{
        //    WriteableBitmap writeableBitmap = Utils.CreateImage(bitmap.Width, bitmap.Height);
        //    Utils.UpdateImage(writeableBitmap, bitmap);

        //    image.Source = writeableBitmap;
        //}
    }

    protected override void OnClosed(EventArgs e)
    {
        _source.Cancel();
        base.OnClosed(e);
    }

    private async void ReadAsync(CancellationToken token)
    {
        //using InputSource source = InputSource.OpenFile(
        //    @"D:\Video\Anime\Моя жена — президент студенческого совета! [2015-2016]\Okusama ga Seitokaichou! Plus [BDRip 1080p HEVC]\Okusama_ga_Seitokaichou_Plus_[01]_[BDRip_1080p_HEVC].mkv");
        using InputSource source = Utils.GetCameraSource();

        InputStream videoStream = source.Streams.First(x => x.MediaType == AVMediaType.Video);
        VideoParameters parameters = (VideoParameters)videoStream.Parameters;
        WriteableBitmap writeableBitmap = Utils.CreateImage(parameters.Width, parameters.Height);
        image.Source = writeableBitmap;

        FrameObserver observer = new FrameObserver(frame =>
        {
            SKBitmap bitmap = frame.ToBitmap();
            Utils.UpdateImage(writeableBitmap, bitmap); // TODO: write to WriteableBitmap directly
        });

        using Decoder decoder = new Decoder(videoStream);
        ((IRawVideoStream)decoder.RawStream).Subscribe(observer);

        while (!token.IsCancellationRequested && !observer.Stop)
        {
            ((IInputSource)source).Push();
            await Task.Delay(5);
        }
    }

    private sealed class FrameObserver: IObserver<VideoFrame>
    {
        private readonly Action<VideoFrame> _action;
        private bool _stop;
        public FrameObserver(Action<VideoFrame> action) => _action = action;
        public bool Stop => _stop;
        public void OnCompleted() => _stop = true;
        public void OnError(Exception error) => _stop = true;
        public void OnNext(VideoFrame value) => _action(value);
    }
}
