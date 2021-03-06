namespace Antrv.FFMpeg.Interop;

/// <summary>
///  Pixel format.
///
/// AV_PIX_FMT_RGB32 is handled in an endian-specific manner. An RGBA color is put together as:
/// (A &lt;&lt; 24) | (R &lt;&lt; 16) | (G &lt;&lt; 8) | B
/// This is stored as BGRA on little-endian CPU architectures and ARGB on big-endian CPUs.
///
/// If the resolution is not a multiple of the chroma subsampling factor
/// then the chroma plane resolution must be rounded up.
///
/// When the pixel format is palettized RGB32 (AV_PIX_FMT_PAL8), the palettized
/// image data is stored in AVFrame.data[0]. The palette is transported in
/// AVFrame.data[1], is 1024 bytes long (256 4-byte entries) and is
/// formatted the same as in AV_PIX_FMT_RGB32 described above (i.e., it is
/// also endian-specific). Note also that the individual RGB32 palette
/// components stored in AVFrame.data[1] should be in the range 0..255.
/// This is important as many custom PAL8 video codecs that were designed
/// to run on the IBM VGA graphics adapter use 6-bit palette components.
///
///
/// For all the 8 bits per pixel formats, an RGB32 palette is in data[1] like
/// for pal8. This palette is filled in automatically by the function
/// allocating the picture.
/// </summary>
public enum AVPixelFormat
{
    AV_PIX_FMT_NONE = -1,

    /// <summary>
    /// planar YUV 4:2:0, 12bpp, (1 Cr & Cb sample per 2x2 Y samples)
    /// </summary>
    AV_PIX_FMT_YUV420P,

    /// <summary>
    /// packed YUV 4:2:2, 16bpp, Y0 Cb Y1 Cr
    /// </summary>
    AV_PIX_FMT_YUYV422,

    /// <summary>
    /// packed RGB 8:8:8, 24bpp, RGBRGB...
    /// </summary>
    AV_PIX_FMT_RGB24,

    /// <summary>
    /// packed RGB 8:8:8, 24bpp, BGRBGR...
    /// </summary>
    AV_PIX_FMT_BGR24,

    /// <summary>
    /// planar YUV 4:2:2, 16bpp, (1 Cr & Cb sample per 2x1 Y samples)
    /// </summary>
    AV_PIX_FMT_YUV422P,

    /// <summary>
    /// planar YUV 4:4:4, 24bpp, (1 Cr & Cb sample per 1x1 Y samples)
    /// </summary>
    AV_PIX_FMT_YUV444P,

    /// <summary>
    /// planar YUV 4:1:0,  9bpp, (1 Cr & Cb sample per 4x4 Y samples)
    /// </summary>
    AV_PIX_FMT_YUV410P,

    /// <summary>
    /// planar YUV 4:1:1, 12bpp, (1 Cr & Cb sample per 4x1 Y samples)
    /// </summary>
    AV_PIX_FMT_YUV411P,

    /// <summary>
    ///        Y        ,  8bpp
    /// </summary>
    AV_PIX_FMT_GRAY8,

    /// <summary>
    ///        Y        ,  1bpp, 0 is white, 1 is black, in each byte pixels are ordered from the msb to the lsb
    /// </summary>
    AV_PIX_FMT_MONOWHITE,

    /// <summary>
    ///        Y        ,  1bpp, 0 is black, 1 is white, in each byte pixels are ordered from the msb to the lsb
    /// </summary>
    AV_PIX_FMT_MONOBLACK,

    /// <summary>
    /// 8 bits with AV_PIX_FMT_RGB32 palette
    /// </summary>
    AV_PIX_FMT_PAL8,

    /// <summary>
    /// planar YUV 4:2:0, 12bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV420P and setting color_range
    /// </summary>
    AV_PIX_FMT_YUVJ420P,

    /// <summary>
    /// planar YUV 4:2:2, 16bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV422P and setting color_range
    /// </summary>
    AV_PIX_FMT_YUVJ422P,

    /// <summary>
    /// planar YUV 4:4:4, 24bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV444P and setting color_range
    /// </summary>
    AV_PIX_FMT_YUVJ444P,

    /// <summary>
    /// packed YUV 4:2:2, 16bpp, Cb Y0 Cr Y1
    /// </summary>
    AV_PIX_FMT_UYVY422,

    /// <summary>
    /// packed YUV 4:1:1, 12bpp, Cb Y0 Y1 Cr Y2 Y3
    /// </summary>
    AV_PIX_FMT_UYYVYY411,

    /// <summary>
    /// packed RGB 3:3:2,  8bpp, (msb)2B 3G 3R(lsb)
    /// </summary>
    AV_PIX_FMT_BGR8,

