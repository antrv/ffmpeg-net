namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Different data types that can be returned via the AVIO write_data_type callback.
/// </summary>
public enum AVIODataMarkerType
{
    /// <summary>
    /// Header data; this needs to be present for the stream to be decodeable.
    /// </summary>
    AVIO_DATA_MARKER_HEADER,

    /// <summary>
    /// A point in the output bytestream where a decoder can start decoding
    /// (i.e. a keyframe). A demuxer/decoder given the data flagged with
    /// AVIO_DATA_MARKER_HEADER, followed by any AVIO_DATA_MARKER_SYNC_POINT,
    /// should give decodeable results.
    /// </summary>
    AVIO_DATA_MARKER_SYNC_POINT,

    /// <summary>
    /// A point in the output bytestream where a demuxer can start parsing
    /// (for non self synchronizing bytestream formats). That is, any
    /// non-keyframe packet start point.
    /// </summary>
    AVIO_DATA_MARKER_BOUNDARY_POINT,

    /// <summary>
    /// This is any, unlabelled data. It can either be a muxer not marking
    /// any positions at all, it can be an actual boundary/sync point
    /// that the muxer chooses not to mark, or a later part of a packet/fragment
    /// that is cut into multiple write callbacks due to limited IO buffer size.
    /// </summary>
    AVIO_DATA_MARKER_UNKNOWN,

    /// <summary>
    /// Trailer data, which doesn't contain actual content, but only for
    /// finalizing the output file.
    /// </summary>
    AVIO_DATA_MARKER_TRAILER,

    /// <summary>
    /// A point in the output bytestream where the underlying AVIOContext might
    /// flush the buffer depending on latency or buffering requirements. Typically
    /// means the end of a packet.
    /// </summary>
    AVIO_DATA_MARKER_FLUSH_POINT,
}
