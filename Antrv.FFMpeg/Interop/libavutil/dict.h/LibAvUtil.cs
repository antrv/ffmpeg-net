namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Get a dictionary entry with matching key.
    ///
    /// The returned entry key or value must not be changed, or it will cause undefined behavior.
    ///
    /// To iterate through all the dictionary entries, you can set the matching key
    /// to the null string "" and set the AV_DICT_IGNORE_SUFFIX flag.
    /// </summary>
    /// <param name="m"></param>
    /// <param name="key">matching key</param>
    /// <param name="prev">Set to the previous matching element to find the next.
    /// If set to NULL the first matching element is returned.</param>
    /// <param name="flags">a collection of AV_DICT_* flags controlling how the entry is retrieved</param>
    /// <returns>found entry or NULL in case no matching entry was found in the dictionary</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVDictionaryEntry> av_dict_get(ConstPtr<AVDictionary> m,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string key, ConstPtr<AVDictionaryEntry> prev, AVDictionaryFlags flags);

    /// <summary>
    /// Get number of entries in dictionary.
    /// </summary>
    /// <param name="m">dictionary</param>
    /// <returns>number of entries in dictionary</returns>
    [DllImport(LibraryName)]
    public static extern int av_dict_count(ConstPtr<AVDictionary> m);

    /// <summary>
    /// Set the given entry in *pm, overwriting an existing entry.
    ///
    /// Note: If AV_DICT_DONT_STRDUP_KEY or AV_DICT_DONT_STRDUP_VAL is set,
    /// these arguments will be freed on error.
    ///
    /// Warning: Adding a new entry to a dictionary invalidates all existing entries
    /// previously returned with av_dict_get.
    /// </summary>
    /// <param name="pm">pointer to a pointer to a dictionary struct. If *pm is NULL
    /// a dictionary struct is allocated and put in *pm.</param>
    /// <param name="key">entry key to add to *pm (will either be av_strduped or added as a new key depending on flags)</param>
    /// <param name="value">entry value to add to *pm (will be av_strduped or added as a new key depending on flags).
    /// Passing a NULL value will cause an existing entry to be deleted.</param>
    /// <param name="flags">&gt;= 0 on success otherwise an error code &lt;0</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_dict_set(ref Ptr<AVDictionary> pm, [MarshalAs(UnmanagedType.LPUTF8Str)] string key,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string? value, AVDictionaryFlags flags);

    /// <summary>
    /// Convenience wrapper for av_dict_set that converts the value to a string
    /// and stores it.
    ///
    /// Note: If AV_DICT_DONT_STRDUP_KEY is set, key will be freed on error.
    /// </summary>
    /// <param name="pm"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_dict_set_int(ref Ptr<AVDictionary> pm, [MarshalAs(UnmanagedType.LPUTF8Str)] string key,
        long value, AVDictionaryFlags flags);

    /// <summary>
    /// Parse the key/value pairs list and add the parsed entries to a dictionary.
    ///
    /// In case of failure, all the successfully set entries are stored in *pm.
    /// You may need to manually free the created dictionary.
    /// </summary>
    /// <param name="pm"></param>
    /// <param name="key"></param>
    /// <param name="keyValueSeparator">a 0-terminated list of characters used to separate key from value</param>
    /// <param name="pairSeparator">a 0-terminated list of characters used to separate two pairs from each other</param>
    /// <param name="flags">flags to use when adding to dictionary.
    /// AV_DICT_DONT_STRDUP_KEY and AV_DICT_DONT_STRDUP_VAL
    /// are ignored since the key/value tokens will always be duplicated.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_dict_parse_string(ref Ptr<AVDictionary> pm,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string key, [MarshalAs(UnmanagedType.LPUTF8Str)] string keyValueSeparator,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string pairSeparator, AVDictionaryFlags flags);

    /// <summary>
    /// Copy entries from one AVDictionary struct into another.
    /// </summary>
    /// <param name="dst">pointer to a pointer to a AVDictionary struct. If *dst is NULL,
    /// this function will allocate a struct for you and put it in *dst</param>
    /// <param name="src">pointer to source AVDictionary struct</param>
    /// <param name="flags">flags to use when setting entries in *dst</param>
    /// <returns>0 on success, negative AVERROR code on failure. If dst was allocated
    /// by this function, callers should free the associated memory.</returns>
    [DllImport(LibraryName)]
    public static extern int av_dict_copy(ref Ptr<AVDictionary> dst, ConstPtr<AVDictionary> src,
        AVDictionaryFlags flags);

    /// <summary>
    /// Free all the memory allocated for an AVDictionary struct and all keys and values.
    /// </summary>
    /// <param name="m"></param>
    [DllImport(LibraryName)]
    public static extern void av_dict_free(ref Ptr<AVDictionary> m);

    /// <summary>
    /// Get dictionary entries as a string.
    ///
    /// Create a string containing dictionary's entries.
    /// Such string may be passed back to av_dict_parse_string().
    /// String is escaped with backslashes ('\').
    /// Separators cannot be neither '\\' nor '\0'. They also cannot be the same.
    /// </summary>
    /// <param name="m">dictionary</param>
    /// <param name="buffer">Pointer to buffer that will be allocated with string containing entries.
    /// Buffer must be freed by the caller when is no longer needed.</param>
    /// <param name="keyValueSeparator">character used to separate key from value</param>
    /// <param name="pairSeparator">character used to separate two pairs from each other</param>
    /// <returns>&gt;= 0 on success, negative on error</returns>
    [DllImport(LibraryName)]
    public static extern int av_dict_get_string(ConstPtr<AVDictionary> m, out Utf8StringPtr buffer,
        byte keyValueSeparator, byte pairSeparator);
}
