namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    /// <summary>
    /// a bitstream filter with the specified name or NULL if no such bitstream filter exists.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVBitStreamFilter> av_bsf_get_by_name(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// Iterate over all registered bitstream filters.
    /// </summary>
    /// <param name="opaque">a pointer where libavcodec will store the iteration state.
    /// Must point to NULL to start the iteration.</param>
    /// <returns>the next registered bitstream filter or NULL when the iteration is finished</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVBitStreamFilter> av_bsf_iterate(ref IntPtr opaque);

    /// <summary>
    /// Allocate a context for a given bitstream filter. The caller must fill in the
    /// context parameters as described in the documentation and then call
    /// av_bsf_init() before sending any data to the filter.
    /// </summary>
    /// <param name="filter">the filter for which to allocate an instance.</param>
    /// <param name="ctx">a pointer into which the pointer to the newly-allocated context
    /// will be written. It must be freed with av_bsf_free() after the
    /// filtering is done.</param>
    /// <returns>0 on success, a negative AVERROR code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_bsf_alloc(ConstPtr<AVBitStreamFilter> filter, out Ptr<AVBSFContext> ctx);

    /// <summary>
    /// Prepare the filter for use, after all the parameters and options have been set.
    /// </summary>
    /// <param name="ctx"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_bsf_init(Ptr<AVBSFContext> ctx);

    /// <summary>
    /// Submit a packet for filtering.
    ///
    /// After sending each packet, the filter must be completely drained by calling
    /// av_bsf_receive_packet() repeatedly until it returns AVERROR(EAGAIN) or AVERROR_EOF.
    /// </summary>
    /// <param name="ctx"></param>
    /// <param name="pkt">the packet to filter. The bitstream filter will take ownership of
    /// the packet and reset the contents of pkt. pkt is not touched if an error occurs.
    /// If pkt is empty (i.e. NULL, or pkt->data is NULL and pkt->side_data_elems zero),
    /// it signals the end of the stream (i.e. no more non-empty packets will be sent;
    /// sending more empty packets does nothing) and will cause the filter to output
    /// any packets it may have buffered internally.</param>
    /// <returns>
    /// 0 on success. AVERROR(EAGAIN) if packets need to be retrieved from the
    /// filter (using av_bsf_receive_packet()) before new input can be consumed. Another
    /// negative AVERROR value if an error occurs.
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int av_bsf_send_packet(Ptr<AVBSFContext> ctx, Ptr<AVPacket> pkt);

    /// <summary>
    /// Retrieve a filtered packet.
    ///
    /// one input packet may result in several output packets, so after sending
    /// a packet with av_bsf_send_packet(), this function needs to be called
    /// repeatedly until it stops returning 0. It is also possible for a filter to
    /// output fewer packets than were sent to it, so this function may return
    /// AVERROR(EAGAIN) immediately after a successful av_bsf_send_packet() call.
    /// </summary>
    /// <param name="ctx"></param>
    /// <param name="pkt">this struct will be filled with the contents of the filtered
    /// packet. It is owned by the caller and must be freed using
    /// av_packet_unref() when it is no longer needed.
    /// This parameter should be "clean" (i.e. freshly allocated
    /// with av_packet_alloc() or unreffed with av_packet_unref())
    /// when this function is called. If this function returns
    /// successfully, the contents of pkt will be completely
    /// overwritten by the returned data. On failure, pkt is not
    /// touched.</param>
    /// <returns>
    /// 0 on success. AVERROR(EAGAIN) if more packets need to be sent to the
    /// filter (using av_bsf_send_packet()) to get more output. AVERROR_EOF if there
    /// will be no further output from the filter. Another negative AVERROR value if
    /// an error occurs.
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int av_bsf_receive_packet(Ptr<AVBSFContext> ctx, Ptr<AVPacket> pkt);

    /// <summary>
    /// Reset the internal bitstream filter state. Should be called e.g. when seeking.
    /// </summary>
    /// <param name="ctx"></param>
    [DllImport(LibraryName)]
    public static extern void av_bsf_flush(Ptr<AVBSFContext> ctx);

    /// <summary>
    /// Free a bitstream filter context and everything associated with it; write NULL
    /// into the supplied pointer.
    /// </summary>
    /// <param name="ctx"></param>
    [DllImport(LibraryName)]
    public static extern void av_bsf_free(ref Ptr<AVBSFContext> ctx);

    /// <summary>
    /// Get the AVClass for AVBSFContext. It can be used in combination with
    /// AV_OPT_SEARCH_FAKE_OBJ for examining options.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVClass> av_bsf_get_class();

    /// <summary>
    /// Allocate empty list of bitstream filters.
    /// The list must be later freed by av_bsf_list_free()
    /// or finalized by av_bsf_list_finalize().
    /// </summary>
    /// <returns>Pointer to @ref AVBSFList on success, NULL in case of failure</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVBSFList> av_bsf_list_alloc();

    /// <summary>
    /// Free list of bitstream filters.
    /// </summary>
    /// <param name="lst">Pointer to pointer returned by av_bsf_list_alloc()</param>
    [DllImport(LibraryName)]
    public static extern void av_bsf_list_free(ref Ptr<AVBSFList> lst);

    /// <summary>
    /// Append bitstream filter to the list of bitstream filters.
    /// </summary>
    /// <param name="lst">List to append to</param>
    /// <param name="bsf">Filter context to be appended</param>
    /// <returns>>=0 on success, negative AVERROR in case of failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_bsf_list_append(Ptr<AVBSFList> lst, Ptr<AVBSFContext> bsf);

    /// <summary>
    /// Construct new bitstream filter context given it's name and options
    /// and append it to the list of bitstream filters.
    /// </summary>
    /// <param name="lst">List to append to</param>
    /// <param name="bsfName">Name of the bitstream filter</param>
    /// <param name="options">Options for the bitstream filter, can be set to NULL</param>
    /// <returns>>=0 on success, negative AVERROR in case of failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_bsf_list_append2(Ptr<AVBSFList> lst,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string bsfName, ref Ptr<AVDictionary> options);

    /// <summary>
    /// Finalize list of bitstream filters.
    ///
    /// This function will transform @ref AVBSFList to single @ref AVBSFContext,
    /// so the whole chain of bitstream filters can be treated as single filter
    /// freshly allocated by av_bsf_alloc().
    /// If the call is successful, @ref AVBSFList structure is freed and lst
    /// will be set to NULL. In case of failure, caller is responsible for
    /// freeing the structure by av_bsf_list_free()
    /// </summary>
    /// <param name="lst">Filter list structure to be transformed</param>
    /// <param name="bsf">Pointer to be set to newly created @ref AVBSFContext structure
    /// representing the chain of bitstream filters</param>
    /// <returns>>=0 on success, negative AVERROR in case of failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_bsf_list_finalize(ref Ptr<AVBSFList> lst, out Ptr<AVBSFContext> bsf);

    /// <summary>
    /// Parse string describing list of bitstream filters and create single
    /// @ref AVBSFContext describing the whole chain of bitstream filters.
    /// Resulting @ref AVBSFContext can be treated as any other @ref AVBSFContext freshly
    /// allocated by av_bsf_alloc().
    /// </summary>
    /// <param name="str">String describing chain of bitstream filters in format
    /// `bsf1[=opt1=val1:opt2=val2][,bsf2]`</param>
    /// <param name="bsf">Pointer to be set to newly created @ref AVBSFContext structure
    /// representing the chain of bitstream filters</param>
    /// <returns>>=0 on success, negative AVERROR in case of failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_bsf_list_parse_str([MarshalAs(UnmanagedType.LPUTF8Str)] string str,
        out Ptr<AVBSFContext> bsf);

    /// <summary>
    /// Get null/pass-through bitstream filter.
    /// </summary>
    /// <param name="bsf">Pointer to be set to new instance of pass-through bitstream filter</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_bsf_get_null_filter(out Ptr<AVBSFContext> bsf);
}