    /// <summary>
    /// packed RGB 1:2:1 bitstream,  4bpp, (msb)1B 2G 1R(lsb), a byte contains two pixels, the first pixel in the byte is the one composed by the 4 msb bits
    /// </summary>
    AV_PIX_FMT_BGR4,

    /// <summary>
    /// packed RGB 1:2:1,  8bpp, (msb)1B 2G 1R(lsb)
    /// </summary>
    AV_PIX_FMT_BGR4_BYTE,

    /// <summary>
    /// packed RGB 3:3:2,  8bpp, (msb)2R 3G 3B(lsb)
    /// </summary>
    AV_PIX_FMT_RGB8,

    /// <summary>
    /// packed RGB 1:2:1 bitstream,  4bpp, (msb)1R 2G 1B(lsb), a byte contains two pixels, the first pixel in the byte is the one composed by the 4 msb bits
    /// </summary>
    AV_PIX_FMT_RGB4,

    /// <summary>
    /// packed RGB 1:2:1,  8bpp, (msb)1R 2G 1B(lsb)
    /// </summary>
    AV_PIX_FMT_RGB4_BYTE,

    /// <summary>
    /// planar YUV 4:2:0, 12bpp, 1 plane for Y and 1 plane for the UV components, which are interleaved (first byte U and the following byte V)
    /// </summary>
    AV_PIX_FMT_NV12,

    /// <summary>
    /// as above, but U and V bytes are swapped
    /// </summary>
    AV_PIX_FMT_NV21,

    /// <summary>
    /// packed ARGB 8:8:8:8, 32bpp, ARGBARGB...
    /// </summary>
    AV_PIX_FMT_ARGB,

    /// <summary>
    /// packed RGBA 8:8:8:8, 32bpp, RGBARGBA...
    /// </summary>
    AV_PIX_FMT_RGBA,

    /// <summary>
    /// packed ABGR 8:8:8:8, 32bpp, ABGRABGR...
    /// </summary>
    AV_PIX_FMT_ABGR,

    /// <summary>
    /// packed BGRA 8:8:8:8, 32bpp, BGRABGRA...
    /// </summary>
    AV_PIX_FMT_BGRA,

    /// <summary>
    ///        Y        , 16bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GRAY16BE,

    /// <summary>
    ///        Y        , 16bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GRAY16LE,

    /// <summary>
    /// planar YUV 4:4:0 (1 Cr & Cb sample per 1x2 Y samples)
    /// </summary>
    AV_PIX_FMT_YUV440P,

    /// <summary>
    /// planar YUV 4:4:0 full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV440P and setting color_range
    /// </summary>
    AV_PIX_FMT_YUVJ440P,

    /// <summary>
    /// planar YUV 4:2:0, 20bpp, (1 Cr & Cb sample per 2x2 Y & A samples)
    /// </summary>
    AV_PIX_FMT_YUVA420P,

    /// <summary>
    /// packed RGB 16:16:16, 48bpp, 16R, 16G, 16B, the 2-byte value for each R/G/B component is stored as big-endian
    /// </summary>
    AV_PIX_FMT_RGB48BE,

    /// <summary>
    /// packed RGB 16:16:16, 48bpp, 16R, 16G, 16B, the 2-byte value for each R/G/B component is stored as little-endian
    /// </summary>
    AV_PIX_FMT_RGB48LE,

    /// <summary>
    /// packed RGB 5:6:5, 16bpp, (msb)   5R 6G 5B(lsb), big-endian
    /// </summary>
    AV_PIX_FMT_RGB565BE,

    /// <summary>
    /// packed RGB 5:6:5, 16bpp, (msb)   5R 6G 5B(lsb), little-endian
    /// </summary>
    AV_PIX_FMT_RGB565LE,

    /// <summary>
    /// packed RGB 5:5:5, 16bpp, (msb)1X 5R 5G 5B(lsb), big-endian   , X=unused/undefined
    /// </summary>
    AV_PIX_FMT_RGB555BE,

    /// <summary>
    /// packed RGB 5:5:5, 16bpp, (msb)1X 5R 5G 5B(lsb), little-endian, X=unused/undefined
    /// </summary>
    AV_PIX_FMT_RGB555LE,

    /// <summary>
    /// packed BGR 5:6:5, 16bpp, (msb)   5B 6G 5R(lsb), big-endian
    /// </summary>
    AV_PIX_FMT_BGR565BE,

    /// <summary>
    /// packed BGR 5:6:5, 16bpp, (msb)   5B 6G 5R(lsb), little-endian
    /// </summary>
    AV_PIX_FMT_BGR565LE,

    /// <summary>
    /// packed BGR 5:5:5, 16bpp, (msb)1X 5B 5G 5R(lsb), big-endian, X=unused/undefined
    /// </summary>
    AV_PIX_FMT_BGR555BE,

