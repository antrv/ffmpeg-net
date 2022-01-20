namespace Antrv.FFMpeg.Interop;

public enum AVPacketSideDataType
{
    /// <summary>
    /// An AV_PKT_DATA_PALETTE side data packet contains exactly AVPALETTE_SIZE
    /// bytes worth of palette. This side data signals that a new palette is
    /// present.
    /// </summary>
    AV_PKT_DATA_PALETTE,

    /// <summary>
    /// The AV_PKT_DATA_NEW_EXTRADATA is used to notify the codec or the format
    /// that the extradata buffer was changed and the receiving side should
    /// act upon it appropriately. The new extradata is embedded in the side
    /// data buffer and should be immediately used for processing the current
    /// frame or packet.
    /// </summary>
    AV_PKT_DATA_NEW_EXTRADATA,

    /// <summary>
    /// An AV_PKT_DATA_PARAM_CHANGE side data packet is laid out as follows:
    ///  u32le param_flags
    ///  if (param_flags & AV_SIDE_DATA_PARAM_CHANGE_CHANNEL_COUNT)
    ///      s32le channel_count
    ///  if (param_flags & AV_SIDE_DATA_PARAM_CHANGE_CHANNEL_LAYOUT)
    ///      u64le channel_layout
    ///  if (param_flags & AV_SIDE_DATA_PARAM_CHANGE_SAMPLE_RATE)
    ///      s32le sample_rate
    ///  if (param_flags & AV_SIDE_DATA_PARAM_CHANGE_DIMENSIONS)
    ///      s32le width
    ///      s32le height
    /// </summary>
    AV_PKT_DATA_PARAM_CHANGE,

    /// <summary>
    /// An AV_PKT_DATA_H263_MB_INFO side data packet contains a number of
    /// structures with info about macroblocks relevant to splitting the
    /// packet into smaller packets on macroblock edges (e.g. as for RFC 2190).
    /// That is, it does not necessarily contain info about all macroblocks,
    /// as long as the distance between macroblocks in the info is smaller
    /// than the target payload size.
    /// Each MB info structure is 12 bytes, and is laid out as follows:
    /// u32le bit offset from the start of the packet
    /// u8    current quantizer at the start of the macroblock
    /// u8    GOB number
    /// u16le macroblock address within the GOB
    /// u8    horizontal MV predictor
    /// u8    vertical MV predictor
    /// u8    horizontal MV predictor for block number 3
    /// u8    vertical MV predictor for block number 3
    /// </summary>
    AV_PKT_DATA_H263_MB_INFO,

    /// <summary>
    /// This side data should be associated with an audio stream and contains
    /// ReplayGain information in form of the AVReplayGain struct.
    /// </summary>
    AV_PKT_DATA_REPLAYGAIN,

    /// <summary>
    /// This side data contains a 3x3 transformation matrix describing an affine
    /// transformation that needs to be applied to the decoded video frames for
    /// correct presentation.
    /// </summary>
    AV_PKT_DATA_DISPLAYMATRIX,

    /// <summary>
    /// This side data should be associated with a video stream and contains
    /// Stereoscopic 3D information in form of the AVStereo3D struct.
    /// </summary>
    AV_PKT_DATA_STEREO3D,

    /// <summary>
    /// This side data should be associated with an audio stream and corresponds
    /// to enum AVAudioServiceType.
    /// </summary>
    AV_PKT_DATA_AUDIO_SERVICE_TYPE,

    /// <summary>
    /// This side data contains quality related information from the encoder.
    /// u32le quality factor of the compressed frame. Allowed range is between 1 (good) and FF_LAMBDA_MAX (bad).
    /// u8    picture type
    /// u8    error count
    /// u16   reserved
    /// u64le[error count] sum of squared differences between encoder in and output
    /// </summary>
    AV_PKT_DATA_QUALITY_STATS,

    /// <summary>
    /// This side data contains an integer value representing the stream index
    /// of a "fallback" track.  A fallback track indicates an alternate
    /// track to use when the current track can not be decoded for some reason.
    /// e.g. no decoder available for codec.
    /// </summary>
    AV_PKT_DATA_FALLBACK_TRACK,

    /// <summary>
    /// This side data corresponds to the AVCPBProperties struct.
    /// </summary>
    AV_PKT_DATA_CPB_PROPERTIES,

    /// <summary>
    /// Recommmends skipping the specified number of samples
    /// u32le number of samples to skip from start of this packet
    /// u32le number of samples to skip from end of this packet
    /// u8    reason for start skip
    /// u8    reason for end   skip (0=padding silence, 1=convergence)
    /// </summary>
    AV_PKT_DATA_SKIP_SAMPLES,

    /// <summary>
    /// An AV_PKT_DATA_JP_DUALMONO side data packet indicates that
    /// the packet may contain "dual mono" audio specific to Japanese DTV
    /// and if it is true, recommends only the selected channel to be used.
    /// u8    selected channels (0=mail/left, 1=sub/right, 2=both)
    /// </summary>
    AV_PKT_DATA_JP_DUALMONO,

    /// <summary>
    /// A list of zero terminated key/value strings. There is no end marker for
    /// the list, so it is required to rely on the side data size to stop.
    /// </summary>
    AV_PKT_DATA_STRINGS_METADATA,

