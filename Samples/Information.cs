using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model;
using Antrv.FFMpeg.Model.Codecs;
using Antrv.FFMpeg.Model.Devices;
using Antrv.FFMpeg.Model.Formats;
using Antrv.FFMpeg.Model.IO;

namespace Samples;

internal static class Information
{
    internal static void PrintChannelLayouts()
    {
        Console.WriteLine("Audio channel standard layouts:");
        Global.ChannelLayouts.ForEach(x => Console.WriteLine($"{x.Name}: {x.ChannelCount} channels, {x.Layout}"));
        Console.WriteLine();
    }

    internal static void PrintCodecs()
    {
        Console.WriteLine("Codecs:");
        foreach (Codec codec in Global.Codecs)
        {
            Console.WriteLine($"{codec.Id} - {codec.ShortName} - {codec.Name}");

            if (codec.Properties != AVCodecProperties.None)
                Console.WriteLine($" - properties: {codec.Properties}");

            foreach (Profile profile in codec.Profiles)
                Console.WriteLine($" - profile {profile.Id} - {profile.Name}");

            foreach (Decoder decoder in codec.Decoders)
            {
                Console.WriteLine($" - decoder: {decoder.ShortName} - {decoder.Name}");
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
                Console.WriteLine($" - encoder: {encoder.ShortName} - {encoder.Name}");
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
        Console.WriteLine("Input devices:");
        Global.InputDevices.ForEach(deviceType =>
        {
            Console.WriteLine(deviceType);
            PrintDeviceInfo(deviceType.Sources);
        });

        Console.WriteLine();
    }

    internal static void PrintOutputDevices()
    {
        Console.WriteLine("Output devices:");
        Global.OutputDevices.ForEach(deviceType =>
        {
            PrintOutputFormat(deviceType);
            PrintDeviceInfo(deviceType.Sinks);
        });

        Console.WriteLine();
    }

    internal static void PrintMediaFileInfo(string filePath)
    {
        using InputSource source = InputSource.OpenFile(filePath);

        Console.WriteLine(filePath);
        Console.WriteLine("Input format: " + source.Format.FullName);
        Console.WriteLine("Streams: ");
        foreach (InputStream stream in source.Streams)
        {
            Console.WriteLine($" #{stream.Index} - {stream.MediaType} - {stream.CodecId} - {stream.TimeBase}");

            if (stream.Metadata.Count > 0)
            {
                Console.WriteLine("      Metadata:");
                foreach (KeyValuePair<string, string> pair in stream.Metadata)
                {
                    Console.WriteLine($"       - {pair.Key}: {pair.Value}");
                }
            }

            switch (stream)
            {
                case InputVideoStream videoStream:
                    Console.WriteLine($"    - dimensions: {videoStream.Parameters.Width}x{videoStream.Parameters.Height}");
                    Console.WriteLine($"    - pixel format: {videoStream.Parameters.PixelFormat}");
                    Console.WriteLine($"    - bitrate: {videoStream.Parameters.BitRate}");
                    Console.WriteLine($"    - profile: {videoStream.Parameters.Profile}");
                    Console.WriteLine($"    - level: {videoStream.Parameters.Level}");
                    Console.WriteLine($"    - field order: {videoStream.Parameters.FieldOrder}");
                    Console.WriteLine($"    - codec tag: {videoStream.Parameters.CodecTag}");
                    Console.WriteLine($"    - delay: {videoStream.Parameters.VideoDelay}");
                    Console.WriteLine($"    - chroma location: {videoStream.Parameters.ChromaLocation}");
                    Console.WriteLine($"    - color primaries: {videoStream.Parameters.ColorPrimaries}");
                    Console.WriteLine($"    - color range: {videoStream.Parameters.ColorRange}");
                    Console.WriteLine($"    - color space: {videoStream.Parameters.ColorSpace}");
                    Console.WriteLine($"    - color transfer characteristic: {videoStream.Parameters.ColorTransferCharacteristic}");
                    break;
            }
        }
    }

    private static void PrintOutputFormat(OutputFormat format)
    {
        Console.WriteLine(format);

        if (format.DefaultVideoCodec != null)
            Console.WriteLine($" - default video codec: {format.DefaultVideoCodec.Name}");

        if (format.DefaultAudioCodec != null)
            Console.WriteLine($" - default audio codec: {format.DefaultAudioCodec.Name}");

        if (format.DefaultSubtitleCodec != null)
            Console.WriteLine($" - default subtitle codec: {format.DefaultSubtitleCodec.Name}");

        foreach (CodecSupport codec in format.SupportedCodecs)
            Console.WriteLine($" - supported codec: {codec.Codec.Name} - {codec.StandardCompliance}");
    }

    private static void PrintDeviceInfo(ImmutableList<DevicePointInfo> list)
    {
        foreach (DevicePointInfo deviceInfo in list)
            Console.WriteLine($" - {deviceInfo.Name} - {deviceInfo.Description} - {string.Join(", ", deviceInfo.MediaTypes)}");
    }
}
