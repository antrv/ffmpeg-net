using System.Runtime.CompilerServices;
using System.Text;

namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Return the LIBAVUTIL_VERSION_INT constant.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint avutil_version();

    /// <summary>
    /// Return an informative version string. This usually is the actual release
    /// version number or a git commit description. This string has no fixed format
    /// and can change any time. It should never be parsed by code.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_version_info();

    /// <summary>
    /// Return the libavutil build-time configuration.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr avutil_configuration();

    /// <summary>
    /// Return the libavutil license.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr avutil_license();

    /// <summary>
    /// Return a string describing the media_type enum, NULL if media_type is unknown.
    /// </summary>
    /// <param name="mediaType"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_get_media_type_string(AVMediaType mediaType);

    public const int FF_LAMBDA_SHIFT = 7;
    public const int FF_LAMBDA_SCALE = 1 << FF_LAMBDA_SHIFT;

    /// <summary>
    /// factor to convert from H.263 QP to lambda
    /// </summary>
    public const int FF_QP2LAMBDA = 118;

    public const int FF_LAMBDA_MAX = 256 * 128 - 1;
    public const int FF_QUALITY_SCALE = FF_LAMBDA_SCALE;

    /// <summary>
    /// Undefined timestamp value.
    /// Usually reported by demuxer that work on containers that do not provide either pts or dts.
    /// </summary>
    public const long AV_NOPTS_VALUE = unchecked((long)0x8000000000000000);

    /// <summary>
    /// Internal time base represented as integer
    /// </summary>
    public const int AV_TIME_BASE = 1000000;

    /// <summary>
    /// Internal time base represented as fractional value
    /// </summary>
    public static AVRational AV_TIME_BASE_Q => new(1, AV_TIME_BASE);

    /// <summary>
    /// Return a single letter to describe the given picture type pict_type.
    /// </summary>
    /// <param name="pictType">the picture type</param>
    /// <returns>a single character</returns>
    [DllImport(LibraryName)]
    public static extern byte av_get_picture_type_char(AVPictureType pictType);

    /// <summary>
    /// Return x default pointer in case p is NULL.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="p"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public static Ptr<T> av_x_if_null<T>(Ptr<T> p, Ptr<T> x)
        where T : unmanaged =>
        p.IsNull ? x : p;

    /// <summary>
    /// Compute the length of an integer list.
    /// </summary>
    /// <param name="elSize">size in bytes of each list element (only 1, 2, 4 or 8)</param>
    /// <param name="list">list terminator (usually 0 or -1)</param>
    /// <param name="term">pointer to the list</param>
    /// <returns>length of the list, in elements, not counting the terminator</returns>
    [DllImport(LibraryName)]
    public static extern uint av_int_list_length_for_size(uint elSize, ConstPtr<byte> list, ulong term);

    /// <summary>
    /// Compute the length of an integer list.
    /// </summary>
    /// <param name="list">list terminator (usually 0 or -1)</param>
    /// <param name="term">pointer to the list</param>
    /// <returns>length of the list, in elements, not counting the terminator</returns>
    public static uint av_int_list_length<T>(Ptr<T> list, ulong term)
        where T : unmanaged => av_int_list_length_for_size((uint)Unsafe.SizeOf<T>(), list.Cast<byte>(), term);

    /// <summary>
    /// Open a file using a UTF-8 filename.
    /// The API of this function matches POSIX fopen(), errors are returned through errno.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<FILE> av_fopen_utf8([MarshalAs(UnmanagedType.LPUTF8Str)] string path,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string mode);

    /// <summary>
    /// Return the fractional representation of the internal time base.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVRational av_get_time_base_q();

    public const int AV_FOURCC_MAX_STRING_SIZE = 32;

    /// <summary>
    /// Fill the provided buffer with a string containing a FourCC (four-character code) representation.
    /// </summary>
    /// <param name="buf">a buffer with size in bytes of at least AV_FOURCC_MAX_STRING_SIZE</param>
    /// <param name="fourcc">the fourcc to represent</param>
    /// <returns>the buffer in input</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<byte> av_fourcc_make_string(Ptr<byte> buf, uint fourcc);

    public static string av_fourcc2str(uint fourcc)
    {
        byte[] data = new byte[AV_FOURCC_MAX_STRING_SIZE];
        Ptr<byte> result = av_fourcc_make_string(Ptr.FromRef(ref data[0]), fourcc);
        return Encoding.UTF8.GetString(data).Trim();
    } 
}