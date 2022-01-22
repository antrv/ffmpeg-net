using System.Collections;
using System.Collections.Immutable;

namespace Antrv.FFMpeg.Model.Formats;

public abstract class ContainerFormatList<T>: IReadOnlyList<T>
    where T: ContainerFormat
{
    private readonly ImmutableDictionary<string, T> _dictionary;
    private readonly ImmutableList<T> _items;

    private protected ContainerFormatList(IEnumerable<T> items)
    {
        _items = items.ToImmutableList();
        _dictionary =
            (from item in _items
             from id in item.Ids
             select (Id: id, Item: item))
            .DistinctBy(x => x.Id, StringComparer.InvariantCultureIgnoreCase)
            .ToImmutableDictionary(x => x.Id, x => x.Item);

        // TODO: `matroska` format id appears twice: one for matroska video, another for matroska audio
    }

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int Count => _items.Count;

    public T this[int index] => _items[index];

    public T this[string name] => _dictionary[name];

    public bool Contains(string name) => _dictionary.ContainsKey(name);

    public bool TryGetFormat(string name, out T? format) => _dictionary.TryGetValue(name, out format);
}
