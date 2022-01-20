namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Structure to hold side data for an AVFrame.
/// 
/// sizeof(AVFrameSideData) is not a part of the public ABI, so new fields may be added
/// to the end with a minor bump.
/// </summary>
public struct AVFrameSideData
{
    public AVFrameSideDataType Type;
    public Ptr<byte> Data;
    public nuint Size;
    public Ptr<AVDictionary> Metadata;
    public Ptr<AVBufferRef> Buf;
}
