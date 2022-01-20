using Antrv.FFMpeg.Types;

namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Return the number of bits per pixel used by the pixel format
    /// described by pixdesc. Note that this is not the same as the number
    /// of bits per sample.
    ///
    /// The returned number of bits refers to the number of bits actually
    /// used for storing the pixel information, that is padding bits are
    /// not counted.
    /// </summary>
    /// <param name="pixDesc"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_get_bits_per_pixel(ConstPtr<AVPixFmtDescriptor> pixDesc);

    /// <summary>
    /// Return the number of bits per pixel for the pixel format
    /// described by pixdesc, including any padding or unused bits.
    /// </summary>
    /// <param name="pixDesc"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_get_padded_bits_per_pixel(ConstPtr<AVPixFmtDescriptor> pixDesc);

    /// <summary>
    /// Returns a pixel format descriptor for provided pixel format or NULL if
    /// this pixel format is unknown.
    /// </summary>
    /// <param name="pixFmt"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVPixFmtDescriptor> av_pix_fmt_desc_get(AVPixelFormat pixFmt);

    /// <summary>
    /// Iterate over all pixel format descriptors known to libavutil.
    /// </summary>
    /// <param name="prev">previous descriptor. NULL to get the first descriptor.</param>
    /// <returns>next descriptor or NULL after the last descriptor</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVPixFmtDescriptor> av_pix_fmt_desc_next(Ptr<AVPixFmtDescriptor> prev);

    /// <summary>
    /// Returns an AVPixelFormat id described by desc, or AV_PIX_FMT_NONE if desc
    /// is not a valid pointer to a pixel format descriptor.
    /// </summary>
    /// <param name="desc"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVPixelFormat av_pix_fmt_desc_get_id(ConstPtr<AVPixFmtDescriptor> desc);

    /// <summary>
    /// Utility function to access log2_chroma_w log2_chroma_h from the pixel format AVPixFmtDescriptor.
    /// </summary>
    /// <param name="pixFmt">the pixel format</param>
    /// <param name="hShift">store log2_chroma_w (horizontal/width shift)</param>
    /// <param name="vShift">store log2_chroma_h (vertical/height shift)</param>
    /// <returns>0 on success, AVERROR(ENOSYS) on invalid or unknown pixel format</returns>
    [DllImport(LibraryName)]
    public static extern int av_pix_fmt_get_chroma_sub_sample(AVPixelFormat pixFmt, out int hShift, out int vShift);

    /// <summary>
    /// Returns number of planes in pix_fmt, a negative AVERROR if pix_fmt is not a valid pixel format.
    /// </summary>
    /// <param name="pixFmt"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_pix_fmt_count_planes(AVPixelFormat pixFmt);

    /// <summary>
    /// Returns the name for provided color range or NULL if unknown.
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_color_range_name(AVColorRange range);

    /// <summary>
    /// Returns the AVColorRange value for name or an AVError if not found.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_color_range_from_name([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// Returns the name for provided color primaries or NULL if unknown.
    /// </summary>
    /// <param name="primaries"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_color_primaries_name(AVColorPrimaries primaries);

    /// <summary>
    /// Returns the AVColorPrimaries value for name or an AVError if not found.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_color_primaries_from_name([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// Returns the name for provided color transfer or NULL if unknown.
    /// </summary>
    /// <param name="transfer"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_color_transfer_name(AVColorTransferCharacteristic transfer);

    /// <summary>
    /// Returns the AVColorTransferCharacteristic value for name or an AVError if not found.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_color_transfer_from_name([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// Returns the name for provided color space or NULL if unknown.
    /// </summary>
    /// <param name="space"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_color_space_name(AVColorSpace space);

    /// <summary>
    /// Returns the AVColorSpace value for name or an AVError if not found.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_color_space_from_name([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// Returns the name for provided chroma location or NULL if unknown.
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_chroma_location_name(AVChromaLocation location);

    /// <summary>
    /// Returns the AVChromaLocation value for name or an AVError if not found.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_chroma_location_from_name([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// Return the pixel format corresponding to name.
    ///
    /// If there is no pixel format with name name, then looks for a
    /// pixel format with the name corresponding to the native endian format of name.
    /// For example in a little-endian system, first looks for "gray16", then for "gray16le".
    ///
    /// Finally if no pixel format has been found, returns AV_PIX_FMT_NONE.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVPixelFormat av_get_pix_fmt([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// Return the short name for a pixel format, NULL in case pix_fmt is unknown.
    /// </summary>
    /// <param name="pixFmt"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_get_pix_fmt_name(AVPixelFormat pixFmt);

    /// <summary>
    /// Print in buf the string corresponding to the pixel format with
    /// number pix_fmt, or a header if pix_fmt is negative.
    /// </summary>
    /// <param name="buf">the buffer where to write the string</param>
    /// <param name="bufSize">the size of buf</param>
    /// <param name="pixFmt">the number of the pixel format to print the
    /// corresponding info string, or a negative value to print the
    /// corresponding header.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<byte> av_get_pix_fmt_string(Ptr<byte> buf, int bufSize, AVPixelFormat pixFmt);

    /// <summary>
    /// Read a line from an image, and write the values of the pixel format component c to dst.
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="data">the array containing the pointers to the planes of the image</param>
    /// <param name="lineSize">the array containing the linesizes of the image</param>
    /// <param name="desc">the pixel format descriptor for the image</param>
    /// <param name="x">the horizontal coordinate of the first pixel to read</param>
    /// <param name="y">the vertical coordinate of the first pixel to read</param>
    /// <param name="c"></param>
    /// <param name="w">the width of the line to read, that is the number of values to write to dst</param>
    /// <param name="readPalComponent">if not zero and the format is a paletted format writes the values corresponding to the palette
    /// component c in data[1] to dst, rather than the palette indexes in data[0]. The behavior is undefined if the format is not paletted.</param>
    /// <param name="dstElementSize">size of elements in dst array (2 or 4 byte)</param>
    [DllImport(LibraryName)]
    public static extern void av_read_image_line2(Ptr<byte> dst, ConstPtr<Array4<ConstPtr<byte>>> data,
        ConstPtr<Array4<int>> lineSize, ConstPtr<AVPixFmtDescriptor> desc, int x, int y, int c, int w,
        int readPalComponent, int dstElementSize);

    /// <summary>
    /// Read a line from an image, and write the values of the pixel format component c to dst.
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="data">the array containing the pointers to the planes of the image</param>
    /// <param name="lineSize">the array containing the linesizes of the image</param>
    /// <param name="desc">the pixel format descriptor for the image</param>
    /// <param name="x">the horizontal coordinate of the first pixel to read</param>
    /// <param name="y">the vertical coordinate of the first pixel to read</param>
    /// <param name="c"></param>
    /// <param name="w">the width of the line to read, that is the number of values to write to dst</param>
    /// <param name="readPalComponent">if not zero and the format is a paletted format writes the values corresponding to the palette
    /// component c in data[1] to dst, rather than the palette indexes in data[0]. The behavior is undefined if the format is not paletted.</param>
    [DllImport(LibraryName)]
    public static extern void av_read_image_line(Ptr<ushort> dst, ConstPtr<Array4<ConstPtr<byte>>> data,
        ConstPtr<Array4<int>> lineSize, ConstPtr<AVPixFmtDescriptor> desc, int x, int y, int c, int w,
        int readPalComponent);

    /// <summary>
    /// Write the values from src to the pixel format component c of an image line.
    /// </summary>
    /// <param name="src">array containing the values to write</param>
    /// <param name="data">the array containing the pointers to the planes of the image to write into. It is supposed to be zeroed.</param>
    /// <param name="lineSize">the array containing the linesizes of the image</param>
    /// <param name="desc">the pixel format descriptor for the image</param>
    /// <param name="x">the horizontal coordinate of the first pixel to write</param>
    /// <param name="y">the vertical coordinate of the first pixel to write</param>
    /// <param name="c"></param>
    /// <param name="w">the width of the line to write, that is the number of values to write to the image line</param>
    /// <param name="srcElementSize">size of elements in src array (2 or 4 byte)</param>
    [DllImport(LibraryName)]
    public static extern void av_write_image_line2(ConstPtr<byte> src, Ptr<Array4<Ptr<byte>>> data,
        ConstPtr<Array4<int>> lineSize, ConstPtr<AVPixFmtDescriptor> desc, int x, int y, int c, int w,
        int srcElementSize);

    /// <summary>
    /// Write the values from src to the pixel format component c of an image line.
    /// </summary>
    /// <param name="src">array containing the values to write</param>
    /// <param name="data">the array containing the pointers to the planes of the image to write into. It is supposed to be zeroed.</param>
    /// <param name="lineSize">the array containing the linesizes of the image</param>
    /// <param name="desc">the pixel format descriptor for the image</param>
    /// <param name="x">the horizontal coordinate of the first pixel to write</param>
    /// <param name="y">the vertical coordinate of the first pixel to write</param>
    /// <param name="c"></param>
    /// <param name="w">the width of the line to write, that is the number of values to write to the image line</param>
    [DllImport(LibraryName)]
    public static extern void av_write_image_line(ConstPtr<ushort> src, Ptr<Array4<Ptr<byte>>> data,
        ConstPtr<Array4<int>> lineSize, ConstPtr<AVPixFmtDescriptor> desc, int x, int y, int c, int w);

    /// <summary>
    /// Utility function to swap the endianness of a pixel format.
    /// </summary>
    /// <param name="pixFmt">the pixel format</param>
    /// <returns>pixel format with swapped endianness if it exists, otherwise AV_PIX_FMT_NONE</returns>
    [DllImport(LibraryName)]
    public static extern AVPixelFormat av_pix_fmt_swap_endianness(AVPixelFormat pixFmt);

    /// <summary>
    /// Compute what kind of losses will occur when converting from one specific
    /// pixel format to another.
    /// When converting from one pixel format to another, information loss may occur.
    /// For example, when converting from RGB24 to GRAY, the color information will
    /// be lost. Similarly, other losses occur when converting from some formats to
    /// other formats. These losses can involve loss of chroma, but also loss of
    /// resolution, loss of color depth, loss due to the color space conversion, loss
    /// of the alpha bits or loss due to color quantization.
    /// av_get_fix_fmt_loss() informs you about the various types of losses
    /// which will occur when converting from one pixel format to another.
    /// </summary>
    /// <param name="dstPixFmt">destination pixel format</param>
    /// <param name="srcPixFmt">source pixel format</param>
    /// <param name="hasAlpha">Whether the source pixel format alpha channel is used.</param>
    /// <returns>Combination of flags informing you what kind of losses will occur
    /// (maximum loss for an invalid dst_pix_fmt).</returns>
    [DllImport(LibraryName)]
    public static extern AVPixelFormatLossKind av_get_pix_fmt_loss(AVPixelFormat dstPixFmt, AVPixelFormat srcPixFmt,
        int hasAlpha);

    /// <summary>
    /// Compute what kind of losses will occur when converting from one specific
    /// pixel format to another.
    /// When converting from one pixel format to another, information loss may occur.
    /// For example, when converting from RGB24 to GRAY, the color information will
    /// be lost. Similarly, other losses occur when converting from some formats to
    /// other formats. These losses can involve loss of chroma, but also loss of
    /// resolution, loss of color depth, loss due to the color space conversion, loss
    /// of the alpha bits or loss due to color quantization.
    /// av_get_fix_fmt_loss() informs you about the various types of losses
    /// which will occur when converting from one pixel format to another.
    /// </summary>
    /// <param name="dstPixFmt1">destination pixel format</param>
    /// <param name="dstPixFmt2"></param>
    /// <param name="srcPixFmt">source pixel format</param>
    /// <param name="hasAlpha">Whether the source pixel format alpha channel is used.</param>
    /// <param name="lossPtr">Combination of flags informing you what kind of losses will occur (maximum loss for an invalid dst_pix_fmt).</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVPixelFormat av_find_best_pix_fmt_of_2(AVPixelFormat dstPixFmt1, AVPixelFormat dstPixFmt2,
        AVPixelFormat srcPixFmt, int hasAlpha, out AVPixelFormatLossKind lossPtr);
}