    /// <summary>
    /// packed BGR 5:5:5, 16bpp, (msb)1X 5B 5G 5R(lsb), little-endian, X=unused/undefined
    /// </summary>
    AV_PIX_FMT_BGR555LE,

    /// <summary>
    /// Hardware acceleration through VA-API, data[3] contains a VASurfaceID.
    /// </summary>
    AV_PIX_FMT_VAAPI,

    /// <summary>
    /// planar YUV 4:2:0, 24bpp, (1 Cr & Cb sample per 2x2 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV420P16LE,

    /// <summary>
    /// planar YUV 4:2:0, 24bpp, (1 Cr & Cb sample per 2x2 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV420P16BE,

    /// <summary>
    /// planar YUV 4:2:2, 32bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV422P16LE,

    /// <summary>
    /// planar YUV 4:2:2, 32bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV422P16BE,

    /// <summary>
    /// planar YUV 4:4:4, 48bpp, (1 Cr & Cb sample per 1x1 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV444P16LE,

    /// <summary>
    /// planar YUV 4:4:4, 48bpp, (1 Cr & Cb sample per 1x1 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV444P16BE,

    /// <summary>
    /// HW decoding through DXVA2, Picture.data[3] contains a LPDIRECT3DSURFACE9 pointer
    /// </summary>
    AV_PIX_FMT_DXVA2_VLD,

    /// <summary>
    /// packed RGB 4:4:4, 16bpp, (msb)4X 4R 4G 4B(lsb), little-endian, X=unused/undefined
    /// </summary>
    AV_PIX_FMT_RGB444LE,

    /// <summary>
    /// packed RGB 4:4:4, 16bpp, (msb)4X 4R 4G 4B(lsb), big-endian,    X=unused/undefined
    /// </summary>
    AV_PIX_FMT_RGB444BE,

    /// <summary>
    /// packed BGR 4:4:4, 16bpp, (msb)4X 4B 4G 4R(lsb), little-endian, X=unused/undefined
    /// </summary>
    AV_PIX_FMT_BGR444LE,

    /// <summary>
    /// packed BGR 4:4:4, 16bpp, (msb)4X 4B 4G 4R(lsb), big-endian,    X=unused/undefined
    /// </summary>
    AV_PIX_FMT_BGR444BE,

    /// <summary>
    /// 8 bits gray, 8 bits alpha
    /// </summary>
    AV_PIX_FMT_YA8,

    /// <summary>
    /// alias for AV_PIX_FMT_YA8
    /// </summary>
    AV_PIX_FMT_Y400A = AV_PIX_FMT_YA8,

    /// <summary>
    /// alias for AV_PIX_FMT_YA8
    /// </summary>
    AV_PIX_FMT_GRAY8A = AV_PIX_FMT_YA8,

    /// <summary>
    /// packed RGB 16:16:16, 48bpp, 16B, 16G, 16R, the 2-byte value for each R/G/B component is stored as big-endian
    /// </summary>
    AV_PIX_FMT_BGR48BE,

    /// <summary>
    /// packed RGB 16:16:16, 48bpp, 16B, 16G, 16R, the 2-byte value for each R/G/B component is stored as little-endian
    /// </summary>
    AV_PIX_FMT_BGR48LE,

    // The following 12 formats have the disadvantage of needing 1 format for each bit depth.
    // Notice that each 9/10 bits sample is stored in 16 bits with extra padding.
    // If you want to support multiple bit depths, then using AV_PIX_FMT_YUV420P16* with the bpp stored separately is better.
    /// <summary>
    /// planar YUV 4:2:0, 13.5bpp, (1 Cr & Cb sample per 2x2 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV420P9BE,

    /// <summary>
    /// planar YUV 4:2:0, 13.5bpp, (1 Cr & Cb sample per 2x2 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV420P9LE,

    /// <summary>
    /// planar YUV 4:2:0, 15bpp, (1 Cr & Cb sample per 2x2 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV420P10BE,

    /// <summary>
    /// planar YUV 4:2:0, 15bpp, (1 Cr & Cb sample per 2x2 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV420P10LE,

    /// <summary>
    /// planar YUV 4:2:2, 20bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV422P10BE,

    /// <summary>
    /// planar YUV 4:2:2, 20bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV422P10LE,

    /// <summary>
    /// planar YUV 4:4:4, 27bpp, (1 Cr & Cb sample per 1x1 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV444P9BE,

    /// <summary>
    /// planar YUV 4:4:4, 27bpp, (1 Cr & Cb sample per 1x1 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV444P9LE,

    /// <summary>
    /// planar YUV 4:4:4, 30bpp, (1 Cr & Cb sample per 1x1 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV444P10BE,

