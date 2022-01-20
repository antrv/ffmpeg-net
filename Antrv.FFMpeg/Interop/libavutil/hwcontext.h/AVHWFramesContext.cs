namespace Antrv.FFMpeg.Interop;

/// <summary>
/// This struct describes a set or pool of "hardware" frames (i.e. those with
/// data not located in normal system memory). All the frames in the pool are
/// assumed to be allocated in the same way and interchangeable.
///
/// This struct is reference-counted with the AVBuffer mechanism and tied to a
/// given AVHWDeviceContext instance. The av_hwframe_ctx_alloc() constructor
/// yields a reference, whose data field points to the actual AVHWFramesContext struct.
/// </summary>
public struct AVHWFramesContext
{
    /// <summary>
    /// A class for logging.
    /// </summary>
    public ConstPtr<AVClass> Class;

    /// <summary>
    /// Private data used internally by libavutil. Must not be accessed in any way by the caller.
    /// </summary>
    public Ptr<AVHWFramesInternal> Internal;

    /// <summary>
    /// A reference to the parent AVHWDeviceContext. This reference is owned and
    /// managed by the enclosing AVHWFramesContext, but the caller may derive
    /// additional references from it.
    /// </summary>
    public Ptr<AVBufferRef> DeviceRef;

    /// <summary>
    /// The parent AVHWDeviceContext. This is simply a pointer to device_ref->data provided for convenience.
    /// Set by libavutil in av_hwframe_ctx_init().
    /// </summary>
    public Ptr<AVHWDeviceContext> DeviceCtx;

    /// <summary>
    /// The format-specific data, allocated and freed automatically along with this context.
    ///
    /// Should be cast by the user to the format-specific context defined in the
    /// corresponding header (hwframe_*.h) and filled as described in the
    /// documentation before calling av_hwframe_ctx_init().
    ///
    /// After any frames using this context are created, the contents of this
    /// struct should not be modified by the caller.
    /// </summary>
    public IntPtr HwCtx;

    /// <summary>
    /// This field may be set by the caller before calling av_hwframe_ctx_init().
    ///
    /// If non-NULL, this callback will be called when the last reference to
    /// this context is unreferenced, immediately before it is freed.
    /// </summary>
    public IntPtr Free; // void (*free)(struct AVHWFramesContext *ctx);

    /// <summary>
    /// Arbitrary user data, to be used e.g. by the free() callback.
    /// </summary>
    public IntPtr UserOpaque;

    /// <summary>
    /// A pool from which the frames are allocated by av_hwframe_get_buffer().
    /// This field may be set by the caller before calling av_hwframe_ctx_init().
    /// The buffers returned by calling av_buffer_pool_get() on this pool must
    /// have the properties described in the documentation in the corresponding hw
    /// type's header (hwcontext_*.h). The pool will be freed strictly before
    /// this struct's free() callback is invoked.
    ///
    /// This field may be NULL, then libavutil will attempt to allocate a pool
    /// internally. Note that certain device types enforce pools allocated at
    /// fixed size (frame count), which cannot be extended dynamically. In such a
    /// case, initial_pool_size must be set appropriately.
    /// </summary>
    public Ptr<AVBufferPool> Pool;

    /// <summary>
    /// Initial size of the frame pool. If a device type does not support
    /// dynamically resizing the pool, then this is also the maximum pool size.
    ///
    /// May be set by the caller before calling av_hwframe_ctx_init(). Must be
    /// set if pool is NULL and the device type does not support dynamic pools.
    /// </summary>
    public int InitialPoolSize;

    /// <summary>
    /// The pixel format identifying the underlying HW surface type.
    ///
    /// Must be a hwaccel format, i.e. the corresponding descriptor must have the
    /// AV_PIX_FMT_FLAG_HWACCEL flag set.
    ///
    /// Must be set by the user before calling av_hwframe_ctx_init().
    /// </summary>
    public AVPixelFormat Format;

    /// <summary>
    /// The pixel format identifying the actual data layout of the hardware frames.
    ///
    /// Must be set by the caller before calling av_hwframe_ctx_init().
    ///
    /// NOTE: when the underlying API does not provide the exact data layout, but
    /// only the colorspace/bit depth, this field should be set to the fully
    /// planar version of that format (e.g. for 8-bit 420 YUV it should be
    /// AV_PIX_FMT_YUV420P, not AV_PIX_FMT_NV12 or anything else).
    /// </summary>
    public AVPixelFormat SwFormat;

    /// <summary>
    /// The allocated dimensions of the frames in this pool.
    ///
    /// Must be set by the user before calling av_hwframe_ctx_init().
    /// </summary>
    public int Width, Height;
}
