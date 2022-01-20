namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVErrorConcealmentFlags
{
    None = 0,
    FF_EC_GUESS_MVS = 1,
    FF_EC_DEBLOCK = 2,
    FF_EC_FAVOR_INTER = 256,
}
