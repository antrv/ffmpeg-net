namespace Antrv.FFMpeg.Interop;

partial class LibAvFormat
{
    /// <summary>
    /// Return the name of the protocol that will handle the passed URL.
    /// NULL is returned if no protocol could be found for the given URL.
    /// </summary>
    /// <param name="url">Name of the protocol or NULL.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr avio_find_protocol_name([MarshalAs(UnmanagedType.LPUTF8Str)] string url);

    /// <summary>
    /// Return AVIO_FLAG_* access flags corresponding to the access permissions
    /// of the resource in url, or a negative value corresponding to an
    /// AVERROR code in case of failure. The returned access flags are
    /// masked by the value in flags.
    ///
    /// This function is intrinsically unsafe, in the sense that the
    /// checked resource may change its existence or permission status from
    /// one call to another. Thus you should not trust the returned value,
    /// unless you are sure that no other processes are accessing the
    /// checked resource.
    /// </summary>
    /// <param name="url"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVIOFlags avio_check([MarshalAs(UnmanagedType.LPUTF8Str)] string url, AVIOFlags flags);

    /// <summary>
    /// Open directory for reading.
    /// </summary>
    /// <param name="s">directory read context. Pointer to a NULL pointer must be passed.</param>
    /// <param name="url">directory to be listed.</param>
    /// <param name="options">A dictionary filled with protocol-private options. On return
    /// this parameter will be destroyed and replaced with a dictionary
    /// containing options that were not found. May be NULL.</param>
    /// <returns>>=0 on success or negative on error.</returns>
    [DllImport(LibraryName)]
    public static extern int avio_open_dir(out Ptr<AVIODirContext> s, [MarshalAs(UnmanagedType.LPUTF8Str)] string url,
        ref Ptr<AVDictionary> options);

    /// <summary>
    /// Get next directory entry.
    ///
    /// Returned entry must be freed with avio_free_directory_entry(). In particular it may outlive AVIODirContext.
    /// </summary>
    /// <param name="s">directory read context.</param>
    /// <param name="next">next entry or NULL when no more entries.</param>
    /// <returns>>=0 on success or negative on error. End of list is not considered an error.</returns>
    [DllImport(LibraryName)]
    public static extern int avio_read_dir(Ptr<AVIODirContext> s, out Ptr<AVIODirEntry> next);

    /// <summary>
    /// Close directory.
    ///
    /// Entries created using avio_read_dir() are not deleted and must be
    /// freeded with avio_free_directory_entry().
    /// </summary>
    /// <param name="s">directory read context.</param>
    /// <returns>>=0 on success or negative on error.</returns>
    [DllImport(LibraryName)]
    public static extern int avio_close_dir(ref Ptr<AVIODirContext> s);

    /// <summary>
    /// Free entry allocated by avio_read_dir().
    /// </summary>
    /// <param name="entry">entry to be freed.</param>
    [DllImport(LibraryName)]
    public static extern void avio_free_directory_entry(ref Ptr<AVIODirEntry> entry);

