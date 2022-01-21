using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model;
using Antrv.FFMpeg.Model.Codecs;
using Antrv.FFMpeg.Model.Devices;
using Antrv.FFMpeg.Model.Formats;

namespace Samples;

internal static class Information
{
    internal static void PrintChannelLayouts()
    {
        Console.WriteLine("Audio channel standard layouts:");
        Global.ChannelLayouts.ForEach(x => Console.WriteLine(x.Name));
        Console.WriteLine();
    }

    internal static void PrintCodecs()
    {
        Console.WriteLine("Codecs:");
        foreach (Codec codec in Global.Codecs)
        {
            Console.WriteLine($"{codec.CodecId} - {codec.Name} - {codec.LongName}");

            if (codec.Properties != AVCodecProperties.None)
                Console.WriteLine($" - properties: {codec.Properties}");

            foreach (Profile profile in codec.Profiles)
                Console.WriteLine($" - profile {profile.Id} - {profile.Name}");

            foreach (Decoder decoder in codec.Decoders)
            {
                Console.WriteLine($" - decoder: {decoder.Name} - {decoder.LongName}");
                switch (decoder)
                {
                    case VideoDecoder videoDecoder:
                        if (videoDecoder.PixelFormats.Count > 0)
                            Console.WriteLine("     pixel formats: " + string.Join(", ", videoDecoder.PixelFormats));

                        if (videoDecoder.FrameRates.Count > 0)
                            Console.WriteLine("     framerates: " + string.Join(", ", videoDecoder.FrameRates));
                        break;

                    case AudioDecoder audioDecoder:
                        if (audioDecoder.ChannelLayouts.Count > 0)
                            Console.WriteLine("     channel layouts: " + string.Join(", ", audioDecoder.ChannelLayouts));

                        if (audioDecoder.SampleFormats.Count > 0)
                            Console.WriteLine("     sample formats: " + string.Join(", ", audioDecoder.SampleFormats));
                        
                        if (audioDecoder.SampleRates.Count > 0)
                            Console.WriteLine("     samplerates: " + string.Join(", ", audioDecoder.SampleRates));
                        break;
                }

                foreach (Profile profile in decoder.Profiles)
                    Console.WriteLine($"     profile {profile.Id} - {profile.Name}");
            }

            foreach (Encoder encoder in codec.Encoders)
            {
                Console.WriteLine($" - encoder: {encoder.Name} - {encoder.LongName}");
                switch (encoder)
                {
                    case VideoEncoder videoEncoder:
                        if (videoEncoder.PixelFormats.Count > 0)
                            Console.WriteLine("     pixel formats: " + string.Join(", ", videoEncoder.PixelFormats));

                        if (videoEncoder.FrameRates.Count > 0)
                            Console.WriteLine("     framerates: " + string.Join(", ", videoEncoder.FrameRates));

                        break;
                    case AudioEncoder audioEncoder:
                        if (audioEncoder.ChannelLayouts.Count > 0)
                            Console.WriteLine("     channel layouts: " + string.Join(", ", audioEncoder.ChannelLayouts));

                        if (audioEncoder.SampleFormats.Count > 0)
                            Console.WriteLine("     sample formats: " + string.Join(", ", audioEncoder.SampleFormats));

                        if (audioEncoder.SampleRates.Count > 0)
                            Console.WriteLine("     samplerates: " + string.Join(", ", audioEncoder.SampleRates));
                        break;
                }

                foreach (Profile profile in encoder.Profiles)
                    Console.WriteLine($"     profile {profile.Id} - {profile.Name}");
            }
        }

        Console.WriteLine();
    }

    internal static void PrintInputFormats()
    {
        Console.WriteLine("Input formats:");
        Global.InputFormats.ForEach(Console.WriteLine);
        Console.WriteLine();
    }

    internal static void PrintOutputFormats()
    {
        Console.WriteLine("Output formats:");
        Global.OutputFormats.ForEach(PrintOutputFormat);
        Console.WriteLine();
    }

    internal static void PrintInputDevices()
    {
        Console.WriteLine("Input audio device types:");
        Global.InputDeviceTypes.AudioDeviceTypes.ForEach(deviceType =>
        {
            Console.WriteLine(deviceType);
            PrintDeviceInfo(deviceType.Devices);
        });

        Console.WriteLine();

        Console.WriteLine("Input video device types:");
        Global.InputDeviceTypes.VideoDeviceTypes.ForEach(deviceType =>
        {
            Console.WriteLine(deviceType);
            PrintDeviceInfo(deviceType.Devices);
        });

        Console.WriteLine();
    }

    internal static void PrintOutputDevices()
    {
        Console.WriteLine("Output audio device types:");
        Global.OutputDeviceTypes.AudioDeviceTypes.ForEach(deviceType =>
        {
            Console.WriteLine(deviceType);
            PrintDeviceInfo(deviceType.Devices);
        });

        Console.WriteLine();

        Console.WriteLine("Output video device types:");
        Global.OutputDeviceTypes.VideoDeviceTypes.ForEach(deviceType =>
        {
            PrintOutputFormat(deviceType);
            PrintDeviceInfo(deviceType.Devices);
        });

        Console.WriteLine();
    }

    private static void PrintOutputFormat(OutputFormat format)
    {
        Console.WriteLine(format);

        if (format.DefaultVideoCodec != null)
            Console.WriteLine($" - default video codec: {format.DefaultVideoCodec.LongName}");

        if (format.DefaultAudioCodec != null)
            Console.WriteLine($" - default audio codec: {format.DefaultAudioCodec.LongName}");

        if (format.DefaultSubtitleCodec != null)
            Console.WriteLine($" - default subtitle codec: {format.DefaultSubtitleCodec.LongName}");

        foreach (CodecSupport codec in format.SupportedCodecs)
            Console.WriteLine($" - supported codec: {codec.Codec.LongName} - {codec.StandardCompliance}");
    }

    private static void PrintDeviceInfo(ImmutableList<DeviceInfo> list)
    {
        foreach (DeviceInfo deviceInfo in list)
            Console.WriteLine($" - device {deviceInfo.Name} - {deviceInfo.Description} - {string.Join(", ", deviceInfo.MediaTypes)}");
    }
}
