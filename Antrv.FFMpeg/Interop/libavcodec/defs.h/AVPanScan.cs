namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Pan Scan area.
/// This specifies the area which should be displayed.
/// Note there may be multiple such areas for one frame.
/// </summary>
public struct AVPanScan
{
    /// <summary>
    /// id
    /// - encoding: Set by user.
    /// - decoding: Set by libavcodec.
    /// </summary>
    public int Id;

    /// <summary>
    /// width in 1/16 pel
    /// encoding: Set by user.
    /// decoding: Set by libavcodec.
    /// </summary>
    public int Width;

    /// <summary>
    /// height in 1/16 pel
    /// encoding: Set by user.
    /// decoding: Set by libavcodec.
    /// </summary>
    public int Height;

    /// <summary>
    /// position of the top left corner in 1/16 pel for up to 3 fields/frames
    /// - encoding: Set by user.
    /// - decoding: Set by libavcodec.
    /// </summary>
    public Array3<Array2<short>> Position;
}
