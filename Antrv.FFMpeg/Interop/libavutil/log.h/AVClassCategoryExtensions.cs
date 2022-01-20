namespace Antrv.FFMpeg.Interop;

public static class AVClassCategoryExtensions
{
    public static bool AV_IS_INPUT_DEVICE(AVClassCategory category) =>
        category is AVClassCategory.AV_CLASS_CATEGORY_DEVICE_VIDEO_INPUT
            or AVClassCategory.AV_CLASS_CATEGORY_DEVICE_AUDIO_INPUT
            or AVClassCategory.AV_CLASS_CATEGORY_DEVICE_INPUT;

    public static bool AV_IS_OUTPUT_DEVICE(AVClassCategory category) =>
        category is AVClassCategory.AV_CLASS_CATEGORY_DEVICE_VIDEO_OUTPUT
            or AVClassCategory.AV_CLASS_CATEGORY_DEVICE_AUDIO_OUTPUT
            or AVClassCategory.AV_CLASS_CATEGORY_DEVICE_OUTPUT;
}
