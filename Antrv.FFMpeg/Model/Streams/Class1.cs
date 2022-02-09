using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Codecs;
using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Streams;

public interface IStream
{
    AVMediaType MediaType { get; }
    AVRational TimeBase { get; }
    StreamParameters Parameters { get; }
}

public interface IStream<out TParameters>: IStream
    where TParameters: StreamParameters
{
    new TParameters Parameters { get; }
}

public interface IEncodedStream: IStream
{
    Codec Codec { get; }
}

public interface IRawStream: IStream
{
}

public interface IVideoStream: IStream<VideoParameters>
{
}

public interface IAudioStream: IStream<AudioParameters>
{
}

public interface ISubtitleStream: IStream<SubtitleParameters>
{
}

public interface IAttachmentStream: IStream<AttachmentParameters>
{
}

public interface IDataStream: IStream<DataParameters>
{
}
