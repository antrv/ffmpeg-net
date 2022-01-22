namespace Antrv.FFMpeg.Interop;

public enum AVError
{
    OK = 0,

    /// <summary>
    /// Bitstream filter not found
    /// </summary>
    AVERROR_BSF_NOT_FOUND = -unchecked((int)(0xF8 | ((uint)'B' << 8) | ((uint)'S' << 16) | ((uint)'F' << 24))),

    /// <summary>
    /// Internal bug, also see AVERROR_BUG2
    /// </summary>
    AVERROR_BUG = -unchecked((int)('B' | ((uint)'U' << 8) | ((uint)'G' << 16) | ((uint)'!' << 24))),

    /// <summary>
    /// Buffer too small
    /// </summary>
    AVERROR_BUFFER_TOO_SMALL =
        -unchecked((int)('B' | ((uint)'U' << 8) | ((uint)'F' << 16) | ((uint)'S' << 24))),

    /// <summary>
    /// Decoder not found
    /// </summary>
    AVERROR_DECODER_NOT_FOUND =
        -unchecked((int)(0xF8 | ((uint)'D' << 8) | ((uint)'E' << 16) | ((uint)'C' << 24))),

    /// <summary>
    /// Demuxer not found
    /// </summary>
    AVERROR_DEMUXER_NOT_FOUND =
        -unchecked((int)(0xF8 | ((uint)'D' << 8) | ((uint)'E' << 16) | ((uint)'M' << 24))),

    /// <summary>
    /// Encoder not found
    /// </summary>
    AVERROR_ENCODER_NOT_FOUND =
        -unchecked((int)(0xF8 | ((uint)'E' << 8) | ((uint)'N' << 16) | ((uint)'C' << 24))),

    /// <summary>
    /// End of file
    /// </summary>
    AVERROR_EOF = -unchecked((int)('E' | ((uint)'O' << 8) | ((uint)'F' << 16) | ((uint)' ' << 24))),

    /// <summary>
    /// Immediate exit was requested; the called function should not be restarted
    /// </summary>
    AVERROR_EXIT = -unchecked((int)('E' | ((uint)'X' << 8) | ((uint)'I' << 16) | ((uint)'T' << 24))),

    /// <summary>
    /// Generic error in an external library
    /// </summary>
    AVERROR_EXTERNAL = -unchecked((int)('E' | ((uint)'X' << 8) | ((uint)'T' << 16) | ((uint)' ' << 24))),

    /// <summary>
    /// Filter not found
    /// </summary>
    AVERROR_FILTER_NOT_FOUND =
        -unchecked((int)(0xF8 | ((uint)'F' << 8) | ((uint)'I' << 16) | ((uint)'L' << 24))),

    /// <summary>
    /// Invalid data found when processing input
    /// </summary>
    AVERROR_INVALIDDATA = -unchecked((int)('I' | ((uint)'N' << 8) | ((uint)'D' << 16) | ((uint)'A' << 24))),

    /// <summary>
    /// Muxer not found
    /// </summary>
    AVERROR_MUXER_NOT_FOUND =
        -unchecked((int)(0xF8 | ((uint)'M' << 8) | ((uint)'U' << 16) | ((uint)'X' << 24))),

    /// <summary>
    /// Option not found
    /// </summary>
    AVERROR_OPTION_NOT_FOUND =
        -unchecked((int)(0xF8 | ((uint)'O' << 8) | ((uint)'P' << 16) | ((uint)'T' << 24))),

    /// <summary>
    /// Not yet implemented in FFmpeg, patches welcome
    /// </summary>
    AVERROR_PATCHWELCOME = -unchecked((int)('P' | ((uint)'A' << 8) | ((uint)'W' << 16) | ((uint)'E' << 24))),

    /// <summary>
    /// Protocol not found
    /// </summary>
    AVERROR_PROTOCOL_NOT_FOUND =
        -unchecked((int)(0xF8 | ((uint)'P' << 8) | ((uint)'R' << 16) | ((uint)'O' << 24))),

    /// <summary>
    /// Stream not found
    /// </summary>
    AVERROR_STREAM_NOT_FOUND =
        -unchecked((int)(0xF8 | ((uint)'S' << 8) | ((uint)'T' << 16) | ((uint)'R' << 24))),

    /// <summary>
    /// This is semantically identical to AVERROR_BUG, it has been introduced in Libav after our AVERROR_BUG and with a modified value.
    /// </summary>
    AVERROR_BUG2 = -unchecked((int)('B' | ((uint)'U' << 8) | ((uint)'G' << 16) | ((uint)' ' << 24))),

    /// <summary>
    /// Unknown error, typically from an external library
    /// </summary>
    AVERROR_UNKNOWN = -unchecked((int)('U' | ((uint)'N' << 8) | ((uint)'K' << 16) | ((uint)'N' << 24))),

    /// <summary>
    /// Requested feature is flagged experimental. Set strict_std_compliance if you really want to use it.
    /// </summary>
    AVERROR_EXPERIMENTAL = -0x2bb2afa8,

    /// <summary>
    /// Input changed between calls. Reconfiguration is required. (can be OR-ed with AVERROR_OUTPUT_CHANGED)
    /// </summary>
    AVERROR_INPUT_CHANGED = -0x636e6701,

    /// <summary>
    /// Output changed between calls. Reconfiguration is required. (can be OR-ed with AVERROR_INPUT_CHANGED)
    /// </summary>
    AVERROR_OUTPUT_CHANGED = -0x636e6702,

    // HTTP & RTSP errors
    AVERROR_HTTP_BAD_REQUEST =
        -unchecked((int)(0xF8 | ((uint)'4' << 8) | ((uint)'0' << 16) | ((uint)'0' << 24))),

    AVERROR_HTTP_UNAUTHORIZED =
        -unchecked((int)(0xF8 | ((uint)'4' << 8) | ((uint)'0' << 16) | ((uint)'1' << 24))),
    AVERROR_HTTP_FORBIDDEN = -unchecked((int)(0xF8 | ((uint)'4' << 8) | ((uint)'0' << 16) | ((uint)'3' << 24))),
    AVERROR_HTTP_NOT_FOUND = -unchecked((int)(0xF8 | ((uint)'4' << 8) | ((uint)'0' << 16) | ((uint)'4' << 24))),
    AVERROR_HTTP_OTHER_4XX = -unchecked((int)(0xF8 | ((uint)'4' << 8) | ((uint)'X' << 16) | ((uint)'X' << 24))),

    AVERROR_HTTP_SERVER_ERROR =
        -unchecked((int)(0xF8 | ((uint)'5' << 8) | ((uint)'X' << 16) | ((uint)'X' << 24))),
}
