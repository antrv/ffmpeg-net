namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Structure describing a single Region Of Interest.
///
/// When multiple regions are defined in a single side-data block, they
/// should be ordered from most to least important - some encoders are only
/// capable of supporting a limited number of distinct regions, so will have
/// to truncate the list.
///
/// When overlapping regions are defined, the first region containing a given
/// area of the frame applies.
/// </summary>
public struct AVRegionOfInterest
{
    /// <summary>
    /// Must be set to the size of this data structure (that is,
    /// sizeof(AVRegionOfInterest)).
    /// </summary>
    public uint SelfSize;

    /// <summary>
    /// Distance in pixels from the top edge of the frame to the top and
    /// bottom edges and from the left edge of the frame to the left and
    /// right edges of the rectangle defining this region of interest.
    ///
    /// The constraints on a region are encoder dependent, so the region
    /// actually affected may be slightly larger for alignment or other
    /// reasons.
    /// </summary>
    public int Top;

    public int Bottom;
    public int Left;
    public int Right;

    /// <summary>
    /// Quantization offset.
    ///
    /// Must be in the range -1 to +1.  A value of zero indicates no quality
    /// change.  A negative value asks for better quality (less quantization),
    /// while a positive value asks for worse quality (greater quantization).
    ///
    /// The range is calibrated so that the extreme values indicate the
    /// largest possible offset - if the rest of the frame is encoded with the
    /// worst possible quality, an offset of -1 indicates that this region
    /// should be encoded with the best possible quality anyway.  Intermediate
    /// values are then interpolated in some codec-dependent way.
    ///
    /// For example, in 10-bit H.264 the quantization parameter varies between
    /// -12 and 51.  A typical qoffset value of -1/10 therefore indicates that
    /// this region should be encoded with a QP around one-tenth of the full
    /// range better than the rest of the frame.  So, if most of the frame
    /// were to be encoded with a QP of around 30, this region would get a QP
    /// of around 24 (an offset of approximately -1/10/// (51 - -12) = -6.3).
    /// An extreme value of -1 would indicate that this region should be
    /// encoded with the best possible quality regardless of the treatment of
    /// the rest of the frame - that is, should be encoded at a QP of -12.
    /// </summary>
    public AVRational QOffset;
}
