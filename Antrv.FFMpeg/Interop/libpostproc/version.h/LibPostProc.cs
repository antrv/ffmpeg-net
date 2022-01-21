﻿namespace Antrv.FFMpeg.Interop;

partial class LibPostProc
{
    public static int LIBPOSTPROC_VERSION_MAJOR => 56;
    public static int LIBPOSTPROC_VERSION_MINOR => 3;
    public static int LIBPOSTPROC_VERSION_MICRO => 100;

    public static int LIBPOSTPROC_VERSION_INT => LibAvUtil.AV_VERSION_INT(LIBPOSTPROC_VERSION_MAJOR,
        LIBPOSTPROC_VERSION_MINOR, LIBPOSTPROC_VERSION_MICRO);

    public static string LIBPOSTPROC_VERSION => LibAvUtil.AV_VERSION(LIBPOSTPROC_VERSION_MAJOR,
        LIBPOSTPROC_VERSION_MINOR, LIBPOSTPROC_VERSION_MICRO);

    public static int LIBPOSTPROC_BUILD => LIBPOSTPROC_VERSION_INT;

    public static string LIBPOSTPROC_IDENT => "postproc" + LIBPOSTPROC_VERSION;
}
