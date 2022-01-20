namespace Antrv.FFMpeg.Interop;

public static partial class LibAvUtil
{
    /// <summary>
    /// Look up an AVHWDeviceType by name.
    /// </summary>
    /// <param name="name">String name of the device type (case-insensitive).</param>
    /// <returns>The type from enum AVHWDeviceType, or AV_HWDEVICE_TYPE_NONE if not found.</returns>
    [DllImport(LibraryName)]
    public static extern AVHWDeviceType av_hwdevice_find_type_by_name(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// Get the string name of an AVHWDeviceType.
    /// </summary>
    /// <param name="type">Type from enum AVHWDeviceType.</param>
    /// <returns>Pointer to a static string containing the name, or NULL if the type is not valid.</returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_hwdevice_get_type_name(AVHWDeviceType type);

    /// <summary>
    /// Iterate over supported device types.
    /// </summary>
    /// <param name="prev">AV_HWDEVICE_TYPE_NONE initially, then the previous type
    /// returned by this function in subsequent iterations.</param>
    /// <returns>The next usable device type from enum AVHWDeviceType, or
    /// AV_HWDEVICE_TYPE_NONE if there are no more.</returns>
    [DllImport(LibraryName)]
    public static extern AVHWDeviceType av_hwdevice_iterate_types(AVHWDeviceType prev);

    /// <summary>
    /// Allocate an AVHWDeviceContext for a given hardware type.
    /// </summary>
    /// <param name="type">the type of the hardware device to allocate.</param>
    /// <returns>a reference to the newly created AVHWDeviceContext on success or NULL on failure.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVBufferRef> av_hwdevice_ctx_alloc(AVHWDeviceType type);

    /// <summary>
    /// Finalize the device context before use. This function must be called after
    /// the context is filled with all the required information and before it is
    /// used in any way.
    /// </summary>
    /// <param name="bufferRef">a reference to the AVHWDeviceContext</param>
    /// <returns>0 on success, a negative AVERROR code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_hwdevice_ctx_init(Ptr<AVBufferRef> bufferRef);

    /// <summary>
    /// Open a device of the specified type and create an AVHWDeviceContext for it.
    ///
    /// This is a convenience function intended to cover the simple cases. Callers
    /// who need to fine-tune device creation/management should open the device
    /// manually and then wrap it in an AVHWDeviceContext using
    /// av_hwdevice_ctx_alloc()/av_hwdevice_ctx_init().
    ///
    /// The returned context is already initialized and ready for use, the caller
    /// should not call av_hwdevice_ctx_init() on it. The user_opaque/free fields of
    /// the created AVHWDeviceContext are set by this function and should not be
    /// touched by the caller.
    /// </summary>
    /// <param name="deviceCtx">On success, a reference to the newly-created device context
    /// will be written here. The reference is owned by the caller
    /// and must be released with av_buffer_unref() when no longer
    /// needed. On failure, NULL will be written to this pointer.</param>
    /// <param name="type">The type of the device to create.</param>
    /// <param name="device">A type-specific string identifying the device to open.</param>
    /// <param name="options">A dictionary of additional (type-specific) options to use in
    /// opening the device. The dictionary remains owned by the caller.</param>
    /// <param name="flags">currently unused</param>
    /// <returns>0 on success, a negative AVERROR code on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int av_hwdevice_ctx_create(out Ptr<AVBufferRef> deviceCtx, AVHWDeviceType type,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string device, Ptr<AVDictionary> options, int flags);

    /// <summary>
    /// Create a new device of the specified type from an existing device.
    ///
    /// If the source device is a device of the target type or was originally
    /// derived from such a device (possibly through one or more intermediate
    /// devices of other types), then this will return a reference to the
    /// existing device of the same type as is requested.
    ///
    /// Otherwise, it will attempt to derive a new device from the given source
    /// device.  If direct derivation to the new type is not implemented, it will
    /// attempt the same derivation from each ancestor of the source device in
    /// turn looking for an implemented derivation method.
    /// </summary>
    /// <param name="dstCtx">On success, a reference to the newly-created AVHWDeviceContext.</param>
    /// <param name="type">The type of the new device to create.</param>
    /// <param name="srcCtx">A reference to an existing AVHWDeviceContext which will be used to create the new device.</param>
    /// <param name="flags">Currently unused; should be set to zero.</param>
    /// <returns>Zero on success, a negative AVERROR code on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int av_hwdevice_ctx_create_derived(out Ptr<AVBufferRef> dstCtx, AVHWDeviceType type,
        Ptr<AVBufferRef> srcCtx, int flags);

