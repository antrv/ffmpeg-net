namespace Antrv.FFMpeg.Interop;

partial class LibSwScale
{
    public const double SWS_MAX_REDUCE_CUTOFF = 0.002;

    public const int SWS_SRC_V_CHR_DROP_MASK = 0x30000;
    public const int SWS_SRC_V_CHR_DROP_SHIFT = 16;

    public const int SWS_PARAM_DEFAULT = 123456;

    /// <summary>
    /// Return the LIBSWSCALE_VERSION_INT constant.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint swscale_version();

    /// <summary>
    /// Return the libswscale build-time configuration.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr swscale_configuration();

    /// <summary>
    /// Return the libswscale license.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr swscale_license();

    /// <summary>
    /// Return a pointer to yuv<->rgb coefficients for the given colorspace
    /// suitable for sws_setColorspaceDetails().
    /// </summary>
    /// <param name="colorSpace"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<int> sws_getCoefficients(SwsColorSpace colorSpace);

    /// <summary>
    /// Return a positive value if pix_fmt is a supported input format, 0 otherwise.
    /// </summary>
    /// <param name="pixelFormat"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int sws_isSupportedInput(AVPixelFormat pixelFormat);

    /// <summary>
    /// Return a positive value if pix_fmt is a supported output format, 0 otherwise.
    /// </summary>
    /// <param name="pixelFormat"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int sws_isSupportedOutput(AVPixelFormat pixelFormat);

    /// <summary>
    /// a positive value if an endianness conversion for pix_fmt is supported, 0 otherwise.
    /// </summary>
    /// <param name="pixelFormat"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int sws_isSupportedEndiannessConversion(AVPixelFormat pixelFormat);

    /// <summary>
    /// Allocate an empty SwsContext. This must be filled and passed to
    /// sws_init_context(). For filling see AVOptions, options.c and
    /// sws_setColorspaceDetails().
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<SwsContext> sws_alloc_context();

    /// <summary>
    /// Initialize the swscaler context sws_context.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="srcFilter"></param>
    /// <param name="dstFilter"></param>
    /// <returns>zero or positive value on success, a negative value on error</returns>
    [DllImport(LibraryName)]
    public static extern int sws_init_context(Ptr<SwsContext> context, Ptr<SwsFilter> srcFilter,
        Ptr<SwsFilter> dstFilter);

    /// <summary>
    /// Free the swscaler context swsContext. If swsContext is NULL, then does nothing.
    /// </summary>
    /// <param name="context"></param>
    [DllImport(LibraryName)]
    public static extern void sws_freeContext(Ptr<SwsContext> context);

