namespace Antrv.FFMpeg.Interop;

/// <summary>
/// The bitstream filter state.
///
/// This struct must be allocated with av_bsf_alloc() and freed with av_bsf_free().
///
/// The fields in the struct will only be changed (by the caller or by the
/// filter) as described in their documentation, and are to be considered
/// immutable otherwise.
/// </summary>
public struct AVBSFContext
{
    /// <summary>
    /// A class for logging and AVOptions
    /// </summary>
    public ConstPtr<AVClass> Class;

    /// <summary>
    /// The bitstream filter this context is an instance of.
    /// </summary>
    public ConstPtr<AVBitStreamFilter> Filter;

    /// <summary>
    /// Opaque filter-specific private data. If filter->priv_class is non-NULL,
    /// this is an AVOptions-enabled struct.
    /// </summary>
    public IntPtr PrivateData;

    /// <summary>
    /// Parameters of the input stream. This field is allocated in
    /// av_bsf_alloc(), it needs to be filled by the caller before
    /// av_bsf_init().
    /// </summary>
    public Ptr<AVCodecParameters> InputParameters;

    /// <summary>
    /// Parameters of the output stream. This field is allocated in
    /// av_bsf_alloc(), it is set by the filter in av_bsf_init().
    /// </summary>
    public Ptr<AVCodecParameters> OutputParameters;

    /// <summary>
    /// The timebase used for the timestamps of the input packets. Set by the
    /// caller before av_bsf_init().
    /// </summary>
    public AVRational InputTimeBase;

    /// <summary>
    /// The timebase used for the timestamps of the output packets. Set by the
    /// filter in av_bsf_init().
    /// </summary>
    public AVRational OutputTimeBase;
}
