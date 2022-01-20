namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVCodecParserContextFlags
{
    None = 0,
    PARSER_FLAG_COMPLETE_FRAMES = 0x0001,
    PARSER_FLAG_ONCE = 0x0002,

    /// <summary>
    /// Set if the parser has a valid file offset
    /// </summary>
    PARSER_FLAG_FETCHED_OFFSET = 0x0004,
    PARSER_FLAG_USE_CODEC_TS = 0x1000,
}