    /// <summary>
    /// planar YUV 4:4:4, 30bpp, (1 Cr & Cb sample per 1x1 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV444P10LE,

    /// <summary>
    /// planar YUV 4:2:2, 18bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV422P9BE,

    /// <summary>
    /// planar YUV 4:2:2, 18bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV422P9LE,

    /// <summary>
    /// planar GBR 4:4:4 24bpp
    /// </summary>
    AV_PIX_FMT_GBRP,

    /// <summary>
    /// alias for #AV_PIX_FMT_GBRP
    /// </summary>
    AV_PIX_FMT_GBR24P = AV_PIX_FMT_GBRP,

    /// <summary>
    /// planar GBR 4:4:4 27bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GBRP9BE,

    /// <summary>
    /// planar GBR 4:4:4 27bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GBRP9LE,

    /// <summary>
    /// planar GBR 4:4:4 30bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GBRP10BE,

    /// <summary>
    /// planar GBR 4:4:4 30bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GBRP10LE,

    /// <summary>
    /// planar GBR 4:4:4 48bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GBRP16BE,

    /// <summary>
    /// planar GBR 4:4:4 48bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GBRP16LE,

    /// <summary>
    /// planar YUV 4:2:2 24bpp, (1 Cr & Cb sample per 2x1 Y & A samples)
    /// </summary>
    AV_PIX_FMT_YUVA422P,

    /// <summary>
    /// planar YUV 4:4:4 32bpp, (1 Cr & Cb sample per 1x1 Y & A samples)
    /// </summary>
    AV_PIX_FMT_YUVA444P,

    /// <summary>
    /// planar YUV 4:2:0 22.5bpp, (1 Cr & Cb sample per 2x2 Y & A samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUVA420P9BE,

    /// <summary>
    /// planar YUV 4:2:0 22.5bpp, (1 Cr & Cb sample per 2x2 Y & A samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUVA420P9LE,

    /// <summary>
    /// planar YUV 4:2:2 27bpp, (1 Cr & Cb sample per 2x1 Y & A samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUVA422P9BE,

    /// <summary>
    /// planar YUV 4:2:2 27bpp, (1 Cr & Cb sample per 2x1 Y & A samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUVA422P9LE,

    /// <summary>
    /// planar YUV 4:4:4 36bpp, (1 Cr & Cb sample per 1x1 Y & A samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUVA444P9BE,

    /// <summary>
    /// planar YUV 4:4:4 36bpp, (1 Cr & Cb sample per 1x1 Y & A samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUVA444P9LE,

    /// <summary>
    /// planar YUV 4:2:0 25bpp, (1 Cr & Cb sample per 2x2 Y & A samples, big-endian)
    /// </summary>
    AV_PIX_FMT_YUVA420P10BE,

    /// <summary>
    /// planar YUV 4:2:0 25bpp, (1 Cr & Cb sample per 2x2 Y & A samples, little-endian)
    /// </summary>
    AV_PIX_FMT_YUVA420P10LE,

    /// <summary>
    /// planar YUV 4:2:2 30bpp, (1 Cr & Cb sample per 2x1 Y & A samples, big-endian)
    /// </summary>
    AV_PIX_FMT_YUVA422P10BE,

    /// <summary>
    /// planar YUV 4:2:2 30bpp, (1 Cr & Cb sample per 2x1 Y & A samples, little-endian)
    /// </summary>
    AV_PIX_FMT_YUVA422P10LE,

    /// <summary>
    /// planar YUV 4:4:4 40bpp, (1 Cr & Cb sample per 1x1 Y & A samples, big-endian)
    /// </summary>
    AV_PIX_FMT_YUVA444P10BE,

    /// <summary>
    /// planar YUV 4:4:4 40bpp, (1 Cr & Cb sample per 1x1 Y & A samples, little-endian)
    /// </summary>
    AV_PIX_FMT_YUVA444P10LE,

    /// <summary>
    /// planar YUV 4:2:0 40bpp, (1 Cr & Cb sample per 2x2 Y & A samples, big-endian)
    /// </summary>
    AV_PIX_FMT_YUVA420P16BE,

    /// <summary>
    /// planar YUV 4:2:0 40bpp, (1 Cr & Cb sample per 2x2 Y & A samples, little-endian)
    /// </summary>
    AV_PIX_FMT_YUVA420P16LE,

    /// <summary>
    /// planar YUV 4:2:2 48bpp, (1 Cr & Cb sample per 2x1 Y & A samples, big-endian)
    /// </summary>
    AV_PIX_FMT_YUVA422P16BE,

