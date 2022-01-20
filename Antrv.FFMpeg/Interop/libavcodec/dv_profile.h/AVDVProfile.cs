namespace Antrv.FFMpeg.Interop;

/// <summary>
/// AVDVProfile is used to express the differences between various
/// DV flavors.For now it's primarily used for differentiating
/// 525/60 and 625/50, but the plans are to use it for various
/// DV specs as well(e.g.SMPTE314M vs. IEC 61834).
/// </summary>
public struct AVDVProfile
{
    /// <summary>
    /// value of the dsf in the DV header
    /// </summary>
    public int Dsf;

    /// <summary>
    /// stype for VAUX source pack
    /// </summary>
    public int VideoSType;

    /// <summary>
    /// total size of one frame in bytes
    /// </summary>
    public int FrameSize;

    /// <summary>
    /// number of DIF segments per DIF channel
    /// </summary>
    public int DIFSegSize;

    /// <summary>
    /// number of DIF channels per frame
    /// </summary>
    public int DIFChannelCount;

    /// <summary>
    /// 1 / framerate
    /// </summary>
    public AVRational TimeBase;

    /// <summary>
    /// FPS from the LTS standpoint
    /// </summary>
    public int LtcDivisor;

    /// <summary>
    /// picture height in pixels
    /// </summary>
    public int Height;

    /// <summary>
    /// picture width in pixels
    /// </summary>
    public int Width;

    /// <summary>
    /// sample aspect ratios for 4:3
    /// </summary>
    public AVRational SampleAspectRatio4_3;

    /// <summary>
    /// sample aspect ratios for 16:9
    /// </summary>
    public AVRational SampleAspectRatio16_9;

    /// <summary>
    /// picture pixel format
    /// </summary>
    public AVPixelFormat PixelFormat;

    /// <summary>
    /// blocks per macroblock
    /// </summary>
    public int BlocksPerMacroBlock;

    /// <summary>
    /// AC block sizes, in bits
    /// </summary>
    public Ptr<byte> BlockSizes;

    /// <summary>
    /// size of audio_shuffle table
    /// </summary>
    public int AudioStride;

    /// <summary>
    /// min amount of audio samples for 48kHz
    /// </summary>
    public int AudioMinSamples48;

    /// <summary>
    /// min amount of audio samples for 44.1kHz
    /// </summary>
    public int AudioMinSamples44_1;

    /// <summary>
    /// min amount of audio samples for 32kHz
    /// </summary>
    public int AudioMinSamples32;

    /// <summary>
    /// how many samples are supposed to be in each frame in a 5 frames window
    /// </summary>
    public Array5<int> AudioSamplesDist;

    /// <summary>
    /// PCM shuffling table
    /// </summary>
    public ConstPtr<Array9<byte>> AudioShuffle;
}
