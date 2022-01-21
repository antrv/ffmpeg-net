namespace Antrv.FFMpeg.Interop;

partial class LibPostProc
{
    public const int PP_QUALITY_MAX = 6;

    /// <summary>
    /// MPEG2 style QScale
    /// </summary>
    public const int PP_PICT_TYPE_QP2 = 0x00000010;

    /// <summary>
    /// Return the LIBPOSTPROC_VERSION_INT constant.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint postproc_version();

    /// <summary>
    /// Return the libpostproc build-time configuration.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr postproc_configuration();

    [DllImport(LibraryName)]
    public static extern Utf8StringPtr postproc_license();

    [DllImport(LibraryName)]
    public static extern void pp_postprocess(ConstPtr<Array3<ConstPtr<byte>>> src, ConstPtr<Array3<int>> srcStride,
        Ptr<Array3<Ptr<byte>>> dst, ConstPtr<Array3<int>> dstStride, int horizontalSize, int verticalSize,
        ConstPtr<sbyte> qpStore, int qpStride, Ptr<PPMode> mode, Ptr<PPContext> ppContext, int pictType);

    /// <summary>
    /// Return a pp_mode or NULL if an error occurred.
    /// </summary>
    /// <param name="name">the string after "-pp" on the command line</param>
    /// <param name="quality">a number from 0 to PP_QUALITY_MAX</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<PPMode> pp_get_mode_by_name_and_quality([MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        int quality);

    [DllImport(LibraryName)]
    public static extern void pp_free_mode(Ptr<PPMode> mode);

    [DllImport(LibraryName)]
    public static extern Ptr<PPContext> pp_get_context(int width, int height, PPContextFlags flags);

    [DllImport(LibraryName)]
    public static extern void pp_free_context(Ptr<PPContext> ppContext);
}
