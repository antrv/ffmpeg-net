namespace Antrv.FFMpeg.Interop;

/// <summary>
/// List of AVOptionRange structs.
/// </summary>
public struct AVOptionRanges
{
    /// <summary>
    /// Array of option ranges.
    /// Most of option types use just one component.
    /// Following describes multi-component option types:
    ///
    /// AV_OPT_TYPE_IMAGE_SIZE:
    /// component index 0: range of pixel count (width * height).
    /// component index 1: range of width.
    /// component index 2: range of height.
    ///
    /// To obtain multi-component version of this structure, user must
    /// provide AV_OPT_MULTI_COMPONENT_RANGE to av_opt_query_ranges or
    /// av_opt_query_ranges_default function.
    /// </summary>
    public Ptr<Ptr<AVOptionRange>> Range;

    /// <summary>
    /// Number of ranges per component.
    /// </summary>
    public int RangeCount;

    /// <summary>
    /// Number of components.
    /// </summary>
    public int ComponentCount;
}
