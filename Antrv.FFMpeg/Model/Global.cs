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
    private static ImmutableList<InputFormat>? _inputFormats;
    private static ImmutableList<OutputFormat>? _outputFormats;
    private static InputDeviceTypeList? _inputDeviceTypes;
    private static OutputDeviceTypeList? _outputDeviceTypes;

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
    public static ImmutableList<InputFormat> InputFormats =>
        _inputFormats ??= Utils.EnumerateInputFormats().ToImmutableList();

    /// <summary>
    /// Output format list.
    /// </summary>
    public static ImmutableList<OutputFormat> OutputFormats =>
        _outputFormats ??= Utils.EnumerateOutputFormats().ToImmutableList();

    /// <summary>
    /// The list of input devices.
    /// </summary>
    public static InputDeviceTypeList InputDeviceTypes => _inputDeviceTypes ??= new InputDeviceTypeList();

    /// <summary>
    /// The list of input devices.
    /// </summary>
    public static OutputDeviceTypeList OutputDeviceTypes => _outputDeviceTypes ??= new OutputDeviceTypeList();
}
