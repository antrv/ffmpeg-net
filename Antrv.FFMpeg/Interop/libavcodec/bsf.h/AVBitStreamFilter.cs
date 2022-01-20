namespace Antrv.FFMpeg.Interop;

public struct AVBitStreamFilter
{
    public Utf8StringPtr Name;

    /// <summary>
    /// A list of codec ids supported by the filter, terminated by AV_CODEC_ID_NONE.
    /// May be NULL, in that case the bitstream filter works with any codec id.
    /// </summary>
    public ConstPtr<AVCodecID> CodecIds;

    /// <summary>
    /// A class for the private data, used to declare bitstream filter private
    /// AVOptions. This field is NULL for bitstream filters that do not declare any options.
    ///
    /// If this field is non-NULL, the first member of the filter private data
    /// must be a pointer to AVClass, which will be set by libavcodec generic
    /// code to this class.
    /// </summary>
    public ConstPtr<AVClass> PrivateClass;

    // No fields below this line are part of the public API. They
    // may not be used outside of libavcodec and can be changed and removed at will.
    // New public fields should be added right above.
}
