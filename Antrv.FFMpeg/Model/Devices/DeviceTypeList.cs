using System.Collections;
using System.Collections.Immutable;
using Antrv.FFMpeg.Model.Formats;

namespace Antrv.FFMpeg.Model.Devices;

public abstract class DeviceTypeList<T, TAudio, TVideo>: IReadOnlyList<T>
    where T: ContainerFormat
    where TAudio: T
    where TVideo: T
{
    private readonly ImmutableList<T> _devices;
    private readonly ImmutableList<TAudio> _audioDeviceTypes;
    private readonly ImmutableList<TVideo> _videoDeviceTypes;

    private protected DeviceTypeList(ImmutableList<TAudio> audioDeviceTypes, ImmutableList<TVideo> videoDeviceTypes)
    {
        _audioDeviceTypes = audioDeviceTypes;
        _videoDeviceTypes = videoDeviceTypes;
        _devices = videoDeviceTypes.Cast<T>().Concat(audioDeviceTypes).ToImmutableList();
    }

    // TODO: refactor devices, some devices can support audio and video
    public ImmutableList<TAudio> AudioDeviceTypes => _audioDeviceTypes;

    public ImmutableList<TVideo> VideoDeviceTypes => _videoDeviceTypes;

    public IEnumerator<T> GetEnumerator() => _devices.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int Count => _devices.Count;

    public T this[int index] => _devices[index];
}