    /// <summary>
    /// planar YUV 4:2:2 48bpp, (1 Cr & Cb sample per 2x1 Y & A samples, little-endian)
    /// </summary>
    AV_PIX_FMT_YUVA422P16LE,

    /// <summary>
    /// planar YUV 4:4:4 64bpp, (1 Cr & Cb sample per 1x1 Y & A samples, big-endian)
    /// </summary>
    AV_PIX_FMT_YUVA444P16BE,

    /// <summary>
    /// planar YUV 4:4:4 64bpp, (1 Cr & Cb sample per 1x1 Y & A samples, little-endian)
    /// </summary>
    AV_PIX_FMT_YUVA444P16LE,

    /// <summary>
    /// HW acceleration through VDPAU, Picture.data[3] contains a VdpVideoSurface
    /// </summary>
    AV_PIX_FMT_VDPAU,

    /// <summary>
    /// packed XYZ 4:4:4, 36 bpp, (msb) 12X, 12Y, 12Z (lsb), the 2-byte value for each X/Y/Z is stored as little-endian, the 4 lower bits are set to 0
    /// </summary>
    AV_PIX_FMT_XYZ12LE,

    /// <summary>
    /// packed XYZ 4:4:4, 36 bpp, (msb) 12X, 12Y, 12Z (lsb), the 2-byte value for each X/Y/Z is stored as big-endian, the 4 lower bits are set to 0
    /// </summary>
    AV_PIX_FMT_XYZ12BE,

    /// <summary>
    /// interleaved chroma YUV 4:2:2, 16bpp, (1 Cr & Cb sample per 2x1 Y samples)
    /// </summary>
    AV_PIX_FMT_NV16,

    /// <summary>
    /// interleaved chroma YUV 4:2:2, 20bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_NV20LE,

    /// <summary>
    /// interleaved chroma YUV 4:2:2, 20bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_NV20BE,

    /// <summary>
    /// packed RGBA 16:16:16:16, 64bpp, 16R, 16G, 16B, 16A, the 2-byte value for each R/G/B/A component is stored as big-endian
    /// </summary>
    AV_PIX_FMT_RGBA64BE,

    /// <summary>
    /// packed RGBA 16:16:16:16, 64bpp, 16R, 16G, 16B, 16A, the 2-byte value for each R/G/B/A component is stored as little-endian
    /// </summary>
    AV_PIX_FMT_RGBA64LE,

    /// <summary>
    /// packed RGBA 16:16:16:16, 64bpp, 16B, 16G, 16R, 16A, the 2-byte value for each R/G/B/A component is stored as big-endian
    /// </summary>
    AV_PIX_FMT_BGRA64BE,

    /// <summary>
    /// packed RGBA 16:16:16:16, 64bpp, 16B, 16G, 16R, 16A, the 2-byte value for each R/G/B/A component is stored as little-endian
    /// </summary>
    AV_PIX_FMT_BGRA64LE,

    /// <summary>
    /// packed YUV 4:2:2, 16bpp, Y0 Cr Y1 Cb
    /// </summary>
    AV_PIX_FMT_YVYU422,

    /// <summary>
    /// 16 bits gray, 16 bits alpha (big-endian)
    /// </summary>
    AV_PIX_FMT_YA16BE,

    /// <summary>
    /// 16 bits gray, 16 bits alpha (little-endian)
    /// </summary>
    AV_PIX_FMT_YA16LE,

    /// <summary>
    /// planar GBRA 4:4:4:4 32bpp
    /// </summary>
    AV_PIX_FMT_GBRAP,

    /// <summary>
    /// planar GBRA 4:4:4:4 64bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GBRAP16BE,

    /// <summary>
    /// planar GBRA 4:4:4:4 64bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GBRAP16LE,

    /// <summary>
    /// HW acceleration through QSV, data[3] contains a pointer to the  mfxFrameSurface1 structure.
    /// </summary>
    AV_PIX_FMT_QSV,

    /// <summary>
    /// HW acceleration though MMAL, data[3] contains a pointer to the MMAL_BUFFER_HEADER_T structure.
    /// </summary>
    AV_PIX_FMT_MMAL,

    /// <summary>
    /// HW decoding through Direct3D11 via old API, Picture.data[3] contains a ID3D11VideoDecoderOutputView pointer
    /// </summary>
    AV_PIX_FMT_D3D11VA_VLD,

    /// <summary>
    /// HW acceleration through CUDA. data[i] contain CUdeviceptr pointers exactly as for system memory frames.
    /// </summary>
    AV_PIX_FMT_CUDA,

    /// <summary>
    /// packed RGB 8:8:8, 32bpp, XRGBXRGB...   X=unused/undefined
    /// </summary>
    AV_PIX_FMT_0RGB,

