namespace Antrv.FFMpeg.Interop;

/// <summary>
/// vectors can be shared
/// </summary>
public struct SwsFilter
{
    public Ptr<SwsVector> LumH;
    public Ptr<SwsVector> LumV;
    public Ptr<SwsVector> ChrH;
    public Ptr<SwsVector> ChrV;
}
