namespace Antrv.FFMpeg.Interop;

public struct AVReplayGain
{
    /// <summary>
    /// Track replay gain in microbels (divide by 100000 to get the value in dB).
    /// Should be set to INT32_MIN when unknown.
    /// </summary>
    public int TrackGain;

    /// <summary>
    /// Peak track amplitude, with 100000 representing full scale (but values
    /// may overflow). 0 when unknown.
    /// </summary>
    public uint TrackPeak;

    /// <summary>
    /// Same as track_gain, but for the whole album.
    /// </summary>
    public int AlbumGain;

    /// <summary>
    /// Same as track_peak, but for the whole album.
    /// </summary>
    public uint AlbumPeak;
}