    /// <summary>
    /// packed RGB 8:8:8, 32bpp, RGBXRGBX...   X=unused/undefined
    /// </summary>
    AV_PIX_FMT_RGB0,

    /// <summary>
    /// packed BGR 8:8:8, 32bpp, XBGRXBGR...   X=unused/undefined
    /// </summary>
    AV_PIX_FMT_0BGR,

    /// <summary>
    /// packed BGR 8:8:8, 32bpp, BGRXBGRX...   X=unused/undefined
    /// </summary>
    AV_PIX_FMT_BGR0,

    /// <summary>
    /// planar YUV 4:2:0,18bpp, (1 Cr & Cb sample per 2x2 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV420P12BE,

    /// <summary>
    /// planar YUV 4:2:0,18bpp, (1 Cr & Cb sample per 2x2 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV420P12LE,

    /// <summary>
    /// planar YUV 4:2:0,21bpp, (1 Cr & Cb sample per 2x2 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV420P14BE,

    /// <summary>
    /// planar YUV 4:2:0,21bpp, (1 Cr & Cb sample per 2x2 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV420P14LE,

    /// <summary>
    /// planar YUV 4:2:2,24bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV422P12BE,

    /// <summary>
    /// planar YUV 4:2:2,24bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV422P12LE,

    /// <summary>
    /// planar YUV 4:2:2,28bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV422P14BE,

    /// <summary>
    /// planar YUV 4:2:2,28bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV422P14LE,

    /// <summary>
    /// planar YUV 4:4:4,36bpp, (1 Cr & Cb sample per 1x1 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV444P12BE,

    /// <summary>
    /// planar YUV 4:4:4,36bpp, (1 Cr & Cb sample per 1x1 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV444P12LE,

    /// <summary>
    /// planar YUV 4:4:4,42bpp, (1 Cr & Cb sample per 1x1 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV444P14BE,

    /// <summary>
    /// planar YUV 4:4:4,42bpp, (1 Cr & Cb sample per 1x1 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV444P14LE,

    /// <summary>
    /// planar GBR 4:4:4 36bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GBRP12BE,

    /// <summary>
    /// planar GBR 4:4:4 36bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GBRP12LE,

    /// <summary>
    /// planar GBR 4:4:4 42bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GBRP14BE,

    /// <summary>
    /// planar GBR 4:4:4 42bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GBRP14LE,

    /// <summary>
    /// planar YUV 4:1:1, 12bpp, (1 Cr & Cb sample per 4x1 Y samples) full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV411P and setting color_range
    /// </summary>
    AV_PIX_FMT_YUVJ411P,

    /// <summary>
    /// bayer, BGBG..(odd line), GRGR..(even line), 8-bit samples
    /// </summary>
    AV_PIX_FMT_BAYER_BGGR8,

    /// <summary>
    /// bayer, RGRG..(odd line), GBGB..(even line), 8-bit samples
    /// </summary>
    AV_PIX_FMT_BAYER_RGGB8,

    /// <summary>
    /// bayer, GBGB..(odd line), RGRG..(even line), 8-bit samples
    /// </summary>
    AV_PIX_FMT_BAYER_GBRG8,

    /// <summary>
    /// bayer, GRGR..(odd line), BGBG..(even line), 8-bit samples
    /// </summary>
    AV_PIX_FMT_BAYER_GRBG8,

    /// <summary>
    /// bayer, BGBG..(odd line), GRGR..(even line), 16-bit samples, little-endian
    /// </summary>
    AV_PIX_FMT_BAYER_BGGR16LE,

    /// <summary>
    /// bayer, BGBG..(odd line), GRGR..(even line), 16-bit samples, big-endian
    /// </summary>
    AV_PIX_FMT_BAYER_BGGR16BE,

    /// <summary>
    /// bayer, RGRG..(odd line), GBGB..(even line), 16-bit samples, little-endian
    /// </summary>
    AV_PIX_FMT_BAYER_RGGB16LE,

    /// <summary>
    /// bayer, RGRG..(odd line), GBGB..(even line), 16-bit samples, big-endian
    /// </summary>
    AV_PIX_FMT_BAYER_RGGB16BE,

    /// <summary>
    /// bayer, GBGB..(odd line), RGRG..(even line), 16-bit samples, little-endian
    /// </summary>
    AV_PIX_FMT_BAYER_GBRG16LE,

    /// <summary>
    /// bayer, GBGB..(odd line), RGRG..(even line), 16-bit samples, big-endian
    /// </summary>
    AV_PIX_FMT_BAYER_GBRG16BE,

    /// <summary>
    /// bayer, GRGR..(odd line), BGBG..(even line), 16-bit samples, little-endian
    /// </summary>
    AV_PIX_FMT_BAYER_GRBG16LE,

