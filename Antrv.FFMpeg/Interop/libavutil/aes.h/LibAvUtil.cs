namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Allocate an AVAES context.
    /// </summary>
    [DllImport(LibraryName)]
    public static extern Ptr<AVAES> av_aes_alloc();


    /// <summary>
    /// Initialize an AVAES context.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="key"></param>
    /// <param name="keyBits">128, 192 or 256</param>
    /// <param name="decrypt">0 for encryption, 1 for decryption</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_aes_init(Ptr<AVAES> a, ConstPtr<byte> key, int keyBits, int decrypt);

    /// <summary>
    /// Encrypt or decrypt a buffer using a previously initialized context.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="dst">destination array, can be equal to src</param>
    /// <param name="src">source array, can be equal to dst</param>
    /// <param name="count">number of 16 byte blocks</param>
    /// <param name="iv">initialization vector for CBC mode, if NULL then ECB will be used</param>
    /// <param name="decrypt">0 for encryption, 1 for decryption</param>
    [DllImport(LibraryName)]
    public static extern void av_aes_crypt(Ptr<AVAES> a, Ptr<byte> dst, ConstPtr<byte> src, int count, Ptr<byte> iv,
        int decrypt);
}
