using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Guards;

internal sealed class DictionaryGuard: ResourceGuard<AVDictionary, DictionaryGuard>
{
    private DictionaryGuard(Ptr<AVDictionary> ptr)
        : base(ptr)
    {
    }

    public static DictionaryGuard New() => new(default);

    public void Set(string key, string value) => LibAvUtil.av_dict_set(ref Ptr, key, value, AVDictionaryFlags.None);

    protected override void Release(Ptr<AVDictionary> ptr) => LibAvUtil.av_dict_free(ref ptr);
}
