namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    public const int AES_CTR_KEY_SIZE = 16;
    public const int AES_CTR_IV_SIZE = 8;

    /// <summary>
    /// Allocate an AVAESCTR context.
    /// </summary>
    [DllImport(LibraryName)]
    public static extern Ptr<AVAESCTR> av_aes_ctr_alloc();

    /// <summary>
    /// Initialize an AVAESCTR context.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="key">encryption key, must have a length of AES_CTR_KEY_SIZE</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_aes_ctr_init(Ptr<AVAESCTR> a, ConstPtr<byte> key);

    /// <summary>
    /// Release an AVAESCTR context.
    /// </summary>
    /// <param name="a"></param>
    [DllImport(LibraryName)]
    public static extern void av_aes_ctr_free(Ptr<AVAESCTR> a);

    /// <summary>
    /// Process a buffer using a previously initialized context.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="dst">destination array, can be equal to src</param>
    /// <param name="src">source array, can be equal to dst</param>
    /// <param name="size">the size of src and dst</param>
    [DllImport(LibraryName)]
    public static extern void av_aes_ctr_crypt(Ptr<AVAESCTR> a, Ptr<byte> dst, ConstPtr<byte> src, int size);

    /// <summary>
    /// Get the current iv
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<byte> av_aes_ctr_get_iv(Ptr<AVAESCTR> a);

    /// <summary>
    /// Generate a random iv
    /// </summary>
    /// <param name="a"></param>
    [DllImport(LibraryName)]
    public static extern void av_aes_ctr_set_random_iv(Ptr<AVAESCTR> a);

    /// <summary>
    /// Forcefully change the 8-byte iv
    /// </summary>
    /// <param name="a"></param>
    /// <param name="iv"></param>
    [DllImport(LibraryName)]
    public static extern void av_aes_ctr_set_iv(Ptr<AVAESCTR> a, ConstPtr<byte> iv);

    /// <summary>
    /// Forcefully change the "full" 16-byte iv, including the counter
    /// </summary>
    /// <param name="a"></param>
    /// <param name="iv"></param>
    [DllImport(LibraryName)]
    public static extern void av_aes_ctr_set_full_iv(Ptr<AVAESCTR> a, ConstPtr<byte> iv);

    /// <summary>
    /// Increment the top 64 bit of the iv (performed after each frame)
    /// </summary>
    /// <param name="a"></param>
    [DllImport(LibraryName)]
    public static extern void av_aes_ctr_increment_iv(Ptr<AVAESCTR> a);
}
