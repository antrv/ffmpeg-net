namespace Antrv.FFMpeg.Interop;

public static class AVPixelFormatEx
{
    static AVPixelFormatEx()
    {
        if (BitConverter.IsLittleEndian)
        {
            AV_PIX_FMT_RGB32 = AVPixelFormat.AV_PIX_FMT_BGRA;
            AV_PIX_FMT_RGB32_1 = AVPixelFormat.AV_PIX_FMT_ABGR;
            AV_PIX_FMT_BGR32 = AVPixelFormat.AV_PIX_FMT_RGBA;
            AV_PIX_FMT_BGR32_1 = AVPixelFormat.AV_PIX_FMT_ARGB;
            AV_PIX_FMT_0RGB32 = AVPixelFormat.AV_PIX_FMT_BGR0;
            AV_PIX_FMT_0BGR32 = AVPixelFormat.AV_PIX_FMT_RGB0;

            AV_PIX_FMT_GRAY9 = AVPixelFormat.AV_PIX_FMT_GRAY9LE;
            AV_PIX_FMT_GRAY10 = AVPixelFormat.AV_PIX_FMT_GRAY10LE;
            AV_PIX_FMT_GRAY12 = AVPixelFormat.AV_PIX_FMT_GRAY12LE;
            AV_PIX_FMT_GRAY14 = AVPixelFormat.AV_PIX_FMT_GRAY14LE;
            AV_PIX_FMT_GRAY16 = AVPixelFormat.AV_PIX_FMT_GRAY16LE;
            AV_PIX_FMT_YA16 = AVPixelFormat.AV_PIX_FMT_YA16LE;
            AV_PIX_FMT_RGB48 = AVPixelFormat.AV_PIX_FMT_RGB48LE;
            AV_PIX_FMT_RGB565 = AVPixelFormat.AV_PIX_FMT_RGB565LE;
            AV_PIX_FMT_RGB555 = AVPixelFormat.AV_PIX_FMT_RGB555LE;
            AV_PIX_FMT_RGB444 = AVPixelFormat.AV_PIX_FMT_RGB444LE;
            AV_PIX_FMT_RGBA64 = AVPixelFormat.AV_PIX_FMT_RGBA64LE;
            AV_PIX_FMT_BGR48 = AVPixelFormat.AV_PIX_FMT_BGR48LE;
            AV_PIX_FMT_BGR565 = AVPixelFormat.AV_PIX_FMT_BGR565LE;
            AV_PIX_FMT_BGR555 = AVPixelFormat.AV_PIX_FMT_BGR555LE;
            AV_PIX_FMT_BGR444 = AVPixelFormat.AV_PIX_FMT_BGR444LE;
            AV_PIX_FMT_BGRA64 = AVPixelFormat.AV_PIX_FMT_BGRA64LE;

            AV_PIX_FMT_YUV420P9 = AVPixelFormat.AV_PIX_FMT_YUV420P9LE;
            AV_PIX_FMT_YUV422P9 = AVPixelFormat.AV_PIX_FMT_YUV422P9LE;
            AV_PIX_FMT_YUV444P9 = AVPixelFormat.AV_PIX_FMT_YUV444P9LE;
            AV_PIX_FMT_YUV420P10 = AVPixelFormat.AV_PIX_FMT_YUV420P10LE;
            AV_PIX_FMT_YUV422P10 = AVPixelFormat.AV_PIX_FMT_YUV422P10LE;
            AV_PIX_FMT_YUV440P10 = AVPixelFormat.AV_PIX_FMT_YUV440P10LE;
            AV_PIX_FMT_YUV444P10 = AVPixelFormat.AV_PIX_FMT_YUV444P10LE;
            AV_PIX_FMT_YUV420P12 = AVPixelFormat.AV_PIX_FMT_YUV420P12LE;
            AV_PIX_FMT_YUV422P12 = AVPixelFormat.AV_PIX_FMT_YUV422P12LE;
            AV_PIX_FMT_YUV440P12 = AVPixelFormat.AV_PIX_FMT_YUV440P12LE;
            AV_PIX_FMT_YUV444P12 = AVPixelFormat.AV_PIX_FMT_YUV444P12LE;
            AV_PIX_FMT_YUV420P14 = AVPixelFormat.AV_PIX_FMT_YUV420P14LE;
            AV_PIX_FMT_YUV422P14 = AVPixelFormat.AV_PIX_FMT_YUV422P14LE;
            AV_PIX_FMT_YUV444P14 = AVPixelFormat.AV_PIX_FMT_YUV444P14LE;
            AV_PIX_FMT_YUV420P16 = AVPixelFormat.AV_PIX_FMT_YUV420P16LE;
            AV_PIX_FMT_YUV422P16 = AVPixelFormat.AV_PIX_FMT_YUV422P16LE;
            AV_PIX_FMT_YUV444P16 = AVPixelFormat.AV_PIX_FMT_YUV444P16LE;

            AV_PIX_FMT_GBRP9 = AVPixelFormat.AV_PIX_FMT_GBRP9LE;
            AV_PIX_FMT_GBRP10 = AVPixelFormat.AV_PIX_FMT_GBRP10LE;
            AV_PIX_FMT_GBRP12 = AVPixelFormat.AV_PIX_FMT_GBRP12LE;
            AV_PIX_FMT_GBRP14 = AVPixelFormat.AV_PIX_FMT_GBRP14LE;
            AV_PIX_FMT_GBRP16 = AVPixelFormat.AV_PIX_FMT_GBRP16LE;
            AV_PIX_FMT_GBRAP10 = AVPixelFormat.AV_PIX_FMT_GBRAP10LE;
            AV_PIX_FMT_GBRAP12 = AVPixelFormat.AV_PIX_FMT_GBRAP12LE;
            AV_PIX_FMT_GBRAP16 = AVPixelFormat.AV_PIX_FMT_GBRAP16LE;

            AV_PIX_FMT_BAYER_BGGR16 = AVPixelFormat.AV_PIX_FMT_BAYER_BGGR16LE;
            AV_PIX_FMT_BAYER_RGGB16 = AVPixelFormat.AV_PIX_FMT_BAYER_RGGB16LE;
            AV_PIX_FMT_BAYER_GBRG16 = AVPixelFormat.AV_PIX_FMT_BAYER_GBRG16LE;
            AV_PIX_FMT_BAYER_GRBG16 = AVPixelFormat.AV_PIX_FMT_BAYER_GRBG16LE;

            AV_PIX_FMT_GBRPF32 = AVPixelFormat.AV_PIX_FMT_GBRPF32LE;
            AV_PIX_FMT_GBRAPF32 = AVPixelFormat.AV_PIX_FMT_GBRAPF32LE;

            AV_PIX_FMT_GRAYF32 = AVPixelFormat.AV_PIX_FMT_GRAYF32LE;

            AV_PIX_FMT_YUVA420P9 = AVPixelFormat.AV_PIX_FMT_YUVA420P9LE;
            AV_PIX_FMT_YUVA422P9 = AVPixelFormat.AV_PIX_FMT_YUVA422P9LE;
            AV_PIX_FMT_YUVA444P9 = AVPixelFormat.AV_PIX_FMT_YUVA444P9LE;
            AV_PIX_FMT_YUVA420P10 = AVPixelFormat.AV_PIX_FMT_YUVA420P10LE;
            AV_PIX_FMT_YUVA422P10 = AVPixelFormat.AV_PIX_FMT_YUVA422P10LE;
            AV_PIX_FMT_YUVA444P10 = AVPixelFormat.AV_PIX_FMT_YUVA444P10LE;
            AV_PIX_FMT_YUVA422P12 = AVPixelFormat.AV_PIX_FMT_YUVA422P12LE;
            AV_PIX_FMT_YUVA444P12 = AVPixelFormat.AV_PIX_FMT_YUVA444P12LE;
            AV_PIX_FMT_YUVA420P16 = AVPixelFormat.AV_PIX_FMT_YUVA420P16LE;
            AV_PIX_FMT_YUVA422P16 = AVPixelFormat.AV_PIX_FMT_YUVA422P16LE;
            AV_PIX_FMT_YUVA444P16 = AVPixelFormat.AV_PIX_FMT_YUVA444P16LE;

            AV_PIX_FMT_XYZ12 = AVPixelFormat.AV_PIX_FMT_XYZ12LE;
            AV_PIX_FMT_NV20 = AVPixelFormat.AV_PIX_FMT_NV20LE;
            AV_PIX_FMT_AYUV64 = AVPixelFormat.AV_PIX_FMT_AYUV64LE;
            AV_PIX_FMT_P010 = AVPixelFormat.AV_PIX_FMT_P010LE;
            AV_PIX_FMT_P016 = AVPixelFormat.AV_PIX_FMT_P016LE;

            AV_PIX_FMT_Y210 = AVPixelFormat.AV_PIX_FMT_Y210LE;
            AV_PIX_FMT_X2RGB10 = AVPixelFormat.AV_PIX_FMT_X2RGB10LE;
            AV_PIX_FMT_X2BGR10 = AVPixelFormat.AV_PIX_FMT_X2BGR10LE;

            AV_PIX_FMT_P210 = AVPixelFormat.AV_PIX_FMT_P210LE;
            AV_PIX_FMT_P410 = AVPixelFormat.AV_PIX_FMT_P410LE;
            AV_PIX_FMT_P216 = AVPixelFormat.AV_PIX_FMT_P216LE;
            AV_PIX_FMT_P416 = AVPixelFormat.AV_PIX_FMT_P416LE;
        }
        else
        {
            AV_PIX_FMT_RGB32 = AVPixelFormat.AV_PIX_FMT_ARGB;
            AV_PIX_FMT_RGB32_1 = AVPixelFormat.AV_PIX_FMT_RGBA;
            AV_PIX_FMT_BGR32 = AVPixelFormat.AV_PIX_FMT_ABGR;
            AV_PIX_FMT_BGR32_1 = AVPixelFormat.AV_PIX_FMT_BGRA;
            AV_PIX_FMT_0RGB32 = AVPixelFormat.AV_PIX_FMT_0RGB;
            AV_PIX_FMT_0BGR32 = AVPixelFormat.AV_PIX_FMT_0BGR;

            AV_PIX_FMT_GRAY9 = AVPixelFormat.AV_PIX_FMT_GRAY9BE;
            AV_PIX_FMT_GRAY10 = AVPixelFormat.AV_PIX_FMT_GRAY10BE;
            AV_PIX_FMT_GRAY12 = AVPixelFormat.AV_PIX_FMT_GRAY12BE;
            AV_PIX_FMT_GRAY14 = AVPixelFormat.AV_PIX_FMT_GRAY14BE;
            AV_PIX_FMT_GRAY16 = AVPixelFormat.AV_PIX_FMT_GRAY16BE;
            AV_PIX_FMT_YA16 = AVPixelFormat.AV_PIX_FMT_YA16BE;
            AV_PIX_FMT_RGB48 = AVPixelFormat.AV_PIX_FMT_RGB48BE;
            AV_PIX_FMT_RGB565 = AVPixelFormat.AV_PIX_FMT_RGB565BE;
            AV_PIX_FMT_RGB555 = AVPixelFormat.AV_PIX_FMT_RGB555BE;
            AV_PIX_FMT_RGB444 = AVPixelFormat.AV_PIX_FMT_RGB444BE;
            AV_PIX_FMT_RGBA64 = AVPixelFormat.AV_PIX_FMT_RGBA64BE;
            AV_PIX_FMT_BGR48 = AVPixelFormat.AV_PIX_FMT_BGR48BE;
            AV_PIX_FMT_BGR565 = AVPixelFormat.AV_PIX_FMT_BGR565BE;
            AV_PIX_FMT_BGR555 = AVPixelFormat.AV_PIX_FMT_BGR555BE;
            AV_PIX_FMT_BGR444 = AVPixelFormat.AV_PIX_FMT_BGR444BE;
            AV_PIX_FMT_BGRA64 = AVPixelFormat.AV_PIX_FMT_BGRA64BE;

            AV_PIX_FMT_YUV420P9 = AVPixelFormat.AV_PIX_FMT_YUV420P9BE;
            AV_PIX_FMT_YUV422P9 = AVPixelFormat.AV_PIX_FMT_YUV422P9BE;
            AV_PIX_FMT_YUV444P9 = AVPixelFormat.AV_PIX_FMT_YUV444P9BE;
            AV_PIX_FMT_YUV420P10 = AVPixelFormat.AV_PIX_FMT_YUV420P10BE;
            AV_PIX_FMT_YUV422P10 = AVPixelFormat.AV_PIX_FMT_YUV422P10BE;
            AV_PIX_FMT_YUV440P10 = AVPixelFormat.AV_PIX_FMT_YUV440P10BE;
            AV_PIX_FMT_YUV444P10 = AVPixelFormat.AV_PIX_FMT_YUV444P10BE;
            AV_PIX_FMT_YUV420P12 = AVPixelFormat.AV_PIX_FMT_YUV420P12BE;
            AV_PIX_FMT_YUV422P12 = AVPixelFormat.AV_PIX_FMT_YUV422P12BE;
            AV_PIX_FMT_YUV440P12 = AVPixelFormat.AV_PIX_FMT_YUV440P12BE;
            AV_PIX_FMT_YUV444P12 = AVPixelFormat.AV_PIX_FMT_YUV444P12BE;
            AV_PIX_FMT_YUV420P14 = AVPixelFormat.AV_PIX_FMT_YUV420P14BE;
            AV_PIX_FMT_YUV422P14 = AVPixelFormat.AV_PIX_FMT_YUV422P14BE;
            AV_PIX_FMT_YUV444P14 = AVPixelFormat.AV_PIX_FMT_YUV444P14BE;
            AV_PIX_FMT_YUV420P16 = AVPixelFormat.AV_PIX_FMT_YUV420P16BE;
            AV_PIX_FMT_YUV422P16 = AVPixelFormat.AV_PIX_FMT_YUV422P16BE;
            AV_PIX_FMT_YUV444P16 = AVPixelFormat.AV_PIX_FMT_YUV444P16BE;

            AV_PIX_FMT_GBRP9 = AVPixelFormat.AV_PIX_FMT_GBRP9BE;
            AV_PIX_FMT_GBRP10 = AVPixelFormat.AV_PIX_FMT_GBRP10BE;
            AV_PIX_FMT_GBRP12 = AVPixelFormat.AV_PIX_FMT_GBRP12BE;
            AV_PIX_FMT_GBRP14 = AVPixelFormat.AV_PIX_FMT_GBRP14BE;
            AV_PIX_FMT_GBRP16 = AVPixelFormat.AV_PIX_FMT_GBRP16BE;
            AV_PIX_FMT_GBRAP10 = AVPixelFormat.AV_PIX_FMT_GBRAP10BE;
            AV_PIX_FMT_GBRAP12 = AVPixelFormat.AV_PIX_FMT_GBRAP12BE;
            AV_PIX_FMT_GBRAP16 = AVPixelFormat.AV_PIX_FMT_GBRAP16BE;

            AV_PIX_FMT_BAYER_BGGR16 = AVPixelFormat.AV_PIX_FMT_BAYER_BGGR16BE;
            AV_PIX_FMT_BAYER_RGGB16 = AVPixelFormat.AV_PIX_FMT_BAYER_RGGB16BE;
            AV_PIX_FMT_BAYER_GBRG16 = AVPixelFormat.AV_PIX_FMT_BAYER_GBRG16BE;
            AV_PIX_FMT_BAYER_GRBG16 = AVPixelFormat.AV_PIX_FMT_BAYER_GRBG16BE;

            AV_PIX_FMT_GBRPF32 = AVPixelFormat.AV_PIX_FMT_GBRPF32BE;
            AV_PIX_FMT_GBRAPF32 = AVPixelFormat.AV_PIX_FMT_GBRAPF32BE;

            AV_PIX_FMT_GRAYF32 = AVPixelFormat.AV_PIX_FMT_GRAYF32BE;

            AV_PIX_FMT_YUVA420P9 = AVPixelFormat.AV_PIX_FMT_YUVA420P9BE;
            AV_PIX_FMT_YUVA422P9 = AVPixelFormat.AV_PIX_FMT_YUVA422P9BE;
            AV_PIX_FMT_YUVA444P9 = AVPixelFormat.AV_PIX_FMT_YUVA444P9BE;
            AV_PIX_FMT_YUVA420P10 = AVPixelFormat.AV_PIX_FMT_YUVA420P10BE;
            AV_PIX_FMT_YUVA422P10 = AVPixelFormat.AV_PIX_FMT_YUVA422P10BE;
            AV_PIX_FMT_YUVA444P10 = AVPixelFormat.AV_PIX_FMT_YUVA444P10BE;
            AV_PIX_FMT_YUVA422P12 = AVPixelFormat.AV_PIX_FMT_YUVA422P12BE;
            AV_PIX_FMT_YUVA444P12 = AVPixelFormat.AV_PIX_FMT_YUVA444P12BE;
            AV_PIX_FMT_YUVA420P16 = AVPixelFormat.AV_PIX_FMT_YUVA420P16BE;
            AV_PIX_FMT_YUVA422P16 = AVPixelFormat.AV_PIX_FMT_YUVA422P16BE;
            AV_PIX_FMT_YUVA444P16 = AVPixelFormat.AV_PIX_FMT_YUVA444P16BE;

            AV_PIX_FMT_XYZ12 = AVPixelFormat.AV_PIX_FMT_XYZ12BE;
            AV_PIX_FMT_NV20 = AVPixelFormat.AV_PIX_FMT_NV20BE;
            AV_PIX_FMT_AYUV64 = AVPixelFormat.AV_PIX_FMT_AYUV64BE;
            AV_PIX_FMT_P010 = AVPixelFormat.AV_PIX_FMT_P010BE;
            AV_PIX_FMT_P016 = AVPixelFormat.AV_PIX_FMT_P016BE;

            AV_PIX_FMT_Y210 = AVPixelFormat.AV_PIX_FMT_Y210BE;
            AV_PIX_FMT_X2RGB10 = AVPixelFormat.AV_PIX_FMT_X2RGB10BE;
            AV_PIX_FMT_X2BGR10 = AVPixelFormat.AV_PIX_FMT_X2BGR10BE;

            AV_PIX_FMT_P210 = AVPixelFormat.AV_PIX_FMT_P210BE;
            AV_PIX_FMT_P410 = AVPixelFormat.AV_PIX_FMT_P410BE;
            AV_PIX_FMT_P216 = AVPixelFormat.AV_PIX_FMT_P216BE;
            AV_PIX_FMT_P416 = AVPixelFormat.AV_PIX_FMT_P416BE;
        }
    }

