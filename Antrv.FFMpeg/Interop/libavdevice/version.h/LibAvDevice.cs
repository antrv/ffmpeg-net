﻿namespace Antrv.FFMpeg.Interop;

partial class LibAvDevice
{
    public static int LIBAVDEVICE_VERSION_MAJOR => 59;
    public static int LIBAVDEVICE_VERSION_MINOR => 4;
    public static int LIBAVDEVICE_VERSION_MICRO => 100;

    public static int LIBAVDEVICE_VERSION_INT => LibAvUtil.AV_VERSION_INT(LIBAVDEVICE_VERSION_MAJOR,
        LIBAVDEVICE_VERSION_MINOR, LIBAVDEVICE_VERSION_MICRO);

    public static string LIBAVDEVICE_VERSION =>
        LibAvUtil.AV_VERSION(LIBAVDEVICE_VERSION_MAJOR, LIBAVDEVICE_VERSION_MINOR, LIBAVDEVICE_VERSION_MICRO);

    public static int LIBAVDEVICE_BUILD => LIBAVDEVICE_VERSION_INT;

    public static string LIBAVDEVICE_IDENT => "Lavd" + LIBAVDEVICE_VERSION;
}