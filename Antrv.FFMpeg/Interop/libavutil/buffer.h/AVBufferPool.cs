﻿namespace Antrv.FFMpeg.Interop;

/// <summary>
/// AVBufferPool is an API for a lock-free thread-safe pool of AVBuffers.
/// 
/// Frequently allocating and freeing large buffers may be slow. AVBufferPool is
/// meant to solve this in cases when the caller needs a set of buffers of the
/// same size (the most obvious use case being buffers for raw video or audio frames).
///
/// At the beginning, the user must call av_buffer_pool_init() to create the
/// buffer pool. Then whenever a buffer is needed, call av_buffer_pool_get() to
/// get a reference to a new buffer, similar to av_buffer_alloc(). This new
/// reference works in all aspects the same way as the one created by
/// av_buffer_alloc(). However, when the last reference to this buffer is
/// unreferenced, it is returned to the pool instead of being freed and will be
/// reused for subsequent av_buffer_pool_get() calls.
///
/// When the caller is done with the pool and no longer needs to allocate any new
/// buffers, av_buffer_pool_uninit() must be called to mark the pool as freeable.
/// Once all the buffers are released, it will automatically be freed.
///
/// Allocating and releasing buffers with this API is thread-safe as long as
/// either the default alloc callback is used, or the user-supplied one is thread-safe.
///
/// This structure is opaque and not meant to be accessed
/// directly. It is allocated with av_buffer_pool_init() and freed with
/// av_buffer_pool_uninit().
/// </summary>
public struct AVBufferPool
{
    // Opaque structure
}
