using System.Collections.Immutable;
using Antrv.FFMpeg.Model.Codecs;
using Antrv.FFMpeg.Model.Devices;
using Antrv.FFMpeg.Model.Formats;

namespace Antrv.FFMpeg.Model;

/// <summary>
/// Reference information.
/// </summary>
public static class Global
{
    private static ImmutableList<ChannelLayout>? _channelLayouts;
    private static CodecList? _codecs;
    private static InputFormatList? _inputFormats;
    private static OutputFormatList? _outputFormats;
    private static InputDeviceList? _inputDevices;
    private static OutputDeviceList? _outputDevices;

    /// <summary>
    /// The standard audio channel layouts
    /// </summary>
    public static ImmutableList<ChannelLayout> ChannelLayouts =>
        _channelLayouts ??= Utils.EnumerateChannelLayouts().ToImmutableList();

    /// <summary>
    /// Codec list.
    /// </summary>
    public static CodecList Codecs => _codecs ??= new CodecList();

    /// <summary>
    /// Input format list.
    /// </summary>
    public static InputFormatList InputFormats => _inputFormats ??= new InputFormatList();

    /// <summary>
    /// Output format list.
    /// </summary>
    public static OutputFormatList OutputFormats => _outputFormats ??= new OutputFormatList();

    /// <summary>
    /// The list of input devices.
    /// </summary>
    public static InputDeviceList InputDevices => _inputDevices ??= new InputDeviceList();

    /// <summary>
    /// The list of input devices.
    /// </summary>
    public static OutputDeviceList OutputDevices => _outputDevices ??= new OutputDeviceList();
}
