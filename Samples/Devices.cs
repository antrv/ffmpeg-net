using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model;
using Antrv.FFMpeg.Model.Devices;
using Antrv.FFMpeg.Model.IO;
using Antrv.FFMpeg.Model.Processing;

namespace Samples;

internal static class Devices
{
    internal static void ShowCameraAndMicrophoneInfo(bool showDeviceDialog = false)
    {
        InputDevice device = Global.InputDevices["dshow"]; // DirectShow device, Windows only

        string? videoSource = null;
        string? audioSource = null;

        foreach (DevicePointInfo p in device.Sources)
        {
            if (videoSource is null && p.MediaTypes.Contains(AVMediaType.Video))
                videoSource = "video=" + p.Name;

            if (audioSource is null && p.MediaTypes.Contains(AVMediaType.Audio))
                audioSource = "audio=" + p.Name;
        }

        // The source string is device specific. See https://ffmpeg.org/ffmpeg-devices.html
        string source =
            videoSource is not null && audioSource is not null
                ? videoSource + ":" + audioSource
                : videoSource ?? audioSource ?? throw new InvalidOperationException("The device has no sources");

        ImmutableDictionary<string, string>.Builder builder = ImmutableDictionary.CreateBuilder<string, string>();
        // TODO: get camera resolutions from DirectShow
        builder.Add("video_size", "1920x1080");
        if (showDeviceDialog)
            builder.Add("show_video_device_dialog", "true");

        using InputSource deviceSource = InputSource.OpenDevice(device, source, builder.ToImmutable());
        Console.WriteLine(source);
        Information.PrintInputSourceInfo(deviceSource);
    }

    internal static void TakeFrameFromCamera()
    {
        InputDevice device = Global.InputDevices["dshow"]; // DirectShow device, Windows only

        string videoSource = device.Sources.First(p => p.MediaTypes.Contains(AVMediaType.Video)).Name;

        ImmutableDictionary<string, string>.Builder builder = ImmutableDictionary.CreateBuilder<string, string>();
        // TODO: get camera resolutions from DirectShow
        builder.Add("video_size", "1920x1080");

        using InputSource deviceSource = InputSource.OpenDevice(device, $"video={videoSource}", builder.ToImmutable());
        InputStream videoStream = deviceSource.Streams[0];

        using Decoder decoder = new(videoStream);
        FrameObserver frameObserver = new();
        ((IRawVideoStream)decoder.RawStream).Subscribe(frameObserver);
        
        while (!frameObserver.Stop)
            ((IInputSource)deviceSource).Push();
    }

    private sealed class FrameObserver: IObserver<VideoFrame>
    {
        private bool _stop;

        public bool Stop => _stop;

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
            Console.WriteLine("Received frame from camera");
        }
    }
}
