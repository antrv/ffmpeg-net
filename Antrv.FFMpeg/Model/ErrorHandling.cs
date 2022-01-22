using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model;

internal static class ErrorHandling
{
    internal static void ThrowOnError(this int returnCode, string errorMessage)
    {
        if (returnCode < 0)
        {
            string? errorText = GetError(returnCode);
            string message = string.IsNullOrWhiteSpace(errorText)
                ? $"{errorMessage} ({returnCode:X8})"
                : $"{errorMessage}: {errorText} ({returnCode:X8})";

            throw new InvalidOperationException(message);
        }
    }

    private static string? GetError(int error)
    {
        Array64<byte> buffer = default;
        Ptr<byte> ptr = Ptr.FromRef(ref buffer[0]);
        return LibAvUtil.av_strerror(error, ptr, (nuint)buffer.Size) == 0 ? ((Utf8StringPtr)ptr).ToString() : null;
    }
}