    /// <summary>
    /// Allocate and return an SwsContext. You need it to perform
    /// scaling/conversion operations using sws_scale().
    /// </summary>
    /// <param name="srcW">the width of the source image</param>
    /// <param name="srcH">the height of the source image</param>
    /// <param name="srcFormat">the source image format</param>
    /// <param name="dstW">the width of the destination image</param>
    /// <param name="dstH">the height of the destination image</param>
    /// <param name="dstFormat">the destination image format</param>
    /// <param name="flags">specify which algorithm and options to use for rescaling</param>
    /// <param name="srcFilter">extra parameters to tune the used scaler
    ///
    /// For SWS_BICUBIC param[0] and [1] tune the shape of the basis
    /// function, param[0] tunes f(1) and param[1] f´(1)
    /// For SWS_GAUSS param[0] tunes the exponent and thus cutoff frequency
    /// For SWS_LANCZOS param[0] tunes the width of the window function
    /// </param>
    /// <param name="dstFilter">
    /// </param>
    /// <param name="param"></param>
    /// <returns>a pointer to an allocated context, or NULL in case of error</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<SwsContext> sws_getContext(int srcW, int srcH, AVPixelFormat srcFormat, int dstW,
        int dstH, AVPixelFormat dstFormat, SwScaleFlags flags, Ptr<SwsFilter> srcFilter, Ptr<SwsFilter> dstFilter,
        ConstPtr<double> param);

    /// <summary>
    /// Scale the image slice in srcSlice and put the resulting scaled
    /// slice in the image in dst. A slice is a sequence of consecutive
    /// rows in an image.
    ///
    /// Slices have to be provided in sequential order, either in
    /// top-bottom or bottom-top order. If slices are provided in
    /// non-sequential order the behavior of the function is undefined.
    /// </summary>
    /// <param name="c">the scaling context previously created with sws_getContext()</param>
    /// <param name="srcSlice">the array containing the pointers to the planes of the source slice</param>
    /// <param name="srcStride">the array containing the strides for each plane of the source image</param>
    /// <param name="srcSliceY">the position in the source image of the slice to
    /// process, that is the number (counted starting from
    /// zero) in the image of the first row of the slice</param>
    /// <param name="srcSliceH">the height of the source slice, that is the number
    /// of rows in the slice</param>
    /// <param name="dst">the array containing the pointers to the planes of
    /// the destination image</param>
    /// <param name="dstStride">the array containing the strides for each plane of
    /// the destination image</param>
    /// <returns>the height of the output slice</returns>
    [DllImport(LibraryName)]
    public static extern int sws_scale(Ptr<SwsContext> c, ConstPtr<ConstPtr<byte>> srcSlice, ConstPtr<int> srcStride,
        int srcSliceY, int srcSliceH, Ptr<Ptr<byte>> dst, ConstPtr<int> dstStride);

    /// <summary>
    /// Scale source data from src and write the output to dst.
    ///
    /// This is merely a convenience wrapper around
    /// - sws_frame_start()
    /// - sws_send_slice(0, src->height)
    /// - sws_receive_slice(0, dst->height)
    /// - sws_frame_end()
    /// </summary>
    /// <param name="c"></param>
    /// <param name="dst">The destination frame. See documentation for sws_frame_start() for more details.</param>
    /// <param name="src">The source frame.</param>
    /// <returns>0 on success, a negative AVERROR code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int sws_scale_frame(Ptr<SwsContext> c, Ptr<AVFrame> dst, ConstPtr<AVFrame> src);

    /// <summary>
    /// Initialize the scaling process for a given pair of source/destination frames.
    /// Must be called before any calls to sws_send_slice() and sws_receive_slice().
    ///
    /// This function will retain references to src and dst, so they must both use
    /// refcounted buffers (if allocated by the caller, in case of dst).
    /// </summary>
    /// <param name="c"></param>
    /// <param name="dst">The destination frame.
    ///
    /// The data buffers may either be already allocated by the caller or
    /// left clear, in which case they will be allocated by the scaler.
    /// The latter may have performance advantages - e.g. in certain cases
    /// some output planes may be references to input planes, rather than copies.
    ///
    /// Output data will be written into this frame in successful sws_receive_slice() calls.
    /// </param>
    /// <param name="src">The source frame. The data buffers must be allocated, but the
    /// frame data does not have to be ready at this point. Data
    /// availability is then signalled by sws_send_slice().</param>
    /// <returns>0 on success, a negative AVERROR code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int sws_frame_start(Ptr<SwsContext> c, Ptr<AVFrame> dst, ConstPtr<AVFrame> src);

    /// <summary>
    /// Finish the scaling process for a pair of source/destination frames previously
    /// submitted with sws_frame_start(). Must be called after all sws_send_slice()
    /// and sws_receive_slice() calls are done, before any new sws_frame_start() calls.
    /// </summary>
    /// <param name="c"></param>
    [DllImport(LibraryName)]
    public static extern void sws_frame_end(Ptr<SwsContext> c);

    /// <summary>
    /// Indicate that a horizontal slice of input data is available in the source
    /// frame previously provided to sws_frame_start(). The slices may be provided in
    /// any order, but may not overlap. For vertically subsampled pixel formats, the
    /// slices must be aligned according to subsampling.
    /// </summary>
    /// <param name="c"></param>
    /// <param name="sliceStart">first row of the slice</param>
    /// <param name="sliceHeight">number of rows in the slice</param>
    /// <returns>a non-negative number on success, a negative AVERROR code on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int sws_send_slice(Ptr<SwsContext> c, uint sliceStart, uint sliceHeight);

    /// <summary>
    /// Request a horizontal slice of the output data to be written into the frame
    /// previously provided to sws_frame_start().
    /// </summary>
    /// <param name="c"></param>
    /// <param name="sliceStart">first row of the slice; must be a multiple of sws_receive_slice_alignment()</param>
    /// <param name="sliceHeight">number of rows in the slice; must be a multiple of
    /// sws_receive_slice_alignment(), except for the last slice
    /// (i.e. when slice_start+slice_height is equal to output frame height)</param>
    /// <returns>a non-negative number if the data was successfully written into the output
    /// AVERROR(EAGAIN) if more input data needs to be provided before the output can be produced
    /// another negative AVERROR code on other kinds of scaling failure
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int sws_receive_slice(Ptr<SwsContext> c, uint sliceStart, uint sliceHeight);

    /// <summary>
    /// Returns alignment required for output slices requested with sws_receive_slice().
    /// Slice offsets and sizes passed to sws_receive_slice() must be
    /// multiples of the value returned from this function.
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint sws_receive_slice_alignment(ConstPtr<SwsContext> c);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="c"></param>
    /// <param name="invTable">the yuv2rgb coefficients describing the input yuv space, normally ff_yuv2rgb_coeffs[x]</param>
    /// <param name="srcRange">flag indicating the while-black range of the input (1=jpeg / 0=mpeg)</param>
    /// <param name="table">the yuv2rgb coefficients describing the output yuv space, normally ff_yuv2rgb_coeffs[x]</param>
    /// <param name="dstRange">flag indicating the while-black range of the output (1=jpeg / 0=mpeg)</param>
    /// <param name="brightness">16.16 fixed point brightness correction</param>
    /// <param name="contrast">16.16 fixed point contrast correction</param>
    /// <param name="saturation">16.16 fixed point saturation correction</param>
    /// <returns>-1 if not supported</returns>
    [DllImport(LibraryName)]
    public static extern int sws_setColorspaceDetails(Ptr<SwsContext> c, ConstPtr<Array4<int>> invTable,
        int srcRange, ConstPtr<Array4<int>> table, int dstRange, int brightness, int contrast, int saturation);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="c"></param>
    /// <param name="invTable"></param>
    /// <param name="srcRange"></param>
    /// <param name="table"></param>
    /// <param name="dstRange"></param>
    /// <param name="brightness"></param>
    /// <param name="contrast"></param>
    /// <param name="saturation"></param>
    /// <returns>-1 if not supported</returns>
    [DllImport(LibraryName)]
    public static extern int sws_getColorspaceDetails(Ptr<SwsContext> c, out Ptr<int> invTable, out int srcRange,
        out Ptr<int> table, out int dstRange, out int brightness, out int contrast, out int saturation);

    /// <summary>
    /// Allocate and return an uninitialized vector with length coefficients.
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<SwsVector> sws_allocVec(int length);

    /// <summary>
    /// Return a normalized Gaussian curve used to filter stuff
    /// quality = 3 is high quality, lower is lower quality.
    /// </summary>
    /// <param name="variance"></param>
    /// <param name="quality"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<SwsVector> sws_getGaussianVec(double variance, double quality);

    /// <summary>
    /// Scale all the coefficients of a by the scalar value.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="scalar"></param>
    [DllImport(LibraryName)]
    public static extern void sws_scaleVec(Ptr<SwsVector> a, double scalar);

    /// <summary>
    /// Scale all the coefficients of a so that their sum equals height.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="height"></param>
    [DllImport(LibraryName)]
    public static extern void sws_normalizeVec(Ptr<SwsVector> a, double height);

    [DllImport(LibraryName)]
    public static extern void sws_freeVec(Ptr<SwsVector> a);

    [DllImport(LibraryName)]
    public static extern Ptr<SwsFilter> sws_getDefaultFilter(float lumaGBlur, float chromaGBlur, float lumaSharpen,
        float chromaSharpen, float chromaHShift, float chromaVShift, int verbose);

    [DllImport(LibraryName)]
    public static extern void sws_freeFilter(Ptr<SwsFilter> filter);

    /// <summary>
    /// Check if context can be reused, otherwise reallocate a new one.
    ///
    /// If context is NULL, just calls sws_getContext() to get a new
    /// context. Otherwise, checks if the parameters are the ones already
    /// saved in context. If that is the case, returns the current
    /// context. Otherwise, frees context and gets a new context with
    /// the new parameters.
    ///
    /// Be warned that srcFilter and dstFilter are not checked, they
    /// are assumed to remain the same.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="srcW"></param>
    /// <param name="srcH"></param>
    /// <param name="srcFormat"></param>
    /// <param name="dstW"></param>
    /// <param name="dstH"></param>
    /// <param name="dstFormat"></param>
    /// <param name="flags"></param>
    /// <param name="srcFilter"></param>
    /// <param name="dstFilter"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<SwsContext> sws_getCachedContext(Ptr<SwsContext> context, int srcW, int srcH,
        AVPixelFormat srcFormat, int dstW, int dstH, AVPixelFormat dstFormat, int flags, Ptr<SwsFilter> srcFilter,
        Ptr<SwsFilter> dstFilter, ConstPtr<double> param);

    /// <summary>
    /// Convert an 8-bit paletted frame into a frame with a color depth of 32 bits.
    ///
    /// The output frame will have the same packed format as the palette.
    /// </summary>
    /// <param name="src">source frame buffer</param>
    /// <param name="dst">destination frame buffer</param>
    /// <param name="numPixels">number of pixels to convert</param>
    /// <param name="palette">array with [256] entries, which must match color arrangement (RGB or BGR) of src</param>
    [DllImport(LibraryName)]
    public static extern void sws_convertPalette8ToPacked32(ConstPtr<byte> src, Ptr<byte> dst, int numPixels,
        ConstPtr<byte> palette);

    /// <summary>
    /// Convert an 8-bit paletted frame into a frame with a color depth of 24 bits.
    ///
    /// With the palette format "ABCD", the destination frame ends up with the format "ABC".
    /// </summary>
    /// <param name="src">source frame buffer</param>
    /// <param name="dst">destination frame buffer</param>
    /// <param name="numPixels">number of pixels to convert</param>
    /// <param name="palette">array with [256] entries, which must match color arrangement (RGB or BGR) of src</param>
    [DllImport(LibraryName)]
    public static extern void sws_convertPalette8ToPacked24(ConstPtr<byte> src, Ptr<byte> dst, int numPixels,
        ConstPtr<byte> palette);

    /// <summary>
    /// Get the AVClass for swsContext. It can be used in combination with
    /// AV_OPT_SEARCH_FAKE_OBJ for examining options.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVClass> sws_get_class();
}
