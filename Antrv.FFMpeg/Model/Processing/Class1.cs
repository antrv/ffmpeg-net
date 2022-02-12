using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Processing;

public interface IStream<out TParameters>: IStream
    where TParameters: StreamParameters
{
    new TParameters Parameters { get; }
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
