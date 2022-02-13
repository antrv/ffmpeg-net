using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Antrv.FFMpeg;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.IO;
using Antrv.FFMpeg.Model.Processing;

namespace CameraFrame;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow: Window
{
    private readonly CancellationTokenSource _source;
    private readonly Task _task;

    public MainWindow()
    {
        InitializeComponent();

        _source = new CancellationTokenSource();
        _task = Task.Run(() =>
        {
            try
            {
                ProcessVideo(_source.Token);
            }
            catch (Exception exception)
            {
                Dispatcher.Invoke(() => MessageBox.Show(exception.ToString()));
            }
        });
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        _source.Cancel();
        base.OnClosing(e);
    }

    private void ProcessVideo(CancellationToken token)
    {
        const string videoPath = @"video.mkv";
        //using InputSource source = InputSource.OpenFile(videoPath);
        using InputSource source = Utils.GetCameraSource();

        InputStream videoStream = source.Streams.First(x => x.MediaType == AVMediaType.Video);
        VideoParameters parameters = (VideoParameters)videoStream.Parameters;

        WriteableBitmap writeableBitmap = null;

        Dispatcher.Invoke(() =>
        {
            writeableBitmap = Utils.CreateImage(parameters.Width, parameters.Height);
            image.Source = writeableBitmap;
        });

        using VideoFrameConverter converter = new(parameters, parameters.Width, parameters.Height,
            AVPixelFormat.AV_PIX_FMT_BGRA, SwScaleFlags.SWS_BICUBIC);

        FrameObserver observer = new FrameObserver(frame =>
        {
            Dispatcher.Invoke(() => converter.Convert(frame, writeableBitmap));
        });

        using StreamDecoder decoder = new StreamDecoder(videoStream);
        decoder.Subscribe(observer);

        while (!token.IsCancellationRequested && !observer.Stop)
        {
            ((IInputSource)source).Push();
        }
    }

    private sealed class FrameObserver: IObserver<Frame>
    {
        private readonly Action<Frame> _action;
        private bool _stop;
        public FrameObserver(Action<Frame> action) => _action = action;
        public bool Stop => _stop;
        public void OnCompleted() => _stop = true;
        public void OnError(Exception error) => _stop = true;
        public void OnNext(Frame value) => _action(value);
    }
}
