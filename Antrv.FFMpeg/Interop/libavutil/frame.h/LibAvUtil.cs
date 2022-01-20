namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    public const int AV_NUM_DATA_POINTERS = 8;

    /// <summary>
    /// Get the name of a colorspace.
    /// Obsolete: use <see cref="av_color_space_name"/>
    /// </summary>
    /// <param name="colorSpace"></param>
    /// <returns>a static string identifying the colorspace; can be NULL.</returns>
    [Obsolete("Use " + nameof(av_color_space_name))]
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_get_colorspace_name(AVColorSpace colorSpace);

    /// <summary>
    /// Allocate an AVFrame and set its fields to default values. The resulting
    /// struct must be freed using av_frame_free().
    ///
    /// Note: this only allocates the AVFrame itself, not the data buffers. Those
    /// must be allocated through other means, e.g. with av_frame_get_buffer() or manually.
    /// </summary>
    /// <returns>An AVFrame filled with default values or NULL on failure.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVFrame> av_frame_alloc();

    /// <summary>
    /// Free the frame and any dynamically allocated objects in it,
    /// e.g. extended_data. If the frame is reference counted, it will be
    /// unreferenced first.
    /// </summary>
    /// <param name="frame"></param>
    [DllImport(LibraryName)]
    public static extern void av_frame_free(ref Ptr<AVFrame> frame);

    /// <summary>
    /// Set up a new reference to the data described by the source frame.
    ///
    /// Copy frame properties from src to dst and create a new reference for each AVBufferRef from src.
    /// If src is not reference counted, new buffers are allocated and the data is copied.
    ///
    /// dst MUST have been either unreferenced with av_frame_unref(dst),
    /// or newly allocated with av_frame_alloc() before calling this
    /// function, or undefined behavior will occur.
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="src"></param>
    /// <returns>0 on success, a negative AVERROR on error</returns>
    [DllImport(LibraryName)]
    public static extern int av_frame_ref(Ptr<AVFrame> dst, ConstPtr<AVFrame> src);

    /// <summary>
    /// Create a new frame that references the same data as src.
    /// This is a shortcut for av_frame_alloc()+av_frame_ref().
    /// </summary>
    /// <param name="src"></param>
    /// <returns>newly created AVFrame on success, NULL on error.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVFrame> av_frame_clone(ConstPtr<AVFrame> src);

    /// <summary>
    /// Unreference all the buffers referenced by frame and reset the frame fields.
    /// </summary>
    /// <param name="frame"></param>
    [DllImport(LibraryName)]
    public static extern void av_frame_unref(Ptr<AVFrame> frame);

    /// <summary>
    /// Move everything contained in src to dst and reset src.
    ///
    /// dst is not unreferenced, but directly overwritten without reading
    /// or deallocating its contents. Call av_frame_unref(dst) manually
    /// before calling this function to ensure that no memory is leaked.
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="src"></param>
    [DllImport(LibraryName)]
    public static extern void av_frame_move_ref(Ptr<AVFrame> dst, Ptr<AVFrame> src);

    /// <summary>
    /// Allocate new buffer(s) for audio or video data.
    ///
    /// The following fields must be set on frame before calling this function:
    /// - format (pixel format for video, sample format for audio)
    /// - width and height for video
    /// - nb_samples and channel_layout for audio
    ///
    /// This function will fill AVFrame.data and AVFrame.buf arrays and, if
    /// necessary, allocate and fill AVFrame.extended_data and AVFrame.extended_buf.
    /// For planar formats, one buffer will be allocated for each plane.
    ///
    /// if frame already has been allocated, calling this function will
    /// leak memory. In addition, undefined behavior can occur in certain cases.
    /// </summary>
    /// <param name="frame">frame in which to store the new buffers.</param>
    /// <param name="align">Required buffer size alignment. If equal to 0, alignment will be
    /// chosen automatically for the current CPU. It is highly
    /// recommended to pass 0 here unless you know what you are doing.</param>
    /// <returns>0 on success, a negative AVERROR on error.</returns>
    [DllImport(LibraryName)]
    public static extern int av_frame_get_buffer(Ptr<AVFrame> frame, int align);

    /// <summary>
    /// Check if the frame data is writable.
    /// </summary>
    /// <param name="frame"></param>
    /// <returns>
    /// A positive value if the frame data is writable (which is true if and
    /// only if each of the underlying buffers has only one reference, namely the one
    /// stored in this frame). Return 0 otherwise.
    ///
    /// If 1 is returned the answer is valid until av_buffer_ref() is called on any
    /// of the underlying AVBufferRefs (e.g. through av_frame_ref() or directly).
    /// @see av_frame_make_writable(), av_buffer_is_writable()
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int av_frame_is_writable(Ptr<AVFrame> frame);

    /// <summary>
    /// Ensure that the frame data is writable, avoiding data copy if possible.
    ///
    /// Do nothing if the frame is writable, allocate new buffers and copy the data if it is not.
    /// @see av_frame_is_writable(), av_buffer_is_writable(), av_buffer_make_writable()
    /// </summary>
    /// <param name="frame"></param>
    /// <returns>0 on success, a negative AVERROR on error.</returns>
    [DllImport(LibraryName)]
    public static extern int av_frame_make_writable(Ptr<AVFrame> frame);

    /// <summary>
    /// Copy the frame data from src to dst.
    ///
    /// This function does not allocate anything, dst must be already initialized and
    /// allocated with the same parameters as src.
    ///
    /// This function only copies the frame data (i.e. the contents of the data /
    /// extended data arrays), not any other properties.
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="src"></param>
    /// <returns>&gt;= 0 on success, a negative AVERROR on error.</returns>
    [DllImport(LibraryName)]
    public static extern int av_frame_copy(Ptr<AVFrame> dst, ConstPtr<AVFrame> src);

    /// <summary>
    /// Copy only "metadata" fields from src to dst.
    ///
    /// Metadata for the purpose of this function are those fields that do not affect
    /// the data layout in the buffers.  E.g. pts, sample rate (for audio) or sample
    /// aspect ratio (for video), but not width/height or channel layout.
    /// Side data is also copied.
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_frame_copy_props(Ptr<AVFrame> dst, ConstPtr<AVFrame> src);

    /// <summary>
    /// Get the buffer reference a given data plane is stored in.
    /// </summary>
    /// <param name="frame"></param>
    /// <param name="plane">index of the data plane of interest in frame->extended_data.</param>
    /// <returns>the buffer reference that contains the plane or NULL if the input frame is not valid.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVBufferRef> av_frame_get_plane_buffer(Ptr<AVFrame> frame, int plane);

    /// <summary>
    /// Add a new side data to a frame.
    /// </summary>
    /// <param name="frame">a frame to which the side data should be added</param>
    /// <param name="type">type of the added side data</param>
    /// <param name="size">size of the side data</param>
    /// <returns>newly added side data on success, NULL on error</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVFrameSideData> av_frame_new_side_data(Ptr<AVFrame> frame, AVFrameSideDataType type,
        nuint size);

    /// <summary>
    /// Add a new side data to a frame from an existing AVBufferRef
    /// </summary>
    /// <param name="frame">a frame to which the side data should be added</param>
    /// <param name="type">the type of the added side data</param>
    /// <param name="buf">an AVBufferRef to add as side data. The ownership of the reference is transferred to the frame.</param>
    /// <returns>newly added side data on success, NULL on error. On failure the frame is unchanged and the AVBufferRef remains owned by
    /// the caller.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVFrameSideData> av_frame_new_side_data_from_buf(Ptr<AVFrame> frame,
        AVFrameSideDataType type, Ptr<AVBufferRef> buf);

    /// <summary>
    /// Returns a pointer to the side data of a given type on success, NULL if there
    /// is no side data with such type in this frame.
    /// </summary>
    /// <param name="frame"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVFrameSideData> av_frame_get_side_data(ConstPtr<AVFrame> frame, AVFrameSideDataType type);

    /// <summary>
    /// Remove and free all side data instances of the given type.
    /// </summary>
    /// <param name="frame"></param>
    /// <param name="type"></param>
    [DllImport(LibraryName)]
    public static extern void av_frame_remove_side_data(Ptr<AVFrame> frame, AVFrameSideDataType type);

    /// <summary>
    /// Crop the given video AVFrame according to its crop_left/crop_top/crop_right/
    /// crop_bottom fields. If cropping is successful, the function will adjust the
    /// data pointers and the width/height fields, and set the crop fields to 0.
    ///
    /// In all cases, the cropping boundaries will be rounded to the inherent
    /// alignment of the pixel format. In some cases, such as for opaque hwaccel
    /// formats, the left/top cropping is ignored. The crop fields are set to 0 even
    /// if the cropping was rounded or ignored.
    /// </summary>
    /// <param name="frame">the frame which should be cropped</param>
    /// <param name="flags">Some combination of AV_FRAME_CROP_* flags, or 0.</param>
    /// <returns>&gt;= 0 on success, a negative AVERROR on error. If the cropping fields were
    /// invalid, AVERROR(ERANGE) is returned, and nothing is changed.</returns>
    [DllImport(LibraryName)]
    public static extern int av_frame_apply_cropping(Ptr<AVFrame> frame, AVFrameCroppingFlags flags);

    /// <summary>
    /// Returns a string identifying the side data type.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_frame_side_data_name(AVFrameSideDataType type);
}
