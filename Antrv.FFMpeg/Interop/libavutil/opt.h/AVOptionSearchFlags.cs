namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVOptionSearchFlags
{
    None = 0,

    /// <summary>
    /// Search in possible children of the given object first.
    /// </summary>
    AV_OPT_SEARCH_CHILDREN = 1 << 0,

    /// <summary>
    /// The obj passed to av_opt_find() is fake -- only a double pointer to AVClass
    /// instead of a required pointer to a struct containing AVClass. This is
    /// useful for searching for options without needing to allocate the corresponding object.
    /// </summary>
    AV_OPT_SEARCH_FAKE_OBJ = 1 << 1,

    /// <summary>
    /// In av_opt_get, return NULL if the option has a pointer type and is set to NULL,
    /// rather than returning an empty string.
    /// </summary>
    AV_OPT_ALLOW_NULL = 1 << 2,

    /// <summary>
    /// Allows av_opt_query_ranges and av_opt_query_ranges_default to return more than
    /// one component for certain option types.
    /// </summary>
    AV_OPT_MULTI_COMPONENT_RANGE = 1 << 12,
}
