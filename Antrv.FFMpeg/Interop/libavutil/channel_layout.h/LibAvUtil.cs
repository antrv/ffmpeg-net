namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Return a channel layout id that matches name, or 0 if no match is found.
    /// 
    /// name can be one or several of the following notations,
    /// separated by '+' or '|':
    /// - the name of an usual channel layout (mono, stereo, 4.0, quad, 5.0,
    ///   5.0(side), 5.1, 5.1(side), 7.1, 7.1(wide), downmix);
    /// - the name of a single channel (FL, FR, FC, LFE, BL, BR, FLC, FRC, BC,
    ///   SL, SR, TC, TFL, TFC, TFR, TBL, TBC, TBR, DL, DR);
    /// - a number of channels, in decimal, followed by 'c', yielding
    ///   the default channel layout for that number of channels (@see
    ///   av_get_default_channel_layout);
    /// - a channel layout mask, in hexadecimal starting with "0x" (see the
    ///   AV_CH_* macros).
    ///
    /// Example: "stereo+FC" = "2c+FC" = "2c+1c" = "0x7"
    /// </summary>
    /// <param name="name">channel layout specification string</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVChannelLayout av_get_channel_layout([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// Return a channel layout and the number of channels based on the specified name.
    ///
    /// This function is similar to <see cref="av_get_channel_layout"/>, but can also parse
    /// unknown channel layout specifications.
    /// </summary>
    /// <param name="name">channel layout specification string</param>
    /// <param name="channelLayout">parsed channel layout (0 if unknown)</param>
    /// <param name="channels">number of channels</param>
    /// <returns>0 on success, AVERROR(EINVAL) if the parsing fails.</returns>
    [DllImport(LibraryName)]
    public static extern int av_get_extended_channel_layout([MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        out AVChannelLayout channelLayout, out int channels);

    /// <summary>
    /// Return a description of a channel layout.
    /// If <paramref name="channels"/> is &lt;= 0, it is guessed from the <paramref name="channelLayout"/>.
    /// </summary>
    /// <param name="buf">put here the string containing the channel layout</param>
    /// <param name="bufSize">size in bytes of the buffer</param>
    /// <param name="channels"></param>
    /// <param name="channelLayout"></param>
    [DllImport(LibraryName)]
    public static extern void av_get_channel_layout_string(Ptr<byte> buf, int bufSize, int channels,
        AVChannelLayout channelLayout);

    /// <summary>
    /// Append a description of a channel layout to a bprint buffer.
    /// </summary>
    /// <param name="bp"></param>
    /// <param name="channels"></param>
    /// <param name="channelLayout"></param>
    [DllImport(LibraryName)]
    public static extern void av_bprint_channel_layout(Ptr<AVBPrint> bp, int channels, AVChannelLayout channelLayout);

    /// <summary>
    /// Return the number of channels in the channel layout.
    /// </summary>
    /// <param name="channelLayout"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_get_channel_layout_nb_channels(AVChannelLayout channelLayout);

    /// <summary>
    /// Return default channel layout for a given number of channels.
    /// </summary>
    /// <param name="channels"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVChannelLayout av_get_default_channel_layout(int channels);

    /// <summary>
    /// Get the index of a <paramref name="channel"/> in <paramref name="channelLayout"/>.
    /// </summary>
    /// <param name="channelLayout"></param>
    /// <param name="channel">a channel layout describing exactly one channel
    /// which must be present in <paramref name="channelLayout"/>.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_get_channel_layout_channel_index(AVChannelLayout channelLayout,
        AVChannelLayout channel);

    /// <summary>
    /// Get the channel with the given <paramref name="index"/> in <paramref name="channelLayout"/>.
    /// </summary>
    /// <param name="channelLayout"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVChannelLayout av_channel_layout_extract_channel(AVChannelLayout channelLayout, int index);

    /// <summary>
    /// Get the name of a given channel.
    /// </summary>
    /// <param name="channel"></param>
    /// <returns>channel name on success, NULL on error.</returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_get_channel_name(AVChannelLayout channel);

    /// <summary>
    /// Get the description of a given channel.
    /// </summary>
    /// <param name="channel">a channel layout with a single channel</param>
    /// <returns>channel description on success, NULL on error</returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_get_channel_description(AVChannelLayout channel);

    /// <summary>
    /// Get the value and name of a standard channel layout.
    /// </summary>
    /// <param name="index">index in an internal list, starting at 0</param>
    /// <param name="layout">channel layout mask</param>
    /// <param name="name">name of the layout</param>
    /// <returns>0 if the layout exists, &lt;0 if index is beyond the limits</returns>
    [DllImport(LibraryName)]
    public static extern int av_get_standard_channel_layout(int index, out AVChannelLayout layout,
        out Utf8StringPtr name);
}
