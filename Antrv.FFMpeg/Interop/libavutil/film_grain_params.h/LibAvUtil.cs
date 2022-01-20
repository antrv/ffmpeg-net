namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Allocate an AVFilmGrainParams structure and set its fields to
    /// default values. The resulting struct can be freed using av_freep().
    /// If size is not NULL it will be set to the number of bytes allocated.
    /// </summary>
    /// <param name="size"></param>
    /// <returns>An AVFilmGrainParams filled with default values or NULL on failure.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVFilmGrainParams> av_film_grain_params_alloc(out nuint size);

    /// <summary>
    /// Allocate a complete AVFilmGrainParams and add it to the frame.
    /// </summary>
    /// <param name="frame">The frame which side data is added to.</param>
    /// <returns>The AVFilmGrainParams structure to be filled by caller.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVFilmGrainParams> av_film_grain_params_create_side_data(Ptr<AVFrame> frame);
}
