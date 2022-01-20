﻿namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Media Type
/// </summary>
public enum AVMediaType
{
    /// <summary>
    /// Usually treated as AVMEDIA_TYPE_DATA
    /// </summary>
    AVMEDIA_TYPE_UNKNOWN = -1,
    AVMEDIA_TYPE_VIDEO,
    AVMEDIA_TYPE_AUDIO,

    /// <summary>
    /// Opaque data information usually continuous
    /// </summary>
    AVMEDIA_TYPE_DATA,
    AVMEDIA_TYPE_SUBTITLE,

    /// <summary>
    /// Opaque data information usually sparse
    /// </summary>
    AVMEDIA_TYPE_ATTACHMENT,
    AVMEDIA_TYPE_NB
}