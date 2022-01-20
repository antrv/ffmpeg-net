namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Get a seed to use in conjunction with random functions.
    /// This function tries to provide a good seed at a best effort bases.
    /// Its possible to call this function multiple times if more bits are needed.
    /// It can be quite slow, which is why it should only be used as seed for a faster
    /// PRNG. The quality of the seed depends on the platform.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint av_get_random_seed();
}
