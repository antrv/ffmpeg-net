namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Return the flags which specify extensions supported by the CPU.
    /// The returned value is affected by av_force_cpu_flags() if that was used
    /// before. So av_get_cpu_flags() can easily be used in an application to
    /// detect the enabled cpu flags.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVCpuFlags av_get_cpu_flags();

    /// <summary>
    /// Disables cpu detection and forces the specified flags.
    /// -1 is a special case that disables forcing of specific flags.
    /// </summary>
    /// <param name="flags"></param>
    [DllImport(LibraryName)]
    public static extern void av_force_cpu_flags(AVCpuFlags flags);

    /// <summary>
    /// Parse CPU caps from a string and update the given AV_CPU_* flags based on that.
    /// </summary>
    /// <param name="flags"></param>
    /// <param name="s"></param>
    /// <returns>negative on error.</returns>
    [DllImport(LibraryName)]
    public static extern AVCpuFlags av_parse_cpu_caps(ref AVCpuFlags flags,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string s);

    /// <summary>
    /// Returns the number of logical CPU cores present.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_cpu_count();

    /// <summary>
    /// Overrides cpu count detection and forces the specified count.
    /// Count &lt; 1 disables forcing of specific count.
    /// </summary>
    /// <param name="count"></param>
    [DllImport(LibraryName)]
    public static extern void av_cpu_force_count(int count);

    /// <summary>
    /// Get the maximum data alignment that may be required by FFmpeg.
    ///
    /// Note that this is affected by the build configuration and the CPU flags mask,
    /// so e.g. if the CPU supports AVX, but libavutil has been built with
    /// --disable-avx or the AV_CPU_FLAG_AVX flag has been disabled through
    /// av_set_cpu_flags_mask(), then this function will behave as if AVX is not
    /// present.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern nuint av_cpu_max_align();
}
