using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model;
using Antrv.FFMpeg.Model.Devices;
using Antrv.FFMpeg.Model.IO;

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
}
