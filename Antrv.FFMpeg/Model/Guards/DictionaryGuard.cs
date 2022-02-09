using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Guards;

internal sealed class DictionaryGuard: ResourceGuard<AVDictionary, DictionaryGuard>
{
    public DictionaryGuard()
        : base(default)
    {
    }

    public void Set(string key, string value) => LibAvUtil.av_dict_set(ref Ptr, key, value, AVDictionaryFlags.None);

    protected override void Release(Ptr<AVDictionary> ptr) => LibAvUtil.av_dict_free(ref ptr);
}
