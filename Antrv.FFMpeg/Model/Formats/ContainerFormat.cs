using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Formats;

/// <summary>
/// Base class for the description of a media container (media file) format.
/// </summary>
public abstract class ContainerFormat
{
    private protected ContainerFormat(ConstPtr<AVInputFormat> ptr)
    {
        string shortNames = ptr.Ref.Name.ToString();
        Name = ptr.Ref.LongName.ToString();
        FullName = shortNames + " - " + Name;
        ShortNames = ptr.Ref.Name.Split(',');
        MimeTypes = ptr.Ref.MimeTypes.Split(',');
        Extensions = ptr.Ref.Extensions.Split(',');
        Flags = ptr.Ref.Flags;
    }

    private protected ContainerFormat(ConstPtr<AVOutputFormat> ptr)
    {
        string shortNames = ptr.Ref.Name.ToString();
        Name = ptr.Ref.LongName.ToString();
        FullName = shortNames + " - " + Name;
        ShortNames = ptr.Ref.Name.Split(',');
        MimeTypes = ImmutableList.Create(ptr.Ref.MimeType.ToString());
        Extensions = ptr.Ref.Extensions.Split(',');
        Flags = ptr.Ref.Flags;
    }

    public IReadOnlyList<string> ShortNames { get; }

    public string Name { get; }

    public string FullName { get; }

    public IReadOnlyList<string> MimeTypes { get; }

    public IReadOnlyList<string> Extensions { get; }

    public AVFormatFlags Flags { get; }

    public override string ToString() => FullName;
}
