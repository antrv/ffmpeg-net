namespace Antrv.FFMpeg.Model.Formats;

public sealed class OutputFormatList: ContainerFormatList<OutputFormat>
{
    internal OutputFormatList()
        : base(Utils.EnumerateOutputFormats())
    {
    }
}
