namespace Antrv.FFMpeg.Interop;

partial class LibSwResample
{
    public static int LIBSWRESAMPLE_VERSION_MAJOR => 4;
    public static int LIBSWRESAMPLE_VERSION_MINOR => 3;
    public static int LIBSWRESAMPLE_VERSION_MICRO => 100;

    public static int LIBSWRESAMPLE_VERSION_INT => LibAvUtil.AV_VERSION_INT(LIBSWRESAMPLE_VERSION_MAJOR,
        LIBSWRESAMPLE_VERSION_MINOR, LIBSWRESAMPLE_VERSION_MICRO);

    public static string LIBSWRESAMPLE_VERSION => LibAvUtil.AV_VERSION(LIBSWRESAMPLE_VERSION_MAJOR,
        LIBSWRESAMPLE_VERSION_MINOR, LIBSWRESAMPLE_VERSION_MICRO);

    public static int LIBSWRESAMPLE_BUILD => LIBSWRESAMPLE_VERSION_INT;

    public static string LIBSWRESAMPLE_IDENT => "SwR" + LIBSWRESAMPLE_VERSION;
}
