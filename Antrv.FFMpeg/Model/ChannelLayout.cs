using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model;

public class ChannelLayout
{
    internal ChannelLayout(AVChannelLayout channelLayout, string name)
    {
        Layout = channelLayout;
        Name = name;
        ChannelCount = LibAvUtil.av_get_channel_layout_nb_channels(channelLayout);
    }

    public AVChannelLayout Layout { get; }

    public string Name { get; }

    public int ChannelCount { get; }
}
