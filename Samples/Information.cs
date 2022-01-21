using Antrv.FFMpeg.Model;
using Antrv.FFMpeg.Model.Codecs;

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

            foreach (Decoder decoder in codec.Decoders)
            {
                Console.WriteLine($" - decoder: {decoder.Name} - {decoder.LongName}");
                switch (decoder)
                {
                    case VideoDecoder videoDecoder:
                        Console.WriteLine("   pixel formats: " + string.Join(", ", videoDecoder.PixelFormats));
                        Console.WriteLine("   framerates: " + string.Join(", ", videoDecoder.FrameRates));
                        break;
                    case AudioDecoder audioDecoder:
                        Console.WriteLine("   channel layouts: " + string.Join(", ", audioDecoder.ChannelLayouts));
                        Console.WriteLine("   sample formats: " + string.Join(", ", audioDecoder.SampleFormats));
                        Console.WriteLine("   samplerates: " + string.Join(", ", audioDecoder.SampleRates));
                        break;
                }
            }

            foreach (Encoder encoder in codec.Encoders)
            {
                Console.WriteLine($" - encoder: {encoder.Name} - {encoder.LongName}");
                switch (encoder)
                {
                    case VideoEncoder videoEncoder:
                        Console.WriteLine("   pixel formats: " + string.Join(", ", videoEncoder.PixelFormats));
                        Console.WriteLine("   framerates: " + string.Join(", ", videoEncoder.FrameRates));
                        break;
                    case AudioEncoder audioEncoder:
                        Console.WriteLine("   channel layouts: " + string.Join(", ", audioEncoder.ChannelLayouts));
                        Console.WriteLine("   sample formats: " + string.Join(", ", audioEncoder.SampleFormats));
                        Console.WriteLine("   samplerates: " + string.Join(", ", audioEncoder.SampleRates));
                        break;
                }
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
        Global.OutputFormats.ForEach(Console.WriteLine);
        Console.WriteLine();
    }
}
