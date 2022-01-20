namespace Antrv.FFMpeg.Interop;

public struct AVIndexEntry
{
    public long Pos;

    /// <summary>
    /// Timestamp in AVStream.time_base units, preferably the time from which on correctly decoded frames are available
    /// when seeking to this entry. That means preferable PTS on keyframe based formats.
    /// But demuxers can choose to store a different timestamp, if it is more convenient for the implementation or nothing better is known
    /// </summary>
    public long Timestamp;

    /// <summary>
    /// Flag is used to indicate which frame should be discarded after decoding.
    /// Yeah, trying to keep the size of this small to reduce memory requirements (it is 24 vs. 32 bytes due to possible 8-byte alignment).
    /// </summary>
    public int FlagsAndSize; // 2 bits - AVIndexFlags, 30 bits - size

    /// <summary>
    /// Minimum distance between this and the previous keyframe, used to avoid unneeded searching.
    /// </summary>
    public int MinDistance;
}
