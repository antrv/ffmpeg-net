namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Bytestream IO Context.
///
/// NOTE: None of the function pointers in AVIOContext should be called
/// directly, they should only be set by the client application
/// when implementing custom I/O. Normally these are set to the
/// function pointers specified in avio_alloc_context()
/// </summary>
public struct AVIOContext
{
    /// <summary>
    /// A class for private options.
    ///
    /// If this AVIOContext is created by avio_open2(), av_class is set and
    /// passes the options down to protocols.
    ///
    /// If this AVIOContext is manually allocated, then av_class may be set by the caller.
    ///
    /// warning -- this field can be NULL, be sure to not pass this AVIOContext
    /// to any av_opt_* functions in that case.
    /// </summary>
    public ConstPtr<AVClass> Class;

    /*
     * The following shows the relationship between buffer, buf_ptr,
     * buf_ptr_max, buf_end, buf_size, and pos, when reading and when writing
     * (since AVIOContext is used for both):
     *
     **********************************************************************************
     *                                   READING
     **********************************************************************************
     *
     *                            |              buffer_size              |
     *                            |---------------------------------------|
     *                            |                                       |
     *
     *                         buffer          buf_ptr       buf_end
     *                            +---------------+-----------------------+
     *                            |/ / / / / / / /|/ / / / / / /|         |
     *  read buffer:              |/ / consumed / | to be read /|         |
     *                            |/ / / / / / / /|/ / / / / / /|         |
     *                            +---------------+-----------------------+
     *
     *                                                         pos
     *              +-------------------------------------------+-----------------+
     *  input file: |                                           |                 |
     *              +-------------------------------------------+-----------------+
     *
     *
     **********************************************************************************
     *                                   WRITING
     **********************************************************************************
     *
     *                             |          buffer_size                 |
     *                             |--------------------------------------|
     *                             |                                      |
     *
     *                                                buf_ptr_max
     *                          buffer                 (buf_ptr)       buf_end
     *                             +-----------------------+--------------+
     *                             |/ / / / / / / / / / / /|              |
     *  write buffer:              | / / to be flushed / / |              |
     *                             |/ / / / / / / / / / / /|              |
     *                             +-----------------------+--------------+
     *                               buf_ptr can be in this
     *                               due to a backward seek
     *
     *                            pos
     *               +-------------+----------------------------------------------+
     *  output file: |             |                                              |
     *               +-------------+----------------------------------------------+
     *
     */

    /// <summary>
    /// Start of the buffer.
    /// </summary>
    public Ptr<byte> Buffer;

    /// <summary>
    /// Maximum buffer size
    /// </summary>
    public int BufferSize;

    /// <summary>
    /// Current position in the buffer
    /// </summary>
    public Ptr<byte> BufPtr;

    /// <summary>
    /// End of the data, may be less than buffer+buffer_size if the read function returned
    /// less data than requested, e.g. for streams where no more data has been received yet.
    /// </summary>
    public Ptr<byte> BufEnd;

    /// <summary>
    /// A private pointer, passed to the read/write/seek/... functions.
    /// </summary>
    public IntPtr Opaque;

    public IntPtr ReadPacket; // int (*read_packet)(void *opaque, uint8_t *buf, int buf_size);
    public IntPtr WritePacket; // int (*write_packet)(void *opaque, uint8_t *buf, int buf_size);
    public IntPtr Seek; // int64_t (*seek)(void *opaque, int64_t offset, int whence);

    /// <summary>
    /// position in the file of the current buffer
    /// </summary>
    public long Pos;

    /// <summary>
    /// true if was unable to read due to error or eof
    /// </summary>
    public int EofReached;

    /// <summary>
    /// contains the error code or 0 if no error happened
    /// </summary>
    public int Error;

    /// <summary>
    /// true if open for writing
    /// </summary>
    public int WriteFlag;

    public int MaxPacketSize;

    /// <summary>
    /// Try to buffer at least this amount of data before flushing it.
    /// </summary>
    public int MinPacketSize;

    public uint CheckSum; // unsigned long // TODO check size
    public Ptr<byte> CheckSumPtr;
    public IntPtr UpdateCheckSum; // unsigned long (*update_checksum)(unsigned long checksum, const uint8_t *buf, unsigned int size);

    /// <summary>
    /// Pause or resume playback for network streaming protocols - e.g. MMS.
    /// </summary>
    public IntPtr ReadPause; // int (*read_pause)(void *opaque, int pause);

    /// <summary>
    /// Seek to a given timestamp in stream with the specified stream_index.
    /// Needed for some network streaming protocols which don't support seeking
    /// to byte position.
    /// </summary>
    public IntPtr ReadSeek; // int64_t (*read_seek)(void *opaque, int stream_index, int64_t timestamp, int flags);

    /// <summary>
    /// A combination of AVIO_SEEKABLE_ flags or 0 when the stream is not seekable.
    /// </summary>
    public AVIOSeekableFlags Seekable;

    /// <summary>
    /// avio_read and avio_write should if possible be satisfied directly
    /// instead of going through a buffer, and avio_seek will always
    /// call the underlying seek function directly.
    /// </summary>
    public int Direct;

    /// <summary>
    /// ',' separated list of allowed protocols.
    /// </summary>
    public Utf8StringPtr ProtocolWhitelist;

    /// <summary>
    /// ',' separated list of disallowed protocols.
    /// </summary>
    public Utf8StringPtr ProtocolBlacklist;

    /// <summary>
    /// A callback that is used instead of write_packet.
    /// </summary>
    public IntPtr WriteDataType; // int (*write_data_type)(void *opaque, uint8_t *buf, int buf_size, enum AVIODataMarkerType type, int64_t time);

    /// <summary>
    /// If set, don't call write_data_type separately for AVIO_DATA_MARKER_BOUNDARY_POINT,
    /// but ignore them and treat them as AVIO_DATA_MARKER_UNKNOWN (to avoid needlessly
    /// small chunks of data returned from the callback).
    /// </summary>
    public int IgnoreBoundaryPoint;

    /// <summary>
    /// field utilized privately by libavformat. For a public
    /// statistic of how many bytes were written out, see
    /// AVIOContext::bytes_written.
    /// </summary>
    [Obsolete("field utilized privately by libavformat")]
    public long Written;

    /// <summary>
    /// Maximum reached position before a backward seek in the write buffer,
    /// used keeping track of already written data for a later flush.
    /// </summary>
    public Ptr<byte> BufPtrMax;

    /// <summary>
    /// Read-only statistic of bytes read for this AVIOContext.
    /// </summary>
    public long BytesRead;

    /// <summary>
    /// Read-only statistic of bytes written for this AVIOContext.
    /// </summary>
    public long BytesWritten;
}