    public static AVPixelFormat AV_PIX_FMT_RGB32 { get; }
    public static AVPixelFormat AV_PIX_FMT_RGB32_1 { get; }
    public static AVPixelFormat AV_PIX_FMT_BGR32 { get; }
    public static AVPixelFormat AV_PIX_FMT_BGR32_1 { get; }
    public static AVPixelFormat AV_PIX_FMT_0RGB32 { get; }
    public static AVPixelFormat AV_PIX_FMT_0BGR32 { get; }

    public static AVPixelFormat AV_PIX_FMT_GRAY9 { get; }
    public static AVPixelFormat AV_PIX_FMT_GRAY10 { get; }
    public static AVPixelFormat AV_PIX_FMT_GRAY12 { get; }
    public static AVPixelFormat AV_PIX_FMT_GRAY14 { get; }
    public static AVPixelFormat AV_PIX_FMT_GRAY16 { get; }
    public static AVPixelFormat AV_PIX_FMT_YA16 { get; }
    public static AVPixelFormat AV_PIX_FMT_RGB48 { get; }
    public static AVPixelFormat AV_PIX_FMT_RGB565 { get; }
    public static AVPixelFormat AV_PIX_FMT_RGB555 { get; }
    public static AVPixelFormat AV_PIX_FMT_RGB444 { get; }
    public static AVPixelFormat AV_PIX_FMT_RGBA64 { get; }
    public static AVPixelFormat AV_PIX_FMT_BGR48 { get; }
    public static AVPixelFormat AV_PIX_FMT_BGR565 { get; }
    public static AVPixelFormat AV_PIX_FMT_BGR555 { get; }
    public static AVPixelFormat AV_PIX_FMT_BGR444 { get; }
    public static AVPixelFormat AV_PIX_FMT_BGRA64 { get; }

