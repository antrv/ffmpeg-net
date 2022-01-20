namespace Antrv.FFMpeg.Interop;

/// <summary>
/// New fields can be added to the end with minor version bumps.
/// Removal, reordering and changes to existing fields require a major version bump.
/// sizeof(AVProgram) must not be used outside libav*.
/// </summary>
public struct AVProgram
{
    public int Id;
    public AVProgramFlags Flags;

    /// <summary>
    /// selects which program to discard and which to feed to the caller
    /// </summary>
    public AVDiscard Discard;

    public Ptr<uint> StreamIndex;
    public uint StreamIndexCount;
    public Ptr<AVDictionary> Metadata;

    public int ProgramNum;
    public int PmtPid;
    public int PcrPid;
    public int PmtVersion;

    //****************************************************************
    // All fields below this line are not part of the public API. They
    // may not be used outside of libavformat and can be changed and
    // removed at will.
    // New public fields should be added right above.
    //****************************************************************
}
