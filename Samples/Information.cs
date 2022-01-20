using Antrv;
using Antrv.FFMpeg.Interop;

namespace Samples;

internal static class Information
{
    internal static void PrintChannelLayouts()
    {
        int index = 0;
        while (LibAvUtil.av_get_standard_channel_layout(index, out AVChannelLayout layout, out Utf8StringPtr name) == 0)
        {
            Console.WriteLine(name);
            index++;
        }
    }
}
