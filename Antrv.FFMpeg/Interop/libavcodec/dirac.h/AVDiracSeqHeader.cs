namespace Antrv.FFMpeg.Interop;

public struct AVDiracSeqHeader
{
    public uint Width;
    public uint Height;

    /// <summary>
    /// 0: 444  1: 422  2: 420
    /// </summary>
    public byte ChromaFormat;

    public byte Interlaced;
    public byte TopFieldFirst;

    /// <summary>
    /// index into dirac_frame_rate[]
    /// </summary>
    public byte FrameRateIndex;

    /// <summary>
    /// index into dirac_aspect_ratio[]
    /// </summary>
    public byte AspectRatioIndex;

    public ushort CleanWidth;
    public ushort CleanHeight;
    public ushort CleanLeftOffset;
    public ushort CleanRightOffset;

    /// <summary>
    /// index into dirac_pixel_range_presets[]
    /// </summary>
    public byte PixelRangeIndex;

    /// <summary>
    /// index into dirac_color_spec_presets[]
    /// </summary>
    public byte ColorSpecIndex;

    public int Profile;
    public int Level;

    public AVRational FrameRate;
    public AVRational SampleAspectRatio;

    public AVPixelFormat PixFmt;
    public AVColorRange ColorRange;
    public AVColorPrimaries ColorPrimaries;
    public AVColorTransferCharacteristic ColorTrc;
    public AVColorSpace ColorSpace;

    public DiracVersionInfo Version;
    public int BitDepth;
}
