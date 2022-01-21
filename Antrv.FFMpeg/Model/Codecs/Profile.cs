namespace Antrv.FFMpeg.Model.Codecs;

public readonly struct Profile
{
    internal Profile(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }

    public string Name { get; }
}