    /// <summary>
    /// Create a new device of the specified type from an existing device.
    ///
    /// This function performs the same action as av_hwdevice_ctx_create_derived,
    /// however, it is able to set options for the new device to be derived.
    /// </summary>
    /// <param name="dstCtx">On success, a reference to the newly-created AVHWDeviceContext.</param>
    /// <param name="type">The type of the new device to create.</param>
    /// <param name="srcCtx">A reference to an existing AVHWDeviceContext which will be used to create the new device.</param>
    /// <param name="options">Options for the new device to create, same format as in av_hwdevice_ctx_create.</param>
    /// <param name="flags">Currently unused; should be set to zero.</param>
    /// <returns>Zero on success, a negative AVERROR code on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int av_hwdevice_ctx_create_derived_opts(out Ptr<AVBufferRef> dstCtx,
        AVHWDeviceType type, Ptr<AVBufferRef> srcCtx, Ptr<AVDictionary> options, int flags);

    /// <summary>
    /// Allocate an AVHWFramesContext tied to a given device context.
    /// </summary>
    /// <param name="deviceCtx">a reference to a AVHWDeviceContext. This function will make
    /// a new reference for internal use, the one passed to the
    /// function remains owned by the caller.</param>
    /// <returns>a reference to the newly created AVHWFramesContext on success or NULL on failure.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVBufferRef> av_hwframe_ctx_alloc(Ptr<AVBufferRef> deviceCtx);

    /// <summary>
    /// Finalize the context before use. This function must be called after the
    /// context is filled with all the required information and before it is attached
    /// to any frames.
    /// </summary>
    /// <param name="bufferRef">a reference to the AVHWFramesContext</param>
    /// <returns>0 on success, a negative AVERROR code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_hwframe_ctx_init(Ptr<AVBufferRef> bufferRef);

    /// <summary>
    /// Allocate a new frame attached to the given AVHWFramesContext.
    /// </summary>
    /// <param name="hwFrameCtx">a reference to an AVHWFramesContext</param>
    /// <param name="frame">an empty (freshly allocated or unreffed) frame to be filled with newly allocated buffers.</param>
    /// <param name="flags">currently unused, should be set to zero</param>
    /// <returns>0 on success, a negative AVERROR code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_hwframe_get_buffer(Ptr<AVBufferRef> hwFrameCtx, Ptr<AVFrame> frame, int flags);

    /// <summary>
    /// Copy data to or from a hw surface. At least one of dst/src must have an AVHWFramesContext attached.
    ///
    /// If src has an AVHWFramesContext attached, then the format of dst (if set)
    /// must use one of the formats returned by av_hwframe_transfer_get_formats(src,
    /// AV_HWFRAME_TRANSFER_DIRECTION_FROM).
    /// If dst has an AVHWFramesContext attached, then the format of src must use one
    /// of the formats returned by av_hwframe_transfer_get_formats(dst,
    /// AV_HWFRAME_TRANSFER_DIRECTION_TO)
    ///
    /// dst may be "clean" (i.e. with data/buf pointers unset), in which case the
    /// data buffers will be allocated by this function using av_frame_get_buffer().
    /// If dst->format is set, then this format will be used, otherwise (when
    /// dst->format is AV_PIX_FMT_NONE) the first acceptable format will be chosen.
    ///
    /// The two frames must have matching allocated dimensions (i.e. equal to
    /// AVHWFramesContext.width/height), since not all device types support
    /// transferring a sub-rectangle of the whole surface. The display dimensions
    /// (i.e. AVFrame.width/height) may be smaller than the allocated dimensions, but
    /// also have to be equal for both frames. When the display dimensions are
    /// smaller than the allocated dimensions, the content of the padding in the
    /// destination frame is unspecified.
    /// </summary>
    /// <param name="dst">the destination frame. dst is not touched on failure.</param>
    /// <param name="src">the source frame.</param>
    /// <param name="flags">currently unused, should be set to zero</param>
    /// <returns>0 on success, a negative AVERROR error code on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int av_hwframe_transfer_data(Ptr<AVFrame> dst, ConstPtr<AVFrame> src, int flags);

    /// <summary>
    /// Get a list of possible source or target formats usable in av_hwframe_transfer_data().
    /// </summary>
    /// <param name="hwFrameCtx">the frame context to obtain the information for</param>
    /// <param name="dir">the direction of the transfer</param>
    /// <param name="formats">the pointer to the output format list will be written here.
    /// The list is terminated with AV_PIX_FMT_NONE and must be freed
    /// by the caller when no longer needed using av_free().
    /// If this function returns successfully, the format list will
    /// have at least one item (not counting the terminator).
    /// On failure, the contents of this pointer are unspecified.</param>
    /// <param name="flags">currently unused, should be set to zero</param>
    /// <returns>0 on success, a negative AVERROR code on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int av_hwframe_transfer_get_formats(Ptr<AVBufferRef> hwFrameCtx,
        AVHWFrameTransferDirection dir, out Ptr<AVPixelFormat> formats, int flags);

    /// <summary>
    /// Allocate a HW-specific configuration structure for a given HW device.
    /// After use, the user must free all members as required by the specific
    /// hardware structure being used, then free the structure itself with av_free().
    /// </summary>
    /// <param name="deviceCtx">a reference to the associated AVHWDeviceContext.</param>
    /// <returns>The newly created HW-specific configuration structure on success or NULL on failure.</returns>
    [DllImport(LibraryName)]
    public static extern IntPtr av_hwdevice_hwconfig_alloc(Ptr<AVBufferRef> deviceCtx);

    /// <summary>
    /// Get the constraints on HW frames given a device and the HW-specific
    /// configuration to be used with that device.  If no HW-specific
    /// configuration is provided, returns the maximum possible capabilities
    /// of the device.
    /// </summary>
    /// <param name="bufferRef">a reference to the associated AVHWDeviceContext.</param>
    /// <param name="hwConfig">a filled HW-specific configuration structure, or NULL
    /// to return the maximum possible capabilities of the device.</param>
    /// <returns>AVHWFramesConstraints structure describing the constraints
    /// on the device, or NULL if not available.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVHWFramesConstraints> av_hwdevice_get_hwframe_constraints(Ptr<AVBufferRef> bufferRef,
        /* const */ IntPtr hwConfig);

    /// <summary>
    /// Free an AVHWFrameConstraints structure.
    /// </summary>
    /// <param name="constraints">The (filled or unfilled) AVHWFrameConstraints structure.</param>
    [DllImport(LibraryName)]
    public static extern void av_hwframe_constraints_free(ref Ptr<AVHWFramesConstraints> constraints);

    /// <summary>
    /// Map a hardware frame.
    ///
    /// This has a number of different possible effects, depending on the format
    /// and origin of the src and dst frames.  On input, src should be a usable
    /// frame with valid buffers and dst should be blank (typically as just created
    /// by av_frame_alloc()).  src should have an associated hwframe context, and
    /// dst may optionally have a format and associated hwframe context.
    ///
    /// If src was created by mapping a frame from the hwframe context of dst,
    /// then this function undoes the mapping - dst is replaced by a reference to
    /// the frame that src was originally mapped from.
    ///
    /// If both src and dst have an associated hwframe context, then this function
    /// attempts to map the src frame from its hardware context to that of dst and
    /// then fill dst with appropriate data to be usable there.  This will only be
    /// possible if the hwframe contexts and associated devices are compatible -
    /// given compatible devices, av_hwframe_ctx_create_derived() can be used to
    /// create a hwframe context for dst in which mapping should be possible.
    ///
    /// If src has a hwframe context but dst does not, then the src frame is
    /// mapped to normal memory and should thereafter be usable as a normal frame.
    /// If the format is set on dst, then the mapping will attempt to create dst
    /// with that format and fail if it is not possible.  If format is unset (is
    /// AV_PIX_FMT_NONE) then dst will be mapped with whatever the most appropriate
    /// format to use is (probably the sw_format of the src hwframe context).
    ///
    /// A return value of AVERROR(ENOSYS) indicates that the mapping is not
    /// possible with the given arguments and hwframe setup, while other return
    /// values indicate that it failed somehow.
    /// </summary>
    /// <param name="dst">Destination frame, to contain the mapping.</param>
    /// <param name="src">Source frame, to be mapped.</param>
    /// <param name="flags">Some combination of AV_HWFRAME_MAP_* flags.</param>
    /// <returns>Zero on success, negative AVERROR code on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int av_hwframe_map(Ptr<AVFrame> dst, ConstPtr<AVFrame> src, AVHWFrameMapFlags flags);

    /// <summary>
    /// Create and initialise an AVHWFramesContext as a mapping of another existing
    /// AVHWFramesContext on a different device.
    /// av_hwframe_ctx_init() should not be called after this.
    /// </summary>
    /// <param name="derivedFrameCtx">On success, a reference to the newly created AVHWFramesContext.</param>
    /// <param name="format"></param>
    /// <param name="derivedDeviceCtx">A reference to the device to create the new AVHWFramesContext on.</param>
    /// <param name="sourceFrameCtx">A reference to an existing AVHWFramesContext
    /// which will be mapped to the derived context.</param>
    /// <param name="flags">Some combination of AV_HWFRAME_MAP_* flags, defining the
    /// mapping parameters to apply to frames which are allocated in the derived device.</param>
    /// <returns>Zero on success, negative AVERROR code on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int av_hwframe_ctx_create_derived(out Ptr<AVBufferRef> derivedFrameCtx,
        AVPixelFormat format, Ptr<AVBufferRef> derivedDeviceCtx, Ptr<AVBufferRef> sourceFrameCtx,
        AVHWFrameMapFlags flags);
}
