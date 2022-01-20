namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVErrorRecognitionFlags
{
    None = 0,

    /// <summary>
    /// Verify checksums embedded in the bitstream (could be of either encoded or
    /// decoded data, depending on the codec) and print an error message on mismatch.
    /// If AV_EF_EXPLODE is also set, a mismatching checksum will result in the
    /// decoder returning an error.
    /// </summary>
    AV_EF_CRCCHECK = 1 << 0,

    /// <summary>
    /// detect bitstream specification deviations
    /// </summary>
    AV_EF_BITSTREAM = 1 << 1,

    /// <summary>
    /// detect improper bitstream length
    /// </summary>
    AV_EF_BUFFER = 1 << 2,

    /// <summary>
    /// abort decoding on minor error detection
    /// </summary>
    AV_EF_EXPLODE = 1 << 3,

    /// <summary>
    /// ignore errors and continue
    /// </summary>
    AV_EF_IGNORE_ERR = 1 << 15,

    /// <summary>
    /// consider things that violate the spec, are fast to calculate and have not been seen in the wild as errors
    /// </summary>
    AV_EF_CAREFUL = 1 << 16,

    /// <summary>
    /// consider all spec non compliances as errors
    /// </summary>
    AV_EF_COMPLIANT = 1 << 17,

    /// <summary>
    /// consider things that a sane encoder should not do as an error
    /// </summary>
    AV_EF_AGGRESSIVE = 1 << 18,
}
