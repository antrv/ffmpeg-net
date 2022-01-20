namespace Antrv.FFMpeg.Interop;

public enum AVHWFrameTransferDirection
{
    /// <summary>
    /// Transfer the data from the queried hw frame.
    /// </summary>
    AV_HWFRAME_TRANSFER_DIRECTION_FROM,

    /// <summary>
    /// Transfer the data to the queried hw frame.
    /// </summary>
    AV_HWFRAME_TRANSFER_DIRECTION_TO,
}