    public static AVPixelFormat AV_PIX_FMT_YUV420P9 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV422P9 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV444P9 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV420P10 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV422P10 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV440P10 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV444P10 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV420P12 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV422P12 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV440P12 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV444P12 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV420P14 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV422P14 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV444P14 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV420P16 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV422P16 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUV444P16 { get; }

    public static AVPixelFormat AV_PIX_FMT_GBRP9 { get; }
    public static AVPixelFormat AV_PIX_FMT_GBRP10 { get; }
    public static AVPixelFormat AV_PIX_FMT_GBRP12 { get; }
    public static AVPixelFormat AV_PIX_FMT_GBRP14 { get; }
    public static AVPixelFormat AV_PIX_FMT_GBRP16 { get; }
    public static AVPixelFormat AV_PIX_FMT_GBRAP10 { get; }
    public static AVPixelFormat AV_PIX_FMT_GBRAP12 { get; }
    public static AVPixelFormat AV_PIX_FMT_GBRAP16 { get; }

    public static AVPixelFormat AV_PIX_FMT_BAYER_BGGR16 { get; }
    public static AVPixelFormat AV_PIX_FMT_BAYER_RGGB16 { get; }
    public static AVPixelFormat AV_PIX_FMT_BAYER_GBRG16 { get; }
    public static AVPixelFormat AV_PIX_FMT_BAYER_GRBG16 { get; }

