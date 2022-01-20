namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Allocate an AVBuffer of the given size using av_malloc().
    /// </summary>
    /// <param name="size"></param>
    /// <returns>an AVBufferRef of given size or NULL when out of memory</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVBufferRef> av_buffer_alloc(nuint size);

    /// <summary>
    /// Same as av_buffer_alloc(), except the returned buffer will be initialized to zero.
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVBufferRef> av_buffer_allocz(nuint size);

    /// <summary>
    /// Create an AVBuffer from an existing array.
    ///
    /// If this function is successful, data is owned by the AVBuffer. The caller may
    /// only access data through the returned AVBufferRef and references derived from it.
    /// If this function fails, data is left untouched.
    /// </summary>
    /// <param name="data">data array</param>
    /// <param name="size">size of data in bytes</param>
    /// <param name="free">a callback for freeing this buffer's data</param>
    /// <param name="opaque">parameter to be got for processing or passed to free</param>
    /// <param name="flags">a combination of AV_BUFFER_FLAG_*</param>
    /// <returns>an AVBufferRef referring to data on success, NULL on failure.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVBufferRef> av_buffer_create(Ptr<byte> data, nuint size,
        [MarshalAs(UnmanagedType.FunctionPtr)] AVBufferDataFree free, IntPtr opaque, AVBufferFlags flags);

    /// <summary>
    /// Default free callback, which calls av_free() on the buffer data.
    /// This function is meant to be passed to av_buffer_create(), not called directly.
    /// </summary>
    /// <param name="opaque"></param>
    /// <param name="data"></param>
    [DllImport(LibraryName)]
    public static extern void av_buffer_default_free(IntPtr opaque, Ptr<byte> data);

    /// <summary>
    /// Create a new reference to an AVBuffer.
    /// </summary>
    /// <param name="buf"></param>
    /// <returns>a new AVBufferRef referring to the same AVBuffer as buf or NULL on failure.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVBufferRef> av_buffer_ref(ConstPtr<AVBufferRef> buf);

    /// <summary>
    /// Free a given reference and automatically free the buffer if there are no more references to it.
    /// </summary>
    /// <param name="buf">the reference to be freed. The pointer is set to NULL on return.</param>
    [DllImport(LibraryName)]
    public static extern void av_buffer_unref(ref Ptr<AVBufferRef> buf);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buf"></param>
    /// <returns>1 if the caller may write to the data referred to by buf (which is
    /// true if and only if buf is the only reference to the underlying AVBuffer).
    /// Return 0 otherwise.
    /// A positive answer is valid until av_buffer_ref() is called on buf.
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int av_buffer_is_writable(ConstPtr<AVBufferRef> buf);

    /// <summary>
    /// Returns the opaque parameter set by av_buffer_create.
    /// </summary>
    /// <param name="buf"></param>
    /// <returns>the opaque parameter set by av_buffer_create.</returns>
    [DllImport(LibraryName)]
    public static extern IntPtr av_buffer_get_opaque(ConstPtr<AVBufferRef> buf);

    [DllImport(LibraryName)]
    public static extern int av_buffer_get_ref_count(ConstPtr<AVBufferRef> buf);

    /// <summary>
    /// Create a writable reference from a given buffer reference, avoiding data copy if possible.
    /// </summary>
    /// <param name="buf">buffer reference to make writable. On success, buf is either left
    /// untouched, or it is unreferenced and a new writable AVBufferRef is
    /// written in its place. On failure, buf is left untouched.</param>
    /// <returns>0 on success, a negative AVERROR on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int av_buffer_make_writable(ref Ptr<AVBufferRef> buf);

    /// <summary>
    /// Reallocate a given buffer.
    ///
    /// Note: the buffer is actually reallocated with av_realloc() only if it was
    /// initially allocated through av_buffer_realloc(NULL) and there is only one
    /// reference to it (i.e. the one passed to this function). In all other cases
    /// a new buffer is allocated and the data is copied.
    /// </summary>
    /// <param name="buf">a buffer reference to reallocate. On success, buf will be
    /// unreferenced and a new reference with the required size will be
    /// written in its place. On failure buf will be left untouched. *buf
    /// may be NULL, then a new buffer is allocated.</param>
    /// <param name="size">required new buffer size.</param>
    /// <returns>0 on success, a negative AVERROR on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int av_buffer_realloc(ref Ptr<AVBufferRef> buf, nuint size);

    /// <summary>
    /// Ensure dst refers to the same data as src.
    ///
    /// When *dst is already equivalent to src, do nothing. Otherwise unreference dst
    /// and replace it with a new reference to src.
    /// </summary>
    /// <param name="dst">Pointer to either a valid buffer reference or NULL. On success,
    /// this will point to a buffer reference equivalent to src. On
    /// failure, dst will be left untouched.</param>
    /// <param name="src">A buffer reference to replace dst with. May be NULL, then this
    /// function is equivalent to av_buffer_unref(dst).</param>
    /// <returns>0 on success, AVERROR(ENOMEM) on memory allocation failure.</returns>
    [DllImport(LibraryName)]
    public static extern int av_buffer_replace(ref Ptr<AVBufferRef> dst, ConstPtr<AVBufferRef> src);

    /// <summary>
    /// Allocate and initialize a buffer pool.
    /// </summary>
    /// <param name="size">size of each buffer in this pool</param>
    /// <param name="alloc"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVBufferPool> av_buffer_pool_init(nuint size,
        [MarshalAs(UnmanagedType.FunctionPtr)] AVBufferAllocator alloc);

    /// <summary>
    /// Allocate and initialize a buffer pool with a more complex allocator.
    /// </summary>
    /// <param name="size">size of each buffer in this pool</param>
    /// <param name="opaque">arbitrary user data used by the allocator</param>
    /// <param name="alloc">a function that will be used to allocate new buffers when the
    /// pool is empty. May be NULL, then the default allocator will be
    /// used (av_buffer_alloc()).</param>
    /// <param name="poolFree">a function that will be called immediately before the pool
    /// is freed. I.e. after av_buffer_pool_uninit() is called
    /// by the caller and all the frames are returned to the pool
    /// and freed. It is intended to uninitialize the user opaque
    /// data. May be NULL.</param>
    /// <returns>newly created buffer pool on success, NULL on error.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVBufferPool> av_buffer_pool_init2(nuint size, IntPtr opaque,
        [MarshalAs(UnmanagedType.FunctionPtr)] AVBufferAllocator2 alloc,
        [MarshalAs(UnmanagedType.FunctionPtr)] AVBufferPoolFree poolFree);

    /// <summary>
    /// Mark the pool as being available for freeing. It will actually be freed only
    /// once all the allocated buffers associated with the pool are released. Thus it
    /// is safe to call this function while some of the allocated buffers are still in use.
    /// </summary>
    /// <param name="pool">pointer to the pool to be freed. It will be set to NULL.</param>
    [DllImport(LibraryName)]
    public static extern void av_buffer_pool_uninit(ref Ptr<AVBufferPool> pool);

    /// <summary>
    /// Allocate a new AVBuffer, reusing an old buffer from the pool when available.
    /// This function may be called simultaneously from multiple threads.
    /// </summary>
    /// <param name="pool"></param>
    /// <returns>a reference to the new buffer on success, NULL on error.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVBufferRef> av_buffer_pool_get(Ptr<AVBufferPool> pool);

    /// <summary>
    /// Query the original opaque parameter of an allocated buffer in the pool.
    ///
    /// Note: the opaque parameter of ref is used by the buffer pool implementation,
    /// therefore you have to use this function to access the original opaque
    /// parameter of an allocated buffer.
    /// </summary>
    /// <param name="bufRef">a buffer reference to a buffer returned by av_buffer_pool_get.</param>
    /// <returns>the opaque parameter set by the buffer allocator function of the buffer pool.</returns>
    [DllImport(LibraryName)]
    public static extern IntPtr av_buffer_pool_buffer_get_opaque(ConstPtr<AVBufferRef> bufRef);
}