    /// <summary>
    /// Subtitle event position
    /// u32le x1
    /// u32le y1
    /// u32le x2
    /// u32le y2
    /// </summary>
    AV_PKT_DATA_SUBTITLE_POSITION,

    /// <summary>
    /// Data found in BlockAdditional element of matroska container. There is
    /// no end marker for the data, so it is required to rely on the side data
    /// size to recognize the end. 8 byte id (as found in BlockAddId) followed
    /// by data.
    /// </summary>
    AV_PKT_DATA_MATROSKA_BLOCKADDITIONAL,

    /// <summary>
    /// The optional first identifier line of a WebVTT cue.
    /// </summary>
    AV_PKT_DATA_WEBVTT_IDENTIFIER,

    /// <summary>
    /// The optional settings (rendering instructions) that immediately
    /// follow the timestamp specifier of a WebVTT cue.
    /// </summary>
    AV_PKT_DATA_WEBVTT_SETTINGS,

    /// <summary>
    /// A list of zero terminated key/value strings. There is no end marker for
    /// the list, so it is required to rely on the side data size to stop. This
    /// side data includes updated metadata which appeared in the stream.
    /// </summary>
    AV_PKT_DATA_METADATA_UPDATE,

    /// <summary>
    /// MPEGTS stream ID as uint8_t, this is required to pass the stream ID
    /// information from the demuxer to the corresponding muxer.
    /// </summary>
    AV_PKT_DATA_MPEGTS_STREAM_ID,

    /// <summary>
    /// Mastering display metadata (based on SMPTE-2086:2014). This metadata
    /// should be associated with a video stream and contains data in the form
    /// of the AVMasteringDisplayMetadata struct.
    /// </summary>
    AV_PKT_DATA_MASTERING_DISPLAY_METADATA,

    /// <summary>
    /// This side data should be associated with a video stream and corresponds
    /// to the AVSphericalMapping structure.
    /// </summary>
    AV_PKT_DATA_SPHERICAL,

    /// <summary>
    /// Content light level (based on CTA-861.3). This metadata should be
    /// associated with a video stream and contains data in the form of the
    /// AVContentLightMetadata struct.
    /// </summary>
    AV_PKT_DATA_CONTENT_LIGHT_LEVEL,

    /// <summary>
    /// ATSC A53 Part 4 Closed Captions. This metadata should be associated with
    /// a video stream. A53 CC bitstream is stored as uint8_t in AVPacketSideData.data.
    /// The number of bytes of CC data is AVPacketSideData.size.
    /// </summary>
    AV_PKT_DATA_A53_CC,

    /// <summary>
    /// This side data is encryption initialization data.
    /// The format is not part of ABI, use av_encryption_init_info_* methods to
    /// access.
    /// </summary>
    AV_PKT_DATA_ENCRYPTION_INIT_INFO,

    /// <summary>
    /// This side data contains encryption info for how to decrypt the packet.
    /// The format is not part of ABI, use av_encryption_info_* methods to access.
    /// </summary>
    AV_PKT_DATA_ENCRYPTION_INFO,

    /// <summary>
    /// Active Format Description data consisting of a single byte as specified
    /// in ETSI TS 101 154 using AVActiveFormatDescription enum.
    /// </summary>
    AV_PKT_DATA_AFD,

    /// <summary>
    /// Producer Reference Time data corresponding to the AVProducerReferenceTime struct,
    /// usually exported by some encoders (on demand through the prft flag set in the
    /// AVCodecContext export_side_data field).
    /// </summary>
    AV_PKT_DATA_PRFT,

    /// <summary>
    /// ICC profile data consisting of an opaque octet buffer following the
    /// format described by ISO 15076-1.
    /// </summary>
    AV_PKT_DATA_ICC_PROFILE,

    /// <summary>
    /// DOVI configuration
    /// dolby-vision-bitstreams-within-the-iso-base-media-file-format-v2.1.2, section 2.2
    /// dolby-vision-bitstreams-in-mpeg-2-transport-stream-multiplex-v1.2, section 3.3
    /// Tags are stored in struct AVDOVIDecoderConfigurationRecord.
    /// </summary>
    AV_PKT_DATA_DOVI_CONF,

    /// <summary>
    /// Timecode which conforms to SMPTE ST 12-1:2014. The data is an array of 4 uint32_t
    /// where the first uint32_t describes how many (1-3) of the other timecodes are used.
    /// The timecode format is described in the documentation of av_timecode_get_smpte_from_framenum()
    /// function in libavutil/timecode.h.
    /// </summary>
    AV_PKT_DATA_S12M_TIMECODE,

    /// <summary>
    /// HDR10+ dynamic metadata associated with a video frame. The metadata is in
    /// the form of the AVDynamicHDRPlus struct and contains
    /// information for color volume transform - application 4 of
    /// SMPTE 2094-40:2016 standard.
    /// </summary>
    AV_PKT_DATA_DYNAMIC_HDR10_PLUS,

    [Obsolete]
    AV_PKT_DATA_QUALITY_FACTOR = AV_PKT_DATA_QUALITY_STATS
}
