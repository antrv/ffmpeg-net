namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    /// <summary>
    /// Allocate an AVPacket and set its fields to default values. The resulting
    /// struct must be freed using av_packet_free().
    /// </summary>
    /// <returns>An AVPacket filled with default values or NULL on failure.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVPacket> av_packet_alloc();

    /// <summary>
    /// Create a new packet that references the same data as src.
    /// This is a shortcut for av_packet_alloc()+av_packet_ref().
    /// </summary>
    /// <param name="src"></param>
    /// <returns>newly created AVPacket on success, NULL on error.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVPacket> av_packet_clone(ConstPtr<AVPacket> src);

    /// <summary>
    /// Free the packet, if the packet is reference counted, it will be
    /// unreferenced first.
    /// </summary>
    /// <param name="pkt">packet to be freed. The pointer will be set to NULL.</param>
    [DllImport(LibraryName)]
    public static extern void av_packet_free(ref Ptr<AVPacket> pkt);

    /// <summary>
    /// Allocate the payload of a packet and initialize its fields with
    /// default values.
    /// </summary>
    /// <param name="pkt">packet</param>
    /// <param name="size">wanted payload size</param>
    /// <returns>0 if OK, AVERROR_xxx otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_new_packet(Ptr<AVPacket> pkt, int size);

    /// <summary>
    /// Reduce packet size, correctly zeroing padding
    /// </summary>
    /// <param name="pkt">packet</param>
    /// <param name="size">new size</param>
    [DllImport(LibraryName)]
    public static extern void av_shrink_packet(Ptr<AVPacket> pkt, int size);

    /// <summary>
    /// Increase packet size, correctly zeroing padding
    /// </summary>
    /// <param name="pkt">packet</param>
    /// <param name="size">number of bytes by which to increase the size of the packet</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_grow_packet(Ptr<AVPacket> pkt, int size);

    /// <summary>
    /// Initialize a reference-counted packet from av_malloc()ed data.
    /// </summary>
    /// <param name="pkt">packet to be initialized. This function will set the data, size,
    /// and buf fields, all others are left untouched.</param>
    /// <param name="data">Data allocated by av_malloc() to be used as packet data. If this
    /// function returns successfully, the data is owned by the underlying AVBuffer.
    /// The caller may not access the data through other means.</param>
    /// <param name="size">size of data in bytes, without the padding. I.e. the full buffer
    /// size is assumed to be size + AV_INPUT_BUFFER_PADDING_SIZE.</param>
    /// <returns>0 on success, a negative AVERROR on error</returns>
    [DllImport(LibraryName)]
    public static extern int av_packet_from_data(Ptr<AVPacket> pkt, Ptr<byte> data, int size);

    /// <summary>
    /// Allocate new information of a packet.
    /// </summary>
    /// <param name="pkt">packet</param>
    /// <param name="type">side information type</param>
    /// <param name="size">side information size</param>
    /// <returns>pointer to fresh allocated data or NULL otherwise</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<byte> av_packet_new_side_data(Ptr<AVPacket> pkt, AVPacketSideDataType type, nuint size);

    /// <summary>
    /// Wrap an existing array as a packet side data.
    /// </summary>
    /// <param name="pkt">packet</param>
    /// <param name="type">side information type</param>
    /// <param name="data">the side data array. It must be allocated with the av_malloc()
    /// family of functions. The ownership of the data is transferred to pkt.</param>
    /// <param name="size">side information size</param>
    /// <returns>a non-negative number on success, a negative AVERROR code on
    /// failure. On failure, the packet is unchanged and the data remains owned by the caller.</returns>
    [DllImport(LibraryName)]
    public static extern int av_packet_add_side_data(Ptr<AVPacket> pkt, AVPacketSideDataType type, Ptr<byte> data,
        nuint size);

    /// <summary>
    /// Shrink the already allocated side data buffer.
    /// </summary>
    /// <param name="pkt">packet</param>
    /// <param name="type">side information type</param>
    /// <param name="size">new side information size</param>
    /// <returns>0 on success, &lt; 0 on failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_packet_shrink_side_data(Ptr<AVPacket> pkt, AVPacketSideDataType type, nuint size);

    /// <summary>
    /// Get side information from packet.
    /// </summary>
    /// <param name="pkt">packet</param>
    /// <param name="type">desired side information type</param>
    /// <param name="size">If supplied, *size will be set to the size of the side data
    /// or to zero if the desired side data is not present.</param>
    /// <returns>pointer to data if present or NULL otherwise</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<byte> av_packet_get_side_data(ConstPtr<AVPacket> pkt, AVPacketSideDataType type,
        out nuint size);

    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_packet_side_data_name(AVPacketSideDataType type);

    /// <summary>
    /// Pack a dictionary for use in side_data.
    /// </summary>
    /// <param name="dict">The dictionary to pack.</param>
    /// <param name="size">pointer to store the size of the returned data</param>
    /// <returns>pointer to data if successful, NULL otherwise</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<byte> av_packet_pack_dictionary(Ptr<AVDictionary> dict, out nuint size);

    /// <summary>
    /// Unpack a dictionary from side_data.
    /// </summary>
    /// <param name="data">data from side_data</param>
    /// <param name="size">size of the data</param>
    /// <param name="dict">the metadata storage dictionary</param>
    /// <returns>0 on success, negative on failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_packet_unpack_dictionary(ConstPtr<byte> data, nuint size, out Ptr<AVDictionary> dict);

    /// <summary>
    /// Convenience function to free all the side data stored. All the other fields stay untouched.
    /// </summary>
    /// <param name="pkt"></param>
    [DllImport(LibraryName)]
    public static extern void av_packet_free_side_data(Ptr<AVPacket> pkt);

    /// <summary>
    /// Setup a new reference to the data described by a given packet.
    ///
    /// If src is reference-counted, setup dst as a new reference to the
    /// buffer in src. Otherwise allocate a new buffer in dst and copy the
    /// data from src into it.
    ///
    /// All the other fields are copied from src.
    /// </summary>
    /// <param name="dst">Destination packet. Will be completely overwritten.</param>
    /// <param name="src">Source packet</param>
    /// <returns>0 on success, a negative AVERROR on error. On error,
    /// dst will be blank (as if returned by av_packet_alloc()).</returns>
    [DllImport(LibraryName)]
    public static extern int av_packet_ref(Ptr<AVPacket> dst, ConstPtr<AVPacket> src);

    /// <summary>
    /// Wipe the packet.
    ///
    /// Unreference the buffer referenced by the packet and reset the
    /// remaining packet fields to their default values.
    /// </summary>
    /// <param name="pkt"></param>
    [DllImport(LibraryName)]
    public static extern void av_packet_unref(Ptr<AVPacket> pkt);

    /// <summary>
    /// Move every field in src to dst and reset src.
    /// </summary>
    /// <param name="dst">Destination packet</param>
    /// <param name="src">Source packet, will be reset</param>
    [DllImport(LibraryName)]
    public static extern void av_packet_move_ref(Ptr<AVPacket> dst, Ptr<AVPacket> src);

    /// <summary>
    /// Copy only "properties" fields from src to dst.
    ///
    /// Properties for the purpose of this function are all the fields
    /// beside those related to the packet data (buf, data, size)
    /// </summary>
    /// <param name="dst">Destination packet</param>
    /// <param name="src">Source packet</param>
    /// <returns>0 on success AVERROR on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int av_packet_copy_props(Ptr<AVPacket> dst, ConstPtr<AVPacket> src);

    /// <summary>
    /// Ensure the data described by a given packet is reference counted.
    ///
    /// This function does not ensure that the reference will be writable.
    /// Use av_packet_make_writable instead for that purpose.
    /// </summary>
    /// <param name="pkt">packet whose data should be made reference counted.</param>
    /// <returns>0 on success, a negative AVERROR on error. On failure, the
    /// packet is unchanged.</returns>
    [DllImport(LibraryName)]
    public static extern int av_packet_make_refcounted(Ptr<AVPacket> pkt);

    /// <summary>
    /// Create a writable reference for the data described by a given packet,
    /// avoiding data copy if possible.
    /// </summary>
    /// <param name="pkt">Packet whose data should be made writable.</param>
    /// <returns>0 on success, a negative AVERROR on failure. On failure, the packet is unchanged.</returns>
    [DllImport(LibraryName)]
    public static extern int av_packet_make_writable(Ptr<AVPacket> pkt);

    /// <summary>
    /// Convert valid timing fields (timestamps / durations) in a packet from one
    /// timebase to another. Timestamps with unknown values (AV_NOPTS_VALUE) will be
    /// ignored.
    /// </summary>
    /// <param name="pkt">packet on which the conversion will be performed</param>
    /// <param name="sourceTimeBase">source timebase, in which the timing fields in pkt are expressed</param>
    /// <param name="destinationTimeBase">destination timebase, to which the timing fields will be converted</param>
    [DllImport(LibraryName)]
    public static extern void av_packet_rescale_ts(Ptr<AVPacket> pkt, AVRational sourceTimeBase,
        AVRational destinationTimeBase);
}
