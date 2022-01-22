namespace Antrv.FFMpeg.Model.Formats;

public sealed class InputFormatList: ContainerFormatList<InputFormat>
{
    internal InputFormatList()
        : base(Utils.EnumerateInputFormats())
    {
    }
}
