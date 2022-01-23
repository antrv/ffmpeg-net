using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Codecs;
using Antrv.FFMpeg.Model.Devices;
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

    internal static IEnumerable<ConstPtr<AVChapter>> EnumerableChapters(this Ptr<Ptr<AVChapter>> ptr, int count)
    {
        for (int i = 0; i < count; i++)
            yield return ptr[i];
    }

    internal static ImmutableDictionary<string, string> ToImmutableDictionary(this Ptr<AVDictionary> ptr)
    {
        if (ptr)
        {
            ImmutableDictionary<string, string>.Builder builder = ImmutableDictionary.CreateBuilder<string, string>();
            for (Ptr<AVDictionaryEntry> entry = LibAvUtil.av_dict_get(ptr, string.Empty, default,
                     AVDictionaryFlags.AV_DICT_IGNORE_SUFFIX);
                 entry;
                 entry = LibAvUtil.av_dict_get(ptr, string.Empty, entry, AVDictionaryFlags.AV_DICT_IGNORE_SUFFIX))
            {
                builder.Add(entry.Ref.Key.ToString(), entry.Ref.Value.ToString());
            }
            return builder.ToImmutable();
        }

        return ImmutableDictionary<string, string>.Empty;
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

    internal static IEnumerable<InputDevice> EnumerateInputDevices() =>
        EnumerateDevices<AVInputFormat>(LibAvDevice.av_input_audio_device_next).
            Concat(EnumerateDevices<AVInputFormat>(LibAvDevice.av_input_video_device_next)).
            Distinct().
            Select(x => new InputDevice(x));

    internal static IEnumerable<OutputDevice> EnumerateOutputDevices() =>
        EnumerateDevices<AVOutputFormat>(LibAvDevice.av_output_audio_device_next).
            Concat(EnumerateDevices<AVOutputFormat>(LibAvDevice.av_output_video_device_next)).
            Distinct().
            Select(x => new OutputDevice(x));

    internal static ImmutableList<Profile> CreateProfileList(this ConstPtr<AVProfile> ptr) =>
        ptr.IncrementingSequence(x => x.Ref.Profile != AVProfileId.FF_PROFILE_UNKNOWN)
            .Select(x => new Profile((int)x.Ref.Profile, x.Ref.Name.ToString())).ToImmutableList();

    internal static ImmutableList<string> CreateStringList(this ConstPtr<Utf8StringPtr> ptr) => ptr
        .IncrementingSequence(x => !x.Ref.IsNull)
        .Select(x => x.Ref.ToString()).ToImmutableList();

    internal static (ImmutableList<DevicePointInfo>, int) GetDeviceList(ConstPtr<AVDeviceInfoList> ptr)
    {
        int defaultDeviceIndex = -1;
        ImmutableList<DevicePointInfo>.Builder builder = ImmutableList.CreateBuilder<DevicePointInfo>();

        if (ptr)
        {
            int count = ptr.Ref.DeviceCount;
            if (count > 0)
            {
                defaultDeviceIndex = ptr.Ref.DefaultDevice;
                count = ptr.Ref.DeviceCount;
                for (int i = 0; i < count; i++)
                {
                    Ptr<AVDeviceInfo> devicePtr = ptr.Ref.Devices[i];

                    ImmutableList<AVMediaType> mediaTypes = ImmutableList<AVMediaType>.Empty;
                    int mediaTypeCount = devicePtr.Ref.MediaTypeCount;
                    if (mediaTypeCount > 0)
                    {
                        ImmutableList<AVMediaType>.Builder mediaBuilder = ImmutableList.CreateBuilder<AVMediaType>();
                        for (int j = 0; j < mediaTypeCount; j++)
                            mediaBuilder.Add(devicePtr.Ref.MediaTypes[j]);

                        mediaTypes = mediaBuilder.ToImmutable();
                    }

                    builder.Add(new DevicePointInfo(devicePtr.Ref.DeviceName.ToString(),
                        devicePtr.Ref.DeviceDescription.ToString(), mediaTypes));
                }
            }
        }

        return (builder.ToImmutable(), defaultDeviceIndex);
    }

    private static IEnumerable<ConstPtr<T>> EnumerateDevices<T>(Func<ConstPtr<T>, ConstPtr<T>> next)
        where T: unmanaged
    {
        DeviceInitializationHelper.Initialize();
        for (ConstPtr<T> ptr = next(default); !ptr.IsNull; ptr = next(ptr))
            yield return ptr;
    }
}
