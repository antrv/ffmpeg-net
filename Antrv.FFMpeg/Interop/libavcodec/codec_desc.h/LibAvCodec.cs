namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    /// <summary>
    /// descriptor for given codec ID or NULL if no descriptor exists.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodecDescriptor> avcodec_descriptor_get(AVCodecID id);

    /// <summary>
    /// Iterate over all codec descriptors known to libavcodec.
    /// </summary>
    /// <param name="prev">previous descriptor. NULL to get the first descriptor.</param>
    /// <returns>next descriptor or NULL after the last descriptor</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodecDescriptor> avcodec_descriptor_next(ConstPtr<AVCodecDescriptor> prev);

    /// <summary>
    /// codec descriptor with the given name or NULL if no such descriptor exists.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodecDescriptor> avcodec_descriptor_get_by_name(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string name);
}