    /// <summary>
    /// bayer, GRGR..(odd line), BGBG..(even line), 16-bit samples, big-endian
    /// </summary>
    AV_PIX_FMT_BAYER_GRBG16BE,

    /// <summary>
    /// XVideo Motion Acceleration via common packet passing
    /// </summary>
    AV_PIX_FMT_XVMC,

    /// <summary>
    /// planar YUV 4:4:0,20bpp, (1 Cr & Cb sample per 1x2 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV440P10LE,

    /// <summary>
    /// planar YUV 4:4:0,20bpp, (1 Cr & Cb sample per 1x2 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV440P10BE,

    /// <summary>
    /// planar YUV 4:4:0,24bpp, (1 Cr & Cb sample per 1x2 Y samples), little-endian
    /// </summary>
    AV_PIX_FMT_YUV440P12LE,

    /// <summary>
    /// planar YUV 4:4:0,24bpp, (1 Cr & Cb sample per 1x2 Y samples), big-endian
    /// </summary>
    AV_PIX_FMT_YUV440P12BE,

    /// <summary>
    /// packed AYUV 4:4:4,64bpp (1 Cr & Cb sample per 1x1 Y & A samples), little-endian
    /// </summary>
    AV_PIX_FMT_AYUV64LE,

    /// <summary>
    /// packed AYUV 4:4:4,64bpp (1 Cr & Cb sample per 1x1 Y & A samples), big-endian
    /// </summary>
    AV_PIX_FMT_AYUV64BE,

    /// <summary>
    /// hardware decoding through Videotoolbox
    /// </summary>
    AV_PIX_FMT_VIDEOTOOLBOX,

    /// <summary>
    /// like NV12, with 10bpp per component, data in the high bits, zeros in the low bits, little-endian
    /// </summary>
    AV_PIX_FMT_P010LE,

    /// <summary>
    /// like NV12, with 10bpp per component, data in the high bits, zeros in the low bits, big-endian
    /// </summary>
    AV_PIX_FMT_P010BE,

    /// <summary>
    /// planar GBR 4:4:4:4 48bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GBRAP12BE,

    /// <summary>
    /// planar GBR 4:4:4:4 48bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GBRAP12LE,

    /// <summary>
    /// planar GBR 4:4:4:4 40bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GBRAP10BE,

    /// <summary>
    /// planar GBR 4:4:4:4 40bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GBRAP10LE,

    /// <summary>
    /// hardware decoding through MediaCodec
    /// </summary>
    AV_PIX_FMT_MEDIACODEC,

    /// <summary>
    ///        Y        , 12bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GRAY12BE,

    /// <summary>
    ///        Y        , 12bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GRAY12LE,

    /// <summary>
    ///        Y        , 10bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GRAY10BE,

    /// <summary>
    ///        Y        , 10bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GRAY10LE,

    /// <summary>
    /// like NV12, with 16bpp per component, little-endian
    /// </summary>
    AV_PIX_FMT_P016LE,

    /// <summary>
    /// like NV12, with 16bpp per component, big-endian
    /// </summary>
    AV_PIX_FMT_P016BE,

    /// <summary>
    /// Hardware surfaces for Direct3D11.
    ///
    /// This is preferred over the legacy AV_PIX_FMT_D3D11VA_VLD. The new D3D11
    /// hwaccel API and filtering support AV_PIX_FMT_D3D11 only.
    ///
    /// data[0] contains a ID3D11Texture2D pointer, and data[1] contains the
    /// texture array index of the frame as intptr_t if the ID3D11Texture2D is
    /// an array texture (or always 0 if it's a normal texture).
    /// </summary>
    AV_PIX_FMT_D3D11,

    /// <summary>
    ///        Y        , 9bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GRAY9BE,

    /// <summary>
    ///        Y        , 9bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GRAY9LE,

    /// <summary>
    /// IEEE-754 single precision planar GBR 4:4:4,     96bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GBRPF32BE,

    /// <summary>
    /// IEEE-754 single precision planar GBR 4:4:4,     96bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GBRPF32LE,

    /// <summary>
    /// IEEE-754 single precision planar GBRA 4:4:4:4, 128bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GBRAPF32BE,

    /// <summary>
    /// IEEE-754 single precision planar GBRA 4:4:4:4, 128bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GBRAPF32LE,

    /// <summary>
    /// DRM-managed buffers exposed through PRIME buffer sharing.
    ///
    /// data[0] points to an AVDRMFrameDescriptor.
    /// </summary>
    AV_PIX_FMT_DRM_PRIME,

    /// <summary>
    /// Hardware surfaces for OpenCL.
    ///
    /// data[i] contain 2D image objects (typed in C as cl_mem, used
    /// in OpenCL as image2d_t) for each plane of the surface.
    /// </summary>
    AV_PIX_FMT_OPENCL,

