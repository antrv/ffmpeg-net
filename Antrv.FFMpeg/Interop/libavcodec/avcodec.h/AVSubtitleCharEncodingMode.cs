namespace Antrv.FFMpeg.Interop;

public enum AVSubtitleCharEncodingMode
{
    /// <summary>
    /// do nothing (demuxer outputs a stream supposed to be already in UTF-8, or the codec is bitmap for instance)
    /// </summary>
    FF_SUB_CHARENC_MODE_DO_NOTHING = -1,

    /// <summary>
    /// libavcodec will select the mode itself
    /// </summary>
    FF_SUB_CHARENC_MODE_AUTOMATIC = 0,

    /// <summary>
    /// the AVPacket data needs to be recoded to UTF-8 before being fed to the decoder, requires iconv
    /// </summary>
    FF_SUB_CHARENC_MODE_PRE_DECODER = 1,

    /// <summary>
    /// neither convert the subtitles, nor check them for valid UTF-8
    /// </summary>
    FF_SUB_CHARENC_MODE_IGNORE = 2,
}