    public static AVPixelFormat AV_PIX_FMT_GBRPF32 { get; }
    public static AVPixelFormat AV_PIX_FMT_GBRAPF32 { get; }

    public static AVPixelFormat AV_PIX_FMT_GRAYF32 { get; }

    public static AVPixelFormat AV_PIX_FMT_YUVA420P9 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUVA422P9 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUVA444P9 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUVA420P10 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUVA422P10 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUVA444P10 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUVA422P12 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUVA444P12 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUVA420P16 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUVA422P16 { get; }
    public static AVPixelFormat AV_PIX_FMT_YUVA444P16 { get; }

    public static AVPixelFormat AV_PIX_FMT_XYZ12 { get; }
    public static AVPixelFormat AV_PIX_FMT_NV20 { get; }
    public static AVPixelFormat AV_PIX_FMT_AYUV64 { get; }
    public static AVPixelFormat AV_PIX_FMT_P010 { get; }
    public static AVPixelFormat AV_PIX_FMT_P016 { get; }

    public static AVPixelFormat AV_PIX_FMT_Y210 { get; }
    public static AVPixelFormat AV_PIX_FMT_X2RGB10 { get; }
    public static AVPixelFormat AV_PIX_FMT_X2BGR10 { get; }

    public static AVPixelFormat AV_PIX_FMT_P210 { get; }
    public static AVPixelFormat AV_PIX_FMT_P410 { get; }
    public static AVPixelFormat AV_PIX_FMT_P216 { get; }
    public static AVPixelFormat AV_PIX_FMT_P416 { get; }
}
