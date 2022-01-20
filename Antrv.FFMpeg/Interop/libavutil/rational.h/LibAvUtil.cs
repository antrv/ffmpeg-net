namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Create an AVRational.
    ///
    /// Useful for compilers that do not support compound literals.
    /// The return value is not reduced.
    /// </summary>
    /// <param name="num"></param>
    /// <param name="den"></param>
    /// <returns></returns>
    public static AVRational av_make_q(int num, int den) => new(num, den);

    /// <summary>
    /// Compare two rationals.
    /// </summary>
    /// <param name="a">First rational</param>
    /// <param name="b">Second rational</param>
    /// <returns>One of the following values:
    /// - 0 if `a == b`
    /// - 1 if `a &gt; b`
    /// - -1 if `a &lt; b`
    /// - `INT_MIN` if one of the values is of the form `0 / 0`</returns>
    public static int av_cmp_q(AVRational a, AVRational b)
    {
        long tmp = a.Numerator * (long)b.Denominator - b.Numerator * (long)a.Denominator;
        if (tmp != 0)
            return (int)((tmp ^ a.Denominator ^ b.Denominator) >> 63) | 1;

        if (b.Denominator != 0 && a.Denominator != 0)
            return 0;

        if (a.Numerator != 0 && b.Numerator != 0)
            return (a.Numerator >> 31) - (b.Numerator >> 31);

        return int.MinValue;
    }

    /// <summary>
    /// Convert an AVRational to a `double`.
    /// </summary>
    /// <param name="a">a AVRational to convert</param>
    /// <returns>`a` in floating-point form</returns>
    public static double av_q2d(AVRational a) => a.Numerator / (double)a.Denominator;

    /// <summary>
    /// Reduce a fraction.
    /// This is useful for framerate calculations.
    /// </summary>
    /// <param name="dstNum">Destination numerator</param>
    /// <param name="dstDen">Destination denominator</param>
    /// <param name="num">Source numerator</param>
    /// <param name="den">Source denominator</param>
    /// <param name="max">Maximum allowed values for `dst_num` & `dst_den`</param>
    /// <returns>1 if the operation is exact, 0 otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_reduce(out int dstNum, out int dstDen, long num, long den, long max);

    /// <summary>
    /// Multiply two rationals.
    /// </summary>
    /// <param name="b">First rational</param>
    /// <param name="c">Second rational</param>
    /// <returns>b*c</returns>
    [DllImport(LibraryName)]
    public static extern AVRational av_mul_q(AVRational b, AVRational c);

    /// <summary>
    /// Divide one rational by another.
    /// </summary>
    /// <param name="b">First rational</param>
    /// <param name="c">Second rational</param>
    /// <returns>b/c</returns>
    [DllImport(LibraryName)]
    public static extern AVRational av_div_q(AVRational b, AVRational c);

    /// <summary>
    /// Add two rationals.
    /// </summary>
    /// <param name="b">First rational</param>
    /// <param name="c">Second rational</param>
    /// <returns>b+c</returns>
    [DllImport(LibraryName)]
    public static extern AVRational av_add_q(AVRational b, AVRational c);

    /// <summary>
    /// Subtract one rational from another.
    /// </summary>
    /// <param name="b">First rational</param>
    /// <param name="c">Second rational</param>
    /// <returns>b-c</returns>
    [DllImport(LibraryName)]
    public static extern AVRational av_sub_q(AVRational b, AVRational c);

    /// <summary>
    /// Invert a rational.
    /// </summary>
    /// <param name="q">value</param>
    /// <returns>1 / q</returns>
    public static AVRational av_inv_q(AVRational q) => new(q.Denominator, q.Numerator);

    /// <summary>
    /// Convert a double precision floating point number to a rational.
    ///
    /// In case of infinity, the returned value is expressed as `{1, 0}` or
    /// `{-1, 0}` depending on the sign.
    /// </summary>
    /// <param name="d">`double` to convert</param>
    /// <param name="max">Maximum allowed numerator and denominator</param>
    /// <returns>`d` in AVRational form</returns>
    [DllImport(LibraryName)]
    public static extern AVRational av_d2q(double d, int max);

    /// <summary>
    /// Find which of the two rationals is closer to another rational.
    /// </summary>
    /// <param name="q">Rational to be compared against</param>
    /// <param name="q1">Rational to be tested</param>
    /// <param name="q2">Rational to be tested</param>
    /// <returns>One of the following values:
    /// - 1 if `q1` is nearer to `q` than `q2`
    /// - -1 if `q2` is nearer to `q` than `q1`
    /// - 0 if they have the same distance</returns>
    [DllImport(LibraryName)]
    public static extern int av_nearer_q(AVRational q, AVRational q1, AVRational q2);

    /// <summary>
    /// Find the value in a list of rationals nearest a given reference rational.
    /// </summary>
    /// <param name="q">Reference rational</param>
    /// <param name="list">Array of rationals terminated by `{0, 0}`</param>
    /// <returns>Index of the nearest value found in the array</returns>
    [DllImport(LibraryName)]
    public static extern int av_find_nearest_q_idx(AVRational q, Ptr<AVRational> list);

    /// <summary>
    /// Convert an AVRational to a IEEE 32-bit `float` expressed in fixed-point format.
    /// </summary>
    /// <param name="q">Rational to be converted</param>
    /// <returns>Equivalent floating-point value, expressed as an unsigned 32-bit integer.
    /// The returned value is platform-independent.</returns>
    [DllImport(LibraryName)]
    public static extern uint av_q2intfloat(AVRational q);

    /// <summary>
    /// Return the best rational so that a and b are multiple of it.
    /// If the resulting denominator is larger than max_den, return def.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="maxDen"></param>
    /// <param name="def"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVRational av_gcd_q(AVRational a, AVRational b, int maxDen, AVRational def);
}
