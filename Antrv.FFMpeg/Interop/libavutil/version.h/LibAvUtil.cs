using System.Globalization;

namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    public static int LIBAVUTIL_VERSION_MAJOR => 57;
    public static int LIBAVUTIL_VERSION_MINOR => 17;
    public static int LIBAVUTIL_VERSION_MICRO => 100;

    public static int AV_VERSION_INT(int major, int minor, int micro) => (major << 16) | (minor << 8) | micro;

    public static string AV_VERSION(int major, int minor, int micro) =>
        string.Format(CultureInfo.InvariantCulture, "{0}.{1}.{2}", major, minor, micro);

    public static int AV_VERSION_MAJOR(int version) => version >> 16;

    public static int AV_VERSION_MINOR(int version) => (version & 0xFF00) >> 8;

    public static int AV_VERSION_MICRO(int version) => version & 0xFF;

    public static int LIBAVUTIL_VERSION_INT =>
        AV_VERSION_INT(LIBAVUTIL_VERSION_MAJOR, LIBAVUTIL_VERSION_MINOR, LIBAVUTIL_VERSION_MICRO);

    public static string LIBAVUTIL_VERSION =>
        AV_VERSION(LIBAVUTIL_VERSION_MAJOR, LIBAVUTIL_VERSION_MINOR, LIBAVUTIL_VERSION_MICRO);

    public static int LIBAVUTIL_BUILD => LIBAVUTIL_VERSION_INT;

    public static string LIBAVUTIL_IDENT => "Lavu" + LIBAVUTIL_VERSION;
}
