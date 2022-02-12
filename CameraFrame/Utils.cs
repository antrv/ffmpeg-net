using System.Collections.Immutable;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.IO;
using Antrv.FFMpeg.Model.Processing;
using Antrv.FFMpeg.Model;
using Antrv.FFMpeg.Model.Devices;
using SkiaSharp;

namespace CameraFrame;

internal static class Utils
{
    public static WriteableBitmap CreateImage(int width, int height) => new(width, height, 96, 96,
        PixelFormats.Bgra32, BitmapPalettes.Halftone256Transparent);

    public static void UpdateImage(WriteableBitmap writeableBitmap, SKBitmap bitmap)
    {
        int width = (int)writeableBitmap.Width;
        int height = (int)writeableBitmap.Height;

        writeableBitmap.Lock();

        using SKPixmap pixmap = new(bitmap.Info, writeableBitmap.BackBuffer, width * 4);
        using (SKSurface surface = SKSurface.Create(pixmap))
        {
            SKCanvas canvas = surface.Canvas;
            canvas.DrawBitmap(bitmap, 0, 0);
        }

        writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
        writeableBitmap.Unlock();
    }

    internal static InputSource GetCameraSource()
    {
        InputDevice device = Global.InputDevices["dshow"]; // DirectShow device, Windows only

        string videoSource = device.Sources.First(p => p.MediaTypes.Contains(AVMediaType.Video)).Name;

        ImmutableDictionary<string, string>.Builder builder = ImmutableDictionary.CreateBuilder<string, string>();
        // TODO: get camera resolutions from DirectShow
        builder.Add("video_size", "1920x1080");

        return InputSource.OpenDevice(device, $"video={videoSource}", builder.ToImmutable());
    }

    internal static SKBitmap? FrameFromSource(InputSource source)
    {
        InputStream videoStream = source.Streams.First(s => s.MediaType == AVMediaType.Video);

        using Decoder decoder = new(videoStream);
        FrameObserver frameObserver = new();
        ((IRawVideoStream)decoder.RawStream).Subscribe(frameObserver);

        while (!frameObserver.Stop)
            ((IInputSource)source).Push();

        return frameObserver.Bitmap;
    }

    private sealed class FrameObserver: IObserver<VideoFrame>
    {
        private bool _stop;
        private SKBitmap? _bitmap;

        public bool Stop => _stop;
        public SKBitmap? Bitmap => _bitmap;

        public void OnCompleted()
        {
            _stop = true;
        }

        public void OnError(Exception error)
        {
            _stop = true;
        }

        public void OnNext(VideoFrame value)
        {
            _stop = true;
            _bitmap = value.ToBitmap();
        }
    }
}
