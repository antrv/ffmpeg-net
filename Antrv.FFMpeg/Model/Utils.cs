﻿using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Formats;

namespace Antrv.FFMpeg.Model;

internal static class Utils
{
    internal static ImmutableList<T> CreateList<T>(this ConstPtr<T> ptr, Func<ConstPtr<T>, bool> predicate)
        where T: unmanaged => IncrementingSequence(ptr, predicate).Select(p => p.Ref).ToImmutableList();

    internal static IEnumerable<ConstPtr<T>> IncrementingSequence<T>(this ConstPtr<T> ptr, Func<ConstPtr<T>, bool> predicate)
        where T : unmanaged
    {
        if (ptr)
        {
            ConstPtr<T> p = ptr;
            while (predicate(p))
            {
                yield return p;
                ++p;
            }
        }
    }

    internal static ImmutableList<string> Split(this Utf8StringPtr ptr, char separator)
    {
        if (!ptr)
            return ImmutableList<string>.Empty;

        string str = ptr.ToString();
        if (string.IsNullOrWhiteSpace(str))
            return ImmutableList<string>.Empty;

        return str.Split(separator).ToImmutableList();
    }

    internal static IEnumerable<ConstPtr<AVCodec>> EnumerateCodecs()
    {
        IntPtr opaque = IntPtr.Zero;
        ConstPtr<AVCodec> ptr;
        while (!(ptr = LibAvCodec.av_codec_iterate(ref opaque)).IsNull)
            yield return ptr;
    }
    
    internal static IEnumerable<ConstPtr<AVCodecDescriptor>> EnumerateCodecDescriptors()
    {
        for (ConstPtr<AVCodecDescriptor> ptr = LibAvCodec.avcodec_descriptor_next(default);
             !ptr.IsNull;
             ptr = LibAvCodec.avcodec_descriptor_next(ptr))
        {
            yield return ptr;
        }
    }

    internal static IEnumerable<InputFormat> EnumerateInputFormats()
    {
        IntPtr opaque = IntPtr.Zero;
        ConstPtr<AVInputFormat> format;
        while (!(format = LibAvFormat.av_demuxer_iterate(ref opaque)).IsNull)
            yield return new InputFormat(format);
    }

    internal static IEnumerable<OutputFormat> EnumerateOutputFormats()
    {
        IntPtr opaque = IntPtr.Zero;
        ConstPtr<AVOutputFormat> format;
        while (!(format = LibAvFormat.av_muxer_iterate(ref opaque)).IsNull)
            yield return new OutputFormat(format);
    }

    internal static IEnumerable<ChannelLayout> EnumerateChannelLayouts()
    {
        int index = 0;
        while (LibAvUtil.av_get_standard_channel_layout(index, out AVChannelLayout layout, out Utf8StringPtr name) == 0)
        {
            yield return new ChannelLayout(layout, name.ToString());
            index++;
        }
    }
}