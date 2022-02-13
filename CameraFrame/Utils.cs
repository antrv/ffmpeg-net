using System.Collections.Immutable;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.IO;
using Antrv.FFMpeg.Model;
using Antrv.FFMpeg.Model.Devices;

namespace CameraFrame;

internal static class Utils
{
    public static WriteableBitmap CreateImage(int width, int height) => new(width, height, 96, 96,
        PixelFormats.Bgra32, BitmapPalettes.Halftone256Transparent);

    internal static InputSource GetCameraSource()
    {
        InputDevice device = Global.InputDevices["dshow"]; // DirectShow device, Windows only

        string videoSource = device.Sources.First(p => p.MediaTypes.Contains(AVMediaType.Video)).Name;

        ImmutableDictionary<string, string>.Builder builder = ImmutableDictionary.CreateBuilder<string, string>();
        // TODO: get camera resolutions from DirectShow
        builder.Add("video_size", "1920x1080");
        //builder.Add("framerate", "30");
        //builder.Add("show_video_device_dialog", "true");

        return InputSource.OpenDevice(device, $"video={videoSource}", builder.ToImmutable());
    }
}
