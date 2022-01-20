namespace Antrv.FFMpeg.Interop;

public delegate void LogCallback(Ptr<AVClass> cl, AVLogLevel level, Utf8StringPtr format, IntPtr args);
