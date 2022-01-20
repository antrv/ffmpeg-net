namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Describes single entry of the directory.
///
/// Only name and type fields are guaranteed be set.
/// Rest of fields are protocol or/and platform dependent and might be unknown.
/// </summary>
public struct AVIODirEntry
{
    /// <summary>
    /// Filename
    /// </summary>
    public Utf8StringPtr Name;

    /// <summary>
    /// Type of the entry
    /// </summary>
    public AVIODirEntryType Type;

    /// <summary>
    /// Set to 1 when name is encoded with UTF-8, 0 otherwise.
    /// Name can be encoded with UTF-8 even though 0 is set.
    /// </summary>
    public int Utf8;

    /// <summary>
    /// File size in bytes, -1 if unknown.
    /// </summary>
    public long Size;

    /// <summary>
    /// Time of last modification in microseconds since unix epoch, -1 if unknown.
    /// </summary>
    public long ModificationTimestamp;

    /// <summary>
    /// Time of last access in microseconds since unix epoch, -1 if unknown.
    /// </summary>
    public long AccessTimestamp;

    /// <summary>
    /// Time of last status change in microseconds since unix epoch, -1 if unknown.
    /// </summary>
    public long StatusChangeTimestamp;

    /// <summary>
    /// User ID of owner, -1 if unknown.
    /// </summary>
    public long UserId;

    /// <summary>
    /// Group ID of owner, -1 if unknown.
    /// </summary>
    public long GroupId;

    /// <summary>
    /// Unix file mode, -1 if unknown.
    /// </summary>
    public long FileMode;
}
