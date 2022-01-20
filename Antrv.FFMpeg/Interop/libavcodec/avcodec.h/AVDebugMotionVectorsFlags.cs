namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVDebugMotionVectorsFlags
{
    None = 0,

    /// <summary>
    /// visualize forward predicted MVs of P frames
    /// </summary>
    FF_DEBUG_VIS_MV_P_FOR = 0x00000001,

    /// <summary>
    /// visualize forward predicted MVs of B frames
    /// </summary>
    FF_DEBUG_VIS_MV_B_FOR = 0x00000002,

    /// <summary>
    /// visualize backward predicted MVs of B frames
    /// </summary>
    FF_DEBUG_VIS_MV_B_BACK = 0x00000004
}