    /// <summary>
    /// Allocate and initialize an AVIOContext for buffered I/O. It must be later
    /// freed with avio_context_free().
    /// </summary>
    /// <param name="buffer">Memory block for input/output operations via AVIOContext.
    /// The buffer must be allocated with av_malloc() and friends.
    /// It may be freed and replaced with a new buffer by libavformat.
    /// AVIOContext.buffer holds the buffer currently in use,
    /// which must be later freed with av_free().</param>
    /// <param name="bufferSize">The buffer size is very important for performance.
    /// For protocols with fixed blocksize it should be set to this blocksize.
    /// For others a typical size is a cache page, e.g. 4kb.</param>
    /// <param name="writeFlag">Set to 1 if the buffer should be writable, 0 otherwise.</param>
    /// <param name="opaque">An opaque pointer to user-specific data.</param>
    /// <param name="readPacket">A function for refilling the buffer, may be NULL.
    /// For stream protocols, must never return 0 but rather a proper AVERROR code.</param>
    /// <param name="writePacket">A function for writing the buffer contents, may be NULL.
    /// The function may not change the input buffers content.</param>
    /// <param name="seek">A function for seeking to specified byte position, may be NULL.</param>
    /// <returns>Allocated AVIOContext or NULL on failure.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVIOContext> avio_alloc_context(Ptr<byte> buffer, int bufferSize, int writeFlag,
        IntPtr opaque, IntPtr readPacket, IntPtr writePacket, IntPtr seek);
    // int (* read_packet)(void* opaque, uint8_t* buf, int buf_size)
    // int (* write_packet)(void* opaque, uint8_t* buf, int buf_size)
    // int64_t (* seek)(void* opaque, int64_t offset, int whence)

    /// <summary>
    /// Free the supplied IO context and everything associated with it.
    /// </summary>
    /// <param name="s">Double pointer to the IO context. This function will write NULL into s.</param>
    [DllImport(LibraryName)]
    public static extern void avio_context_free(ref Ptr<AVIOContext> s);

    [DllImport(LibraryName)]
    public static extern void avio_w8(Ptr<AVIOContext> s, int b);

    [DllImport(LibraryName)]
    public static extern void avio_write(Ptr<AVIOContext> s, ConstPtr<byte> buffer, int size);

    [DllImport(LibraryName)]
    public static extern void avio_wl64(Ptr<AVIOContext> s, ulong val);

    [DllImport(LibraryName)]
    public static extern void avio_wb64(Ptr<AVIOContext> s, ulong val);

    [DllImport(LibraryName)]
    public static extern void avio_wl32(Ptr<AVIOContext> s, uint val);

    [DllImport(LibraryName)]
    public static extern void avio_wb32(Ptr<AVIOContext> s, uint val);

    [DllImport(LibraryName)]
    public static extern void avio_wl24(Ptr<AVIOContext> s, uint val);

    [DllImport(LibraryName)]
    public static extern void avio_wb24(Ptr<AVIOContext> s, uint val);

    [DllImport(LibraryName)]
    public static extern void avio_wl16(Ptr<AVIOContext> s, uint val);

    [DllImport(LibraryName)]
    public static extern void avio_wb16(Ptr<AVIOContext> s, uint val);

    /// <summary>
    /// Write a NULL-terminated string.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="str"></param>
    /// <returns>number of bytes written.</returns>
    [DllImport(LibraryName)]
    public static extern int avio_put_str(Ptr<AVIOContext> s, Ptr<byte> str);

    /// <summary>
    /// Convert an UTF-8 string to UTF-16LE and write it.
    /// </summary>
    /// <param name="s">the AVIOContext</param>
    /// <param name="str">NULL-terminated UTF-8 string</param>
    /// <returns>number of bytes written.</returns>
    [DllImport(LibraryName)]
    public static extern int avio_put_str16le(Ptr<AVIOContext> s, Ptr<byte> str);

    /// <summary>
    /// Convert an UTF-8 string to UTF-16BE and write it.
    /// </summary>
    /// <param name="s">the AVIOContext</param>
    /// <param name="str">NULL-terminated UTF-8 string</param>
    /// <returns>number of bytes written.</returns>
    [DllImport(LibraryName)]
    public static extern int avio_put_str16be(Ptr<AVIOContext> s, Ptr<byte> str);

    /// <summary>
    /// Mark the written bytestream as a specific type.
    ///
    /// Zero-length ranges are omitted from the output.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="time">the stream time the current bytestream pos corresponds to
    /// (in AV_TIME_BASE units), or AV_NOPTS_VALUE if unknown or not applicable</param>
    /// <param name="type">the kind of data written starting at the current pos</param>
    [DllImport(LibraryName)]
    public static extern void avio_write_marker(Ptr<AVIOContext> s, long time, AVIODataMarkerType type);

    /// <summary>
    /// ORing this as the "whence" parameter to a seek function causes it to
    /// return the filesize without seeking anywhere. Supporting this is optional.
    /// If it is not supported then the seek function will return &lt; 0.
    /// </summary>
    public const int AVSEEK_SIZE = 0x10000;

    /// <summary>
    /// Passing this flag as the "whence" parameter to a seek function causes it to
    /// seek by any means (like reopening and linear reading) or other normally unreasonable
    /// means that can be extremely slow.
    /// This may be ignored by the seek code.
    /// </summary>
    public const int AVSEEK_FORCE = 0x20000;

    /// <summary>
    /// fseek() equivalent for AVIOContext.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="offset"></param>
    /// <param name="whence"></param>
    /// <returns>new position or AVERROR.</returns>
    [DllImport(LibraryName)]
    public static extern long avio_seek(Ptr<AVIOContext> s, long offset, int whence);

    /// <summary>
    /// Skip given number of bytes forward
    /// </summary>
    /// <param name="s"></param>
    /// <param name="offset"></param>
    /// <returns>new position or AVERROR.</returns>
    [DllImport(LibraryName)]
    public static extern long avio_skip(Ptr<AVIOContext> s, long offset);

    /// <summary>
    /// ftell() equivalent for AVIOContext.
    /// </summary>
    /// <param name="s"></param>
    /// <returns>position or AVERROR.</returns>
    public static long avio_tell(Ptr<AVIOContext> s) => avio_seek(s, 0, 1); // 1 = SEEK_CUR

    /// <summary>
    /// Get the filesize.
    /// </summary>
    /// <param name="s"></param>
    /// <returns>filesize or AVERROR</returns>
    [DllImport(LibraryName)]
    public static extern long avio_size(Ptr<AVIOContext> s);

    /// <summary>
    /// Similar to feof() but also returns nonzero on read errors.
    /// </summary>
    /// <param name="s"></param>
    /// <returns>non zero if and only if at end of file or a read error happened when reading.</returns>
    [DllImport(LibraryName)]
    public static extern int avio_feof(Ptr<AVIOContext> s);

    // TODO:
    //int avio_printf(AVIOContext* s, const char* fmt, ...) av_printf_format(2, 3);

    /// <summary>
    /// Write a NULL terminated array of strings to the context.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="strings"></param>
    [DllImport(LibraryName)]
    public static extern void avio_print_string_array(Ptr<AVIOContext> s,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)] string[] strings);

    // TODO:
    // #define avio_print(s, ...) \
    //      avio_print_string_array(s, (const char*[]){__VA_ARGS__, NULL})

    /// <summary>
    /// Force flushing of buffered data.
    ///
    /// For write streams, force the buffered data to be immediately written to the output,
    /// without to wait to fill the internal buffer.
    ///
    /// For read streams, discard all currently buffered data, and advance the
    /// reported file position to that of the underlying stream. This does not
    /// read new data, and does not perform any seeks.
    /// </summary>
    /// <param name="s"></param>
    [DllImport(LibraryName)]
    public static extern void avio_flush(Ptr<AVIOContext> s);

    /// <summary>
    /// Read size bytes from AVIOContext into buf.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="buffer"></param>
    /// <param name="size"></param>
    /// <returns>number of bytes read or AVERROR</returns>
    [DllImport(LibraryName)]
    public static extern int avio_read(Ptr<AVIOContext> s, Ptr<byte> buffer, int size);

    /// <summary>
    /// Read size bytes from AVIOContext into buf. Unlike avio_read(), this is allowed
    /// to read fewer bytes than requested. The missing bytes can be read in the next
    /// call. This always tries to read at least 1 byte.
    /// Useful to reduce latency in certain cases.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="buffer"></param>
    /// <param name="size"></param>
    /// <returns>number of bytes read or AVERROR</returns>
    [DllImport(LibraryName)]
    public static extern int avio_read_partial(Ptr<AVIOContext> s, Ptr<byte> buffer, int size);

    /// <summary>
    /// Functions for reading from AVIOContext.
    /// Note: returns 0 if EOF, so you cannot use it if EOF handling is
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int avio_r8(Ptr<AVIOContext> s);

    /// <summary>
    /// Functions for reading from AVIOContext.
    /// Note: returns 0 if EOF, so you cannot use it if EOF handling is
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint avio_rl16(Ptr<AVIOContext> s);

    /// <summary>
    /// Functions for reading from AVIOContext.
    /// Note: returns 0 if EOF, so you cannot use it if EOF handling is
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint avio_rl24(Ptr<AVIOContext> s);

    /// <summary>
    /// Functions for reading from AVIOContext.
    /// Note: returns 0 if EOF, so you cannot use it if EOF handling is
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint avio_rl32(Ptr<AVIOContext> s);

    /// <summary>
    /// Functions for reading from AVIOContext.
    /// Note: returns 0 if EOF, so you cannot use it if EOF handling is
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ulong avio_rl64(Ptr<AVIOContext> s);

    /// <summary>
    /// Functions for reading from AVIOContext.
    /// Note: returns 0 if EOF, so you cannot use it if EOF handling is
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint avio_rb16(Ptr<AVIOContext> s);

    /// <summary>
    /// Functions for reading from AVIOContext.
    /// Note: returns 0 if EOF, so you cannot use it if EOF handling is
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint avio_rb24(Ptr<AVIOContext> s);

    /// <summary>
    /// Functions for reading from AVIOContext.
    /// Note: returns 0 if EOF, so you cannot use it if EOF handling is
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint avio_rb32(Ptr<AVIOContext> s);

    /// <summary>
    /// Functions for reading from AVIOContext.
    /// Note: returns 0 if EOF, so you cannot use it if EOF handling is
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ulong avio_rb64(Ptr<AVIOContext> s);

    /// <summary>
    /// Read a string from pb into buf. The reading will terminate when either
    /// a NULL character was encountered, maxlen bytes have been read, or nothing
    /// more can be read from pb. The result is guaranteed to be NULL-terminated, it
    /// will be truncated if buf is too small.
    /// Note that the string is not interpreted or validated in any way, it
    /// might get truncated in the middle of a sequence for multi-byte encodings.
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="maxLen"></param>
    /// <param name="buffer"></param>
    /// <param name="bufferLen"></param>
    /// <returns>number of bytes read (is always &lt;= maxlen).
    /// If reading ends on EOF or error, the return value will be one more than
    /// bytes actually read.
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int avio_get_str(Ptr<AVIOContext> pb, int maxLen, Ptr<byte> buffer, int bufferLen);

    /// <summary>
    /// Read a UTF-16 string from pb and convert it to UTF-8.
    /// The reading will terminate when either a null or invalid character was
    /// encountered or maxlen bytes have been read.
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="maxLen"></param>
    /// <param name="buffer"></param>
    /// <param name="bufferLen"></param>
    /// <returns>number of bytes read (is always &lt;= maxlen)</returns>
    [DllImport(LibraryName)]
    public static extern int avio_get_str16le(Ptr<AVIOContext> pb, int maxLen, Ptr<byte> buffer, int bufferLen);

    /// <summary>
    /// Read a UTF-16 string from pb and convert it to UTF-8.
    /// The reading will terminate when either a null or invalid character was
    /// encountered or maxlen bytes have been read.
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="maxLen"></param>
    /// <param name="buffer"></param>
    /// <param name="bufferLen"></param>
    /// <returns>number of bytes read (is always &lt;= maxlen)</returns>
    [DllImport(LibraryName)]
    public static extern int avio_get_str16be(Ptr<AVIOContext> pb, int maxLen, Ptr<byte> buffer, int bufferLen);

    /// <summary>
    /// Create and initialize a AVIOContext for accessing the
    /// resource indicated by url.
    /// When the resource indicated by url has been opened in
    /// read+write mode, the AVIOContext can be used only for writing.
    /// </summary>
    /// <param name="s">Used to return the pointer to the created AVIOContext. In case of failure the pointed to value is set to NULL.</param>
    /// <param name="url">resource to access</param>
    /// <param name="flags">flags which control how the resource indicated by url is to be opened</param>
    /// <returns>>= 0 in case of success, a negative value corresponding to an AVERROR code in case of failure</returns>
    [DllImport(LibraryName)]
    public static extern int avio_open(out Ptr<AVIOContext> s, [MarshalAs(UnmanagedType.LPUTF8Str)] string url,
        AVIOFlags flags);

    /// <summary>
    /// Create and initialize a AVIOContext for accessing the resource indicated by url.
    /// When the resource indicated by url has been opened in
    /// read+write mode, the AVIOContext can be used only for writing.
    /// </summary>
    /// <param name="s">Used to return the pointer to the created AVIOContext.
    /// In case of failure the pointed to value is set to NULL.</param>
    /// <param name="url">resource to access</param>
    /// <param name="flags">flags which control how the resource indicated by url is to be opened</param>
    /// <param name="intCb">an interrupt callback to be used at the protocols level</param>
    /// <param name="options">A dictionary filled with protocol-private options. On return
    /// this parameter will be destroyed and replaced with a dict containing options
    /// that were not found. May be NULL.</param>
    /// <returns>>= 0 in case of success, a negative value corresponding to an AVERROR code in case of failure</returns>
    [DllImport(LibraryName)]
    public static extern int avio_open2(out Ptr<AVIOContext> s, [MarshalAs(UnmanagedType.LPUTF8Str)] string url,
        AVIOFlags flags, ConstPtr<AVIOInterruptCB> intCb, ref Ptr<AVDictionary> options);

    /// <summary>
    /// Close the resource accessed by the AVIOContext s and free it.
    /// This function can only be used if s was opened by avio_open().
    ///
    /// The internal buffer is automatically flushed before closing the resource.
    /// </summary>
    /// <param name="s"></param>
    /// <returns>0 on success, an AVERROR &lt; 0 on error.</returns>
    [DllImport(LibraryName)]
    public static extern int avio_close(Ptr<AVIOContext> s);

    /// <summary>
    /// Close the resource accessed by the AVIOContext *s, free it
    /// and set the pointer pointing to it to NULL.
    /// This function can only be used if s was opened by avio_open().
    ///
    /// The internal buffer is automatically flushed before closing the resource.
    /// </summary>
    /// <param name="s"></param>
    /// <returns>0 on success, an AVERROR &lt; 0 on error.</returns>
    [DllImport(LibraryName)]
    public static extern int avio_closep(ref Ptr<AVIOContext> s);

    /// <summary>
    /// Open a write only memory stream.
    /// </summary>
    /// <param name="s">new IO context</param>
    /// <returns>zero if no error.</returns>
    [DllImport(LibraryName)]
    public static extern int avio_open_dyn_buf(out Ptr<AVIOContext> s);

    /// <summary>
    /// Return the written size and a pointer to the buffer.
    /// The AVIOContext stream is left intact.
    /// The buffer must NOT be freed.
    /// No padding is added to the buffer.
    /// </summary>
    /// <param name="s">IO context</param>
    /// <param name="buffer">pointer to a byte buffer</param>
    /// <returns>the length of the byte buffer</returns>
    [DllImport(LibraryName)]
    public static extern int avio_get_dyn_buf(Ptr<AVIOContext> s, out Ptr<byte> buffer);

    /// <summary>
    /// Return the written size and a pointer to the buffer. The buffer
    /// must be freed with av_free().
    ///
    /// Padding of AV_INPUT_BUFFER_PADDING_SIZE is added to the buffer.
    /// </summary>
    /// <param name="s">IO context</param>
    /// <param name="buffer">pointer to a byte buffer</param>
    /// <returns>the length of the byte buffer</returns>
    [DllImport(LibraryName)]
    public static extern int avio_close_dyn_buf(Ptr<AVIOContext> s, out Ptr<byte> buffer);

    /// <summary>
    /// Iterate through names of available protocols.
    /// </summary>
    /// <param name="opaque">A private pointer representing current protocol.
    /// It must be a pointer to NULL on first iteration and will
    /// be updated by successive calls to avio_enum_protocols.</param>
    /// <param name="output">If set to 1, iterate over output protocols, otherwise over input protocols.</param>
    /// <returns>A static string containing the name of current protocol or NULL</returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr avio_enum_protocols(ref IntPtr opaque, int output);

    /// <summary>
    /// Get AVClass by names of available protocols.
    /// </summary>
    /// <param name="name"></param>
    /// <returns>A AVClass of input protocol name or NULL</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVClass> avio_protocol_get_class([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// Pause and resume playing - only meaningful if using a network streaming
    /// protocol (e.g. MMS).
    /// </summary>
    /// <param name="h">IO context from which to call the read_pause function pointer</param>
    /// <param name="pause">1 for pause, 0 for resume</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int avio_pause(Ptr<AVIOContext> h, int pause);

    /// <summary>
    /// Seek to a given timestamp relative to some component stream.
    /// Only meaningful if using a network streaming protocol (e.g. MMS.).
    /// </summary>
    /// <param name="h">IO context from which to call the seek function pointers</param>
    /// <param name="streamIndex">The stream index that the timestamp is relative to.
    /// If stream_index is (-1) the timestamp should be in AV_TIME_BASE
    /// units from the beginning of the presentation.
    /// If a stream_index >= 0 is used and the protocol does not support
    /// seeking based on component streams, the call will fail.
    /// </param>
    /// <param name="timestamp">timestamp in AVStream.time_base units
    /// or if there is no stream specified then in AV_TIME_BASE units.</param>
    /// <param name="flags">Optional combination of AVSEEK_FLAG_BACKWARD, AVSEEK_FLAG_BYTE
    /// and AVSEEK_FLAG_ANY. The protocol may silently ignore
    /// AVSEEK_FLAG_BACKWARD and AVSEEK_FLAG_ANY, but AVSEEK_FLAG_BYTE will
    /// fail if used and not supported.</param>
    /// <returns>>= 0 on success</returns>
    [DllImport(LibraryName)]
    public static extern long avio_seek_time(Ptr<AVIOContext> h, int streamIndex, long timestamp, AVIOSeekFlags flags);

    /// <summary>
    /// Read contents of h into print buffer, up to max_size bytes, or up to EOF.
    /// </summary>
    /// <param name="h"></param>
    /// <param name="pb"></param>
    /// <param name="maxSize"></param>
    /// <returns>0 for success (max_size bytes read or EOF reached), negative error
    /// code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int avio_read_to_bprint(Ptr<AVIOContext> h, Ptr<AVBPrint> pb, nuint maxSize);

    /// <summary>
    /// Accept and allocate a client context on a server context.
    /// </summary>
    /// <param name="s">the server context</param>
    /// <param name="c">the client context, must be unallocated</param>
    /// <returns>>= 0 on success or a negative value corresponding to an AVERROR on failure</returns>
    [DllImport(LibraryName)]
    public static extern int avio_accept(Ptr<AVIOContext> s, out Ptr<AVIOContext> c);

    /// <summary>
    /// Perform one step of the protocol handshake to accept a new client.
    /// This function must be called on a client returned by avio_accept() before
    /// using it as a read/write context.
    ///
    /// It is separate from avio_accept() because it may block.
    /// A step of the handshake is defined by places where the application may
    /// decide to change the proceedings.
    ///
    /// For example, on a protocol with a request header and a reply header, each
    /// one can constitute a step because the application may use the parameters
    /// from the request to change parameters in the reply; or each individual
    /// chunk of the request can constitute a step.
    /// If the handshake is already finished, avio_handshake() does nothing and
    /// returns 0 immediately.
    /// </summary>
    /// <param name="c">the client context to perform the handshake on</param>
    /// <returns>
    /// 0   on a complete and successful handshake
    /// > 0 if the handshake progressed, but is not complete
    /// &lt; 0 for an AVERROR code
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int avio_handshake(Ptr<AVIOContext> c);
}