    /// <summary>
    ///        Y        , 14bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GRAY14BE,

    /// <summary>
    ///        Y        , 14bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GRAY14LE,

    /// <summary>
    /// IEEE-754 single precision Y, 32bpp, big-endian
    /// </summary>
    AV_PIX_FMT_GRAYF32BE,

    /// <summary>
    /// IEEE-754 single precision Y, 32bpp, little-endian
    /// </summary>
    AV_PIX_FMT_GRAYF32LE,

    /// <summary>
    /// planar YUV 4:2:2,24bpp, (1 Cr & Cb sample per 2x1 Y samples), 12b alpha, big-endian
    /// </summary>
    AV_PIX_FMT_YUVA422P12BE,

    /// <summary>
    /// planar YUV 4:2:2,24bpp, (1 Cr & Cb sample per 2x1 Y samples), 12b alpha, little-endian
    /// </summary>
    AV_PIX_FMT_YUVA422P12LE,

    /// <summary>
    /// planar YUV 4:4:4,36bpp, (1 Cr & Cb sample per 1x1 Y samples), 12b alpha, big-endian
    /// </summary>
    AV_PIX_FMT_YUVA444P12BE,

    /// <summary>
    /// planar YUV 4:4:4,36bpp, (1 Cr & Cb sample per 1x1 Y samples), 12b alpha, little-endian
    /// </summary>
    AV_PIX_FMT_YUVA444P12LE,

    /// <summary>
    /// planar YUV 4:4:4, 24bpp, 1 plane for Y and 1 plane for the UV components, which are interleaved (first byte U and the following byte V)
    /// </summary>
    AV_PIX_FMT_NV24,

    /// <summary>
    /// as above, but U and V bytes are swapped
    /// </summary>
    AV_PIX_FMT_NV42,

    /// <summary>
    /// Vulkan hardware images.
    /// data[0] points to an AVVkFrame
    /// </summary>
    AV_PIX_FMT_VULKAN,

    /// <summary>
    /// packed YUV 4:2:2 like YUYV422, 20bpp, data in the high bits, big-endian
    /// </summary>
    AV_PIX_FMT_Y210BE,

    /// <summary>
    /// packed YUV 4:2:2 like YUYV422, 20bpp, data in the high bits, little-endian
    /// </summary>
    AV_PIX_FMT_Y210LE,

    /// <summary>
    /// packed RGB 10:10:10, 30bpp, (msb)2X 10R 10G 10B(lsb), little-endian, X=unused/undefined
    /// </summary>
    AV_PIX_FMT_X2RGB10LE,

    /// <summary>
    /// packed RGB 10:10:10, 30bpp, (msb)2X 10R 10G 10B(lsb), big-endian, X=unused/undefined
    /// </summary>
    AV_PIX_FMT_X2RGB10BE,

    /// <summary>
    /// packed BGR 10:10:10, 30bpp, (msb)2X 10B 10G 10R(lsb), little-endian, X=unused/undefined
    /// </summary>
    AV_PIX_FMT_X2BGR10LE,

    /// <summary>
    /// packed BGR 10:10:10, 30bpp, (msb)2X 10B 10G 10R(lsb), big-endian, X=unused/undefined
    /// </summary>
    AV_PIX_FMT_X2BGR10BE,

    /// <summary>
    /// interleaved chroma YUV 4:2:2, 20bpp, data in the high bits, big-endian
    /// </summary>
    AV_PIX_FMT_P210BE,

    /// <summary>
    /// interleaved chroma YUV 4:2:2, 20bpp, data in the high bits, little-endian
    /// </summary>
    AV_PIX_FMT_P210LE,

    /// <summary>
    /// interleaved chroma YUV 4:4:4, 30bpp, data in the high bits, big-endian
    /// </summary>
    AV_PIX_FMT_P410BE,

    /// <summary>
    /// interleaved chroma YUV 4:4:4, 30bpp, data in the high bits, little-endian
    /// </summary>
    AV_PIX_FMT_P410LE,

    /// <summary>
    /// interleaved chroma YUV 4:2:2, 32bpp, big-endian
    /// </summary>
    AV_PIX_FMT_P216BE,

    /// <summary>
    /// interleaved chroma YUV 4:2:2, 32bpp, liddle-endian
    /// </summary>
    AV_PIX_FMT_P216LE,

    /// <summary>
    /// interleaved chroma YUV 4:4:4, 48bpp, big-endian
    /// </summary>
    AV_PIX_FMT_P416BE,

    /// <summary>
    /// interleaved chroma YUV 4:4:4, 48bpp, little-endian
    /// </summary>
    AV_PIX_FMT_P416LE,
}
