namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Show the obj options.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="avLogObj">log context to use for showing the options</param>
    /// <param name="reqFlags">requested flags for the options to show. Show only the options for which it is opt->flags & req_flags.</param>
    /// <param name="rejFlags">rejected flags for the options to show. Show only the options for which it is !(opt->flags & req_flags).</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_show2(IntPtr obj, IntPtr avLogObj, int reqFlags, int rejFlags);

    /// <summary>
    /// Set the values of all AVOption fields to their default values.
    /// an AVOption-enabled struct (its first member must be a pointer to AVClass)
    /// </summary>
    /// <param name="s"></param>
    [DllImport(LibraryName)]
    public static extern void av_opt_set_defaults(IntPtr s);

    /// <summary>
    /// Set the values of all AVOption fields to their default values. Only these
    /// AVOption fields for which (opt->flags & mask) == flags will have their
    /// default applied to s.
    /// </summary>
    /// <param name="s">an AVOption-enabled struct (its first member must be a pointer to AVClass)</param>
    /// <param name="mask"></param>
    /// <param name="flags"></param>
    [DllImport(LibraryName)]
    public static extern void av_opt_set_defaults2(IntPtr s, AVOptionFlags mask, AVOptionFlags flags);

    /// <summary>
    /// Parse the key/value pairs list in opts. For each key/value pair
    /// found, stores the value in the field in ctx that is named like the
    /// key. ctx must be an AVClass context, storing is done using AVOptions.
    /// </summary>
    /// <param name="ctx"></param>
    /// <param name="opts">options string to parse, may be NULL</param>
    /// <param name="keyValSep">a 0-terminated list of characters used to separate key from value</param>
    /// <param name="pairsSep">a 0-terminated list of characters used to separate two pairs from each other</param>
    /// <returns>the number of successfully set key/value pairs, or a negative
    /// value corresponding to an AVERROR code in case of error:
    /// AVERROR(EINVAL) if opts cannot be parsed,
    /// the error code issued by av_opt_set() if a key/value pair cannot be set</returns>
    [DllImport(LibraryName)]
    public static extern int av_set_options_string(IntPtr ctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string opts,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string keyValSep,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string pairsSep);

    /// <summary>
    /// Parse the key-value pairs list in opts. For each key=value pair found,
    /// set the value of the corresponding option in ctx.
    ///
    /// Options names must use only the following characters: a-z A-Z 0-9 - . / _
    /// Separators must use characters distinct from option names and from each other.
    /// </summary>
    /// <param name="ctx">the AVClass object to set options on</param>
    /// <param name="opts">the options string, key-value pairs separated by a delimiter</param>
    /// <param name="shorthand">a NULL-terminated array of options names for shorthand
    /// notation: if the first field in opts has no key part,
    /// the key is taken from the first element of shorthand;
    /// then again for the second, etc., until either opts is
    /// finished, shorthand is finished or a named option is
    /// found; after that, all options must be named</param>
    /// <param name="keyValSep">a 0-terminated list of characters used to separate key from value, for example '='</param>
    /// <param name="pairsSep">a 0-terminated list of characters used to separate
    /// two pairs from each other, for example ':' or ','</param>
    /// <returns>the number of successfully set key=value pairs, or a negative
    /// value corresponding to an AVERROR code in case of error:
    /// AVERROR(EINVAL) if opts cannot be parsed,
    /// the error code issued by av_set_string3() if a key/value pair cannot be set
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set_from_string(IntPtr ctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string opts,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)]
        string[] shorthand, [MarshalAs(UnmanagedType.LPUTF8Str)] string keyValSep,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string pairsSep);

    /// <summary>
    /// Free all allocated objects in obj.
    /// </summary>
    /// <param name="obj"></param>
    [DllImport(LibraryName)]
    public static extern void av_opt_free(IntPtr obj);

    /// <summary>
    /// Check whether a particular flag is set in a flags field.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="fieldName">the name of the flag field option</param>
    /// <param name="flagName">the name of the flag to check</param>
    /// <returns>non-zero if the flag is set, zero if the flag isn't set,
    /// isn't of the right type, or the flags field doesn't exist.</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_flag_is_set(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string fieldName,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string flagName);

    /// <summary>
    /// Set all the options from a given dictionary on an object.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to AVClass</param>
    /// <param name="options">options to process. This dictionary will be freed and replaced
    /// by a new one containing all options not found in obj.
    /// Of course this new dictionary needs to be freed by caller with av_dict_free().</param>
    /// <returns>0 on success, a negative AVERROR if some option was found in obj, but could not be set.</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set_dict(IntPtr obj, ref Ptr<AVDictionary> options);

    /// <summary>
    /// Set all the options from a given dictionary on an object.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to AVClass</param>
    /// <param name="options">options to process. This dictionary will be freed and replaced
    /// by a new one containing all options not found in obj.
    /// Of course this new dictionary needs to be freed by caller with av_dict_free().</param>
    /// <param name="searchFlags"></param>
    /// <returns>0 on success, a negative AVERROR if some option was found in obj, but could not be set.</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set_dict2(IntPtr obj, ref Ptr<AVDictionary> options,
        AVOptionSearchFlags searchFlags);

    /// <summary>
    /// Extract a key-value pair from the beginning of a string.
    /// </summary>
    /// <param name="opts">pointer to the options string, will be updated to
    /// point to the rest of the string (one of the pairs_sep or the final NUL)</param>
    /// <param name="keyValSep">a 0-terminated list of characters used to separate key from value, for example '='</param>
    /// <param name="pairSep">a 0-terminated list of characters used to separate two pairs from each other, for example ':' or ','</param>
    /// <param name="flags">flags; see the AV_OPT_FLAG_* values below</param>
    /// <param name="rKey">parsed key; must be freed using av_free()</param>
    /// <param name="rVal">parsed value; must be freed using av_free()</param>
    /// <returns>>=0 for success, or a negative value corresponding to an
    /// AVERROR code in case of error; in particular:
    /// AVERROR(EINVAL) if no key is present</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_get_key_value(ref Utf8StringPtr opts,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string keyValSep, [MarshalAs(UnmanagedType.LPUTF8Str)] string pairSep,
        AVOptionParseFlags flags, out Utf8StringPtr rKey, out Utf8StringPtr rVal);

    /// <summary>
    /// This group of functions can be used to evaluate option strings
    /// and get numbers out of them. They do the same thing as av_opt_set(),
    /// except the result is written into the caller-supplied pointer.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to AVClass.</param>
    /// <param name="o">an option for which the string is to be evaluated.</param>
    /// <param name="val">string to be evaluated.</param>
    /// <param name="flagsOut">value of the string will be written here.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_eval_flags(IntPtr obj, ConstPtr<AVOption> o,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string val, out int flagsOut);

    /// <summary>
    /// This group of functions can be used to evaluate option strings
    /// and get numbers out of them. They do the same thing as av_opt_set(),
    /// except the result is written into the caller-supplied pointer.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to AVClass.</param>
    /// <param name="o">an option for which the string is to be evaluated.</param>
    /// <param name="val">string to be evaluated.</param>
    /// <param name="intOut">value of the string will be written here.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_eval_int(IntPtr obj, ConstPtr<AVOption> o,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string val, out int intOut);

    /// <summary>
    /// This group of functions can be used to evaluate option strings
    /// and get numbers out of them. They do the same thing as av_opt_set(),
    /// except the result is written into the caller-supplied pointer.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to AVClass.</param>
    /// <param name="o">an option for which the string is to be evaluated.</param>
    /// <param name="val">string to be evaluated.</param>
    /// <param name="int64Out">value of the string will be written here.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_eval_int64(IntPtr obj, ConstPtr<AVOption> o,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string val, out long int64Out);

    /// <summary>
    /// This group of functions can be used to evaluate option strings
    /// and get numbers out of them. They do the same thing as av_opt_set(),
    /// except the result is written into the caller-supplied pointer.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to AVClass.</param>
    /// <param name="o">an option for which the string is to be evaluated.</param>
    /// <param name="val">string to be evaluated.</param>
    /// <param name="floatOut">value of the string will be written here.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_eval_float(IntPtr obj, ConstPtr<AVOption> o,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string val, out float floatOut);

    /// <summary>
    /// This group of functions can be used to evaluate option strings
    /// and get numbers out of them. They do the same thing as av_opt_set(),
    /// except the result is written into the caller-supplied pointer.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to AVClass.</param>
    /// <param name="o">an option for which the string is to be evaluated.</param>
    /// <param name="val">string to be evaluated.</param>
    /// <param name="doubleOut">value of the string will be written here.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_eval_double(IntPtr obj, ConstPtr<AVOption> o,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string val, out double doubleOut);

    /// <summary>
    /// This group of functions can be used to evaluate option strings
    /// and get numbers out of them. They do the same thing as av_opt_set(),
    /// except the result is written into the caller-supplied pointer.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to AVClass.</param>
    /// <param name="o">an option for which the string is to be evaluated.</param>
    /// <param name="val">string to be evaluated.</param>
    /// <param name="qOut">value of the string will be written here.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_eval_q(IntPtr obj, ConstPtr<AVOption> o,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string val, out AVRational qOut);

    /// <summary>
    /// Look for an option in an object. Consider only options which have all the specified flags set.
    /// 
    /// Note: Options found with AV_OPT_SEARCH_CHILDREN flag may not be settable
    /// directly with av_opt_set(). Use special calls which take an options
    /// AVDictionary (e.g. avformat_open_input()) to set options found with this flag.
    /// </summary>
    /// <param name="obj">A pointer to a struct whose first element is a pointer to an AVClass.
    /// Alternatively a double pointer to an AVClass, if AV_OPT_SEARCH_FAKE_OBJ search flag is set.</param>
    /// <param name="name">The name of the option to look for.</param>
    /// <param name="unit">When searching for named constants, name of the unit it belongs to.</param>
    /// <param name="optFlags">Find only options with all the specified flags set (AV_OPT_FLAG).</param>
    /// <param name="searchFlags">A combination of AV_OPT_SEARCH_*.</param>
    /// <returns>A pointer to the option found, or NULL if no option was found.</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVOption> av_opt_find(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string unit, AVOptionFlags optFlags, AVOptionSearchFlags searchFlags);

    /// <summary>
    /// Look for an option in an object. Consider only options which have all the specified flags set.
    /// </summary>
    /// <param name="obj">A pointer to a struct whose first element is a pointer to an AVClass.
    /// Alternatively a double pointer to an AVClass, if AV_OPT_SEARCH_FAKE_OBJ search flag is set.</param>
    /// <param name="name">The name of the option to look for.</param>
    /// <param name="unit">When searching for named constants, name of the unit it belongs to.</param>
    /// <param name="optFlags">Find only options with all the specified flags set (AV_OPT_FLAG).</param>
    /// <param name="searchFlags">A combination of AV_OPT_SEARCH_*.</param>
    /// <param name="targetObj">if non-NULL, an object to which the option belongs will be
    /// written here. It may be different from obj if AV_OPT_SEARCH_CHILDREN is present
    /// in search_flags. This parameter is ignored if search_flags contain AV_OPT_SEARCH_FAKE_OBJ.</param>
    /// <returns>A pointer to the option found, or NULL if no option was found.</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVOption> av_opt_find2(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string unit, AVOptionFlags optFlags, AVOptionSearchFlags searchFlags,
        out IntPtr targetObj);

    /// <summary>
    /// Iterate over all AVOptions belonging to obj.
    /// </summary>
    /// <param name="obj">an AVOptions-enabled struct or a double pointer to an AVClass describing it.</param>
    /// <param name="prev">result of the previous call to av_opt_next() on this object or NULL</param>
    /// <returns>next AVOption or NULL</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVOption> av_opt_next(IntPtr obj, ConstPtr<AVOption> prev);

    /// <summary>
    /// Iterate over AVOptions-enabled children of obj.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="prev">result of a previous call to this function or NULL</param>
    /// <returns>next AVOptions-enabled child or NULL</returns>
    [DllImport(LibraryName)]
    public static extern IntPtr av_opt_child_next(IntPtr obj, IntPtr prev);

    /// <summary>
    /// Iterate over potential AVOptions-enabled children of parent.
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="iter">a pointer where iteration state is stored.</param>
    /// <returns>AVClass corresponding to next potential child or NULL</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVClass> av_opt_child_class_iterate(ConstPtr<AVClass> parent, ref IntPtr iter);

    /// <summary>
    /// Those functions set the field of obj with the given name to value.
    /// </summary>
    /// <param name="obj">A struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">the name of the field to set</param>
    /// <param name="val">The value to set. In case of av_opt_set() if the field is not
    /// of a string type, then the given string is parsed.
    /// SI postfixes and some named scalars are supported.
    /// If the field is of a numeric type, it has to be a numeric or named
    /// scalar. Behavior with more than one scalar and +- infix operators is undefined.
    /// If the field is of a flags type, it has to be a sequence of numeric
    /// scalars or named flags separated by '+' or '-'. Prefixing a flag
    /// with '+' causes it to be set without affecting the other flags;
    /// similarly, '-' unsets a flag.
    /// If the field is of a dictionary type, it has to be a ':' separated list of
    /// key=value parameters. Values containing ':' special characters must be escaped.
    /// </param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be set on a child of obj.</param>
    /// <returns>0 if the value has been set, or an AVERROR code in case of error:
    /// AVERROR_OPTION_NOT_FOUND if no matching option exists
    /// AVERROR(ERANGE) if the value is out of range
    /// AVERROR(EINVAL) if the value is not valid</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string val, AVOptionSearchFlags searchFlags);

    /// <summary>
    /// Those functions set the field of obj with the given name to value.
    /// </summary>
    /// <param name="obj">A struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">the name of the field to set</param>
    /// <param name="val">The value to set. In case of av_opt_set() if the field is not
    /// of a string type, then the given string is parsed.
    /// SI postfixes and some named scalars are supported.
    /// If the field is of a numeric type, it has to be a numeric or named
    /// scalar. Behavior with more than one scalar and +- infix operators is undefined.
    /// If the field is of a flags type, it has to be a sequence of numeric
    /// scalars or named flags separated by '+' or '-'. Prefixing a flag
    /// with '+' causes it to be set without affecting the other flags;
    /// similarly, '-' unsets a flag.
    /// If the field is of a dictionary type, it has to be a ':' separated list of
    /// key=value parameters. Values containing ':' special characters must be escaped.
    /// </param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be set on a child of obj.</param>
    /// <returns>0 if the value has been set, or an AVERROR code in case of error:
    /// AVERROR_OPTION_NOT_FOUND if no matching option exists
    /// AVERROR(ERANGE) if the value is out of range
    /// AVERROR(EINVAL) if the value is not valid</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set_int(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, long val,
        AVOptionSearchFlags searchFlags);

    /// <summary>
    /// Those functions set the field of obj with the given name to value.
    /// </summary>
    /// <param name="obj">A struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">the name of the field to set</param>
    /// <param name="val">The value to set. In case of av_opt_set() if the field is not
    /// of a string type, then the given string is parsed.
    /// SI postfixes and some named scalars are supported.
    /// If the field is of a numeric type, it has to be a numeric or named
    /// scalar. Behavior with more than one scalar and +- infix operators is undefined.
    /// If the field is of a flags type, it has to be a sequence of numeric
    /// scalars or named flags separated by '+' or '-'. Prefixing a flag
    /// with '+' causes it to be set without affecting the other flags;
    /// similarly, '-' unsets a flag.
    /// If the field is of a dictionary type, it has to be a ':' separated list of
    /// key=value parameters. Values containing ':' special characters must be escaped.
    /// </param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be set on a child of obj.</param>
    /// <returns>0 if the value has been set, or an AVERROR code in case of error:
    /// AVERROR_OPTION_NOT_FOUND if no matching option exists
    /// AVERROR(ERANGE) if the value is out of range
    /// AVERROR(EINVAL) if the value is not valid</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set_double(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        double val, AVOptionSearchFlags searchFlags);

    /// <summary>
    /// Those functions set the field of obj with the given name to value.
    /// </summary>
    /// <param name="obj">A struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">the name of the field to set</param>
    /// <param name="val">The value to set. In case of av_opt_set() if the field is not
    /// of a string type, then the given string is parsed.
    /// SI postfixes and some named scalars are supported.
    /// If the field is of a numeric type, it has to be a numeric or named
    /// scalar. Behavior with more than one scalar and +- infix operators is undefined.
    /// If the field is of a flags type, it has to be a sequence of numeric
    /// scalars or named flags separated by '+' or '-'. Prefixing a flag
    /// with '+' causes it to be set without affecting the other flags;
    /// similarly, '-' unsets a flag.
    /// If the field is of a dictionary type, it has to be a ':' separated list of
    /// key=value parameters. Values containing ':' special characters must be escaped.
    /// </param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be set on a child of obj.</param>
    /// <returns>0 if the value has been set, or an AVERROR code in case of error:
    /// AVERROR_OPTION_NOT_FOUND if no matching option exists
    /// AVERROR(ERANGE) if the value is out of range
    /// AVERROR(EINVAL) if the value is not valid</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set_q(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVRational val, AVOptionSearchFlags searchFlags);

    /// <summary>
    /// Those functions set the field of obj with the given name to value.
    /// </summary>
    /// <param name="obj">A struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">the name of the field to set</param>
    /// <param name="val">The value to set. In case of av_opt_set() if the field is not
    /// of a string type, then the given string is parsed.
    /// SI postfixes and some named scalars are supported.
    /// If the field is of a numeric type, it has to be a numeric or named
    /// scalar. Behavior with more than one scalar and +- infix operators is undefined.
    /// If the field is of a flags type, it has to be a sequence of numeric
    /// scalars or named flags separated by '+' or '-'. Prefixing a flag
    /// with '+' causes it to be set without affecting the other flags;
    /// similarly, '-' unsets a flag.
    /// If the field is of a dictionary type, it has to be a ':' separated list of
    /// key=value parameters. Values containing ':' special characters must be escaped.
    /// </param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be set on a child of obj.</param>
    /// <returns>0 if the value has been set, or an AVERROR code in case of error:
    /// AVERROR_OPTION_NOT_FOUND if no matching option exists
    /// AVERROR(ERANGE) if the value is out of range
    /// AVERROR(EINVAL) if the value is not valid</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set_bin(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        Ptr<byte> val, int size, AVOptionSearchFlags searchFlags);

    /// <summary>
    /// Those functions set the field of obj with the given name to value.
    /// </summary>
    /// <param name="obj">A struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">the name of the field to set</param>
    /// <param name="w">The value to set. In case of av_opt_set() if the field is not
    /// of a string type, then the given string is parsed.
    /// SI postfixes and some named scalars are supported.
    /// If the field is of a numeric type, it has to be a numeric or named
    /// scalar. Behavior with more than one scalar and +- infix operators is undefined.
    /// If the field is of a flags type, it has to be a sequence of numeric
    /// scalars or named flags separated by '+' or '-'. Prefixing a flag
    /// with '+' causes it to be set without affecting the other flags;
    /// similarly, '-' unsets a flag.
    /// If the field is of a dictionary type, it has to be a ':' separated list of
    /// key=value parameters. Values containing ':' special characters must be escaped.
    /// </param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be set on a child of obj.</param>
    /// <returns>0 if the value has been set, or an AVERROR code in case of error:
    /// AVERROR_OPTION_NOT_FOUND if no matching option exists
    /// AVERROR(ERANGE) if the value is out of range
    /// AVERROR(EINVAL) if the value is not valid</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set_image_size(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        int w, int h, AVOptionSearchFlags searchFlags);

    /// <summary>
    /// Those functions set the field of obj with the given name to value.
    /// </summary>
    /// <param name="obj">A struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">the name of the field to set</param>
    /// <param name="fmt">The value to set. In case of av_opt_set() if the field is not
    /// of a string type, then the given string is parsed.
    /// SI postfixes and some named scalars are supported.
    /// If the field is of a numeric type, it has to be a numeric or named
    /// scalar. Behavior with more than one scalar and +- infix operators is undefined.
    /// If the field is of a flags type, it has to be a sequence of numeric
    /// scalars or named flags separated by '+' or '-'. Prefixing a flag
    /// with '+' causes it to be set without affecting the other flags;
    /// similarly, '-' unsets a flag.
    /// If the field is of a dictionary type, it has to be a ':' separated list of
    /// key=value parameters. Values containing ':' special characters must be escaped.
    /// </param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be set on a child of obj.</param>
    /// <returns>0 if the value has been set, or an AVERROR code in case of error:
    /// AVERROR_OPTION_NOT_FOUND if no matching option exists
    /// AVERROR(ERANGE) if the value is out of range
    /// AVERROR(EINVAL) if the value is not valid</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set_pixel_fmt(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVPixelFormat fmt, AVOptionSearchFlags searchFlags);

    /// <summary>
    /// Those functions set the field of obj with the given name to value.
    /// </summary>
    /// <param name="obj">A struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">the name of the field to set</param>
    /// <param name="fmt">The value to set. In case of av_opt_set() if the field is not
    /// of a string type, then the given string is parsed.
    /// SI postfixes and some named scalars are supported.
    /// If the field is of a numeric type, it has to be a numeric or named
    /// scalar. Behavior with more than one scalar and +- infix operators is undefined.
    /// If the field is of a flags type, it has to be a sequence of numeric
    /// scalars or named flags separated by '+' or '-'. Prefixing a flag
    /// with '+' causes it to be set without affecting the other flags;
    /// similarly, '-' unsets a flag.
    /// If the field is of a dictionary type, it has to be a ':' separated list of
    /// key=value parameters. Values containing ':' special characters must be escaped.
    /// </param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be set on a child of obj.</param>
    /// <returns>0 if the value has been set, or an AVERROR code in case of error:
    /// AVERROR_OPTION_NOT_FOUND if no matching option exists
    /// AVERROR(ERANGE) if the value is out of range
    /// AVERROR(EINVAL) if the value is not valid</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set_sample_fmt(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVSampleFormat fmt, AVOptionSearchFlags searchFlags);

    /// <summary>
    /// Those functions set the field of obj with the given name to value.
    /// </summary>
    /// <param name="obj">A struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">the name of the field to set</param>
    /// <param name="val">The value to set. In case of av_opt_set() if the field is not
    /// of a string type, then the given string is parsed.
    /// SI postfixes and some named scalars are supported.
    /// If the field is of a numeric type, it has to be a numeric or named
    /// scalar. Behavior with more than one scalar and +- infix operators is undefined.
    /// If the field is of a flags type, it has to be a sequence of numeric
    /// scalars or named flags separated by '+' or '-'. Prefixing a flag
    /// with '+' causes it to be set without affecting the other flags;
    /// similarly, '-' unsets a flag.
    /// If the field is of a dictionary type, it has to be a ':' separated list of
    /// key=value parameters. Values containing ':' special characters must be escaped.
    /// </param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be set on a child of obj.</param>
    /// <returns>0 if the value has been set, or an AVERROR code in case of error:
    /// AVERROR_OPTION_NOT_FOUND if no matching option exists
    /// AVERROR(ERANGE) if the value is out of range
    /// AVERROR(EINVAL) if the value is not valid</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set_video_rate(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVRational val, AVOptionSearchFlags searchFlags);

    /// <summary>
    /// Those functions set the field of obj with the given name to value.
    /// </summary>
    /// <param name="obj">A struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">the name of the field to set</param>
    /// <param name="layout">The value to set. In case of av_opt_set() if the field is not
    /// of a string type, then the given string is parsed.
    /// SI postfixes and some named scalars are supported.
    /// If the field is of a numeric type, it has to be a numeric or named
    /// scalar. Behavior with more than one scalar and +- infix operators is undefined.
    /// If the field is of a flags type, it has to be a sequence of numeric
    /// scalars or named flags separated by '+' or '-'. Prefixing a flag
    /// with '+' causes it to be set without affecting the other flags;
    /// similarly, '-' unsets a flag.
    /// If the field is of a dictionary type, it has to be a ':' separated list of
    /// key=value parameters. Values containing ':' special characters must be escaped.
    /// </param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be set on a child of obj.</param>
    /// <returns>0 if the value has been set, or an AVERROR code in case of error:
    /// AVERROR_OPTION_NOT_FOUND if no matching option exists
    /// AVERROR(ERANGE) if the value is out of range
    /// AVERROR(EINVAL) if the value is not valid</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set_channel_layout(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVChannelLayout layout, AVOptionSearchFlags searchFlags);

    /// <summary>
    /// Those functions set the field of obj with the given name to value.
    /// Note: Any old dictionary present is discarded and replaced with a copy of the new one. The
    /// caller still owns val is and responsible for freeing it.
    /// </summary>
    /// <param name="obj">A struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">the name of the field to set</param>
    /// <param name="layout">The value to set. In case of av_opt_set() if the field is not
    /// of a string type, then the given string is parsed.
    /// SI postfixes and some named scalars are supported.
    /// If the field is of a numeric type, it has to be a numeric or named
    /// scalar. Behavior with more than one scalar and +- infix operators is undefined.
    /// If the field is of a flags type, it has to be a sequence of numeric
    /// scalars or named flags separated by '+' or '-'. Prefixing a flag
    /// with '+' causes it to be set without affecting the other flags;
    /// similarly, '-' unsets a flag.
    /// If the field is of a dictionary type, it has to be a ':' separated list of
    /// key=value parameters. Values containing ':' special characters must be escaped.
    /// </param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be set on a child of obj.</param>
    /// <returns>0 if the value has been set, or an AVERROR code in case of error:
    /// AVERROR_OPTION_NOT_FOUND if no matching option exists
    /// AVERROR(ERANGE) if the value is out of range
    /// AVERROR(EINVAL) if the value is not valid</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_set_dict_val(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        ConstPtr<AVDictionary> val, AVOptionSearchFlags searchFlags);

    // TODO av_opt_set_int_list

    /// <summary>
    /// Those functions get a value of the option with the given name from an object.
    /// Note: the returned string will be av_malloc()ed and must be av_free()ed by the caller.
    /// Note: if AV_OPT_ALLOW_NULL is set in search_flags in av_opt_get, and the
    /// option is of type AV_OPT_TYPE_STRING, AV_OPT_TYPE_BINARY or AV_OPT_TYPE_DICT
    /// and is set to NULL, *out_val will be set to NULL instead of an allocated empty string.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">name of the option to get.</param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be found in a child of obj.</param>
    /// <param name="outVal">value of the option will be written here</param>
    /// <returns>>=0 on success, a negative error code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_get(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVOptionSearchFlags searchFlags, out Utf8StringPtr outVal);

    /// <summary>
    /// Those functions get a value of the option with the given name from an object.
    /// Note: the returned string will be av_malloc()ed and must be av_free()ed by the caller.
    /// Note: if AV_OPT_ALLOW_NULL is set in search_flags in av_opt_get, and the
    /// option is of type AV_OPT_TYPE_STRING, AV_OPT_TYPE_BINARY or AV_OPT_TYPE_DICT
    /// and is set to NULL, *out_val will be set to NULL instead of an allocated empty string.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">name of the option to get.</param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be found in a child of obj.</param>
    /// <param name="outVal">value of the option will be written here</param>
    /// <returns>>=0 on success, a negative error code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_get_int(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVOptionSearchFlags searchFlags, out long outVal);

    /// <summary>
    /// Those functions get a value of the option with the given name from an object.
    /// Note: the returned string will be av_malloc()ed and must be av_free()ed by the caller.
    /// Note: if AV_OPT_ALLOW_NULL is set in search_flags in av_opt_get, and the
    /// option is of type AV_OPT_TYPE_STRING, AV_OPT_TYPE_BINARY or AV_OPT_TYPE_DICT
    /// and is set to NULL, *out_val will be set to NULL instead of an allocated empty string.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">name of the option to get.</param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be found in a child of obj.</param>
    /// <param name="outVal">value of the option will be written here</param>
    /// <returns>>=0 on success, a negative error code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_get_double(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVOptionSearchFlags searchFlags, out double outVal);

    /// <summary>
    /// Those functions get a value of the option with the given name from an object.
    /// Note: the returned string will be av_malloc()ed and must be av_free()ed by the caller.
    /// Note: if AV_OPT_ALLOW_NULL is set in search_flags in av_opt_get, and the
    /// option is of type AV_OPT_TYPE_STRING, AV_OPT_TYPE_BINARY or AV_OPT_TYPE_DICT
    /// and is set to NULL, *out_val will be set to NULL instead of an allocated empty string.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">name of the option to get.</param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be found in a child of obj.</param>
    /// <param name="outVal">value of the option will be written here</param>
    /// <returns>>=0 on success, a negative error code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_get_q(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVOptionSearchFlags searchFlags, out AVRational outVal);

    /// <summary>
    /// Those functions get a value of the option with the given name from an object.
    /// Note: the returned string will be av_malloc()ed and must be av_free()ed by the caller.
    /// Note: if AV_OPT_ALLOW_NULL is set in search_flags in av_opt_get, and the
    /// option is of type AV_OPT_TYPE_STRING, AV_OPT_TYPE_BINARY or AV_OPT_TYPE_DICT
    /// and is set to NULL, *out_val will be set to NULL instead of an allocated empty string.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">name of the option to get.</param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be found in a child of obj.</param>
    /// <param name="wOut">value of the option will be written here</param>
    /// <returns>>=0 on success, a negative error code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_get_image_size(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVOptionSearchFlags searchFlags, out int wOut, out int hOut);

    /// <summary>
    /// Those functions get a value of the option with the given name from an object.
    /// Note: the returned string will be av_malloc()ed and must be av_free()ed by the caller.
    /// Note: if AV_OPT_ALLOW_NULL is set in search_flags in av_opt_get, and the
    /// option is of type AV_OPT_TYPE_STRING, AV_OPT_TYPE_BINARY or AV_OPT_TYPE_DICT
    /// and is set to NULL, *out_val will be set to NULL instead of an allocated empty string.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">name of the option to get.</param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be found in a child of obj.</param>
    /// <param name="outFmt">value of the option will be written here</param>
    /// <returns>>=0 on success, a negative error code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_get_pixel_fmt(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVOptionSearchFlags searchFlags, out AVPixelFormat outFmt);

    /// <summary>
    /// Those functions get a value of the option with the given name from an object.
    /// Note: the returned string will be av_malloc()ed and must be av_free()ed by the caller.
    /// Note: if AV_OPT_ALLOW_NULL is set in search_flags in av_opt_get, and the
    /// option is of type AV_OPT_TYPE_STRING, AV_OPT_TYPE_BINARY or AV_OPT_TYPE_DICT
    /// and is set to NULL, *out_val will be set to NULL instead of an allocated empty string.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">name of the option to get.</param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be found in a child of obj.</param>
    /// <param name="outFmt">value of the option will be written here</param>
    /// <returns>>=0 on success, a negative error code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_get_sample_fmt(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVOptionSearchFlags searchFlags, out AVSampleFormat outFmt);

    /// <summary>
    /// Those functions get a value of the option with the given name from an object.
    /// Note: the returned string will be av_malloc()ed and must be av_free()ed by the caller.
    /// Note: if AV_OPT_ALLOW_NULL is set in search_flags in av_opt_get, and the
    /// option is of type AV_OPT_TYPE_STRING, AV_OPT_TYPE_BINARY or AV_OPT_TYPE_DICT
    /// and is set to NULL, *out_val will be set to NULL instead of an allocated empty string.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">name of the option to get.</param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be found in a child of obj.</param>
    /// <param name="outVal">value of the option will be written here</param>
    /// <returns>>=0 on success, a negative error code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_get_video_rate(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVOptionSearchFlags searchFlags, out AVRational outVal);

    /// <summary>
    /// Those functions get a value of the option with the given name from an object.
    /// Note: the returned string will be av_malloc()ed and must be av_free()ed by the caller.
    /// Note: if AV_OPT_ALLOW_NULL is set in search_flags in av_opt_get, and the
    /// option is of type AV_OPT_TYPE_STRING, AV_OPT_TYPE_BINARY or AV_OPT_TYPE_DICT
    /// and is set to NULL, *out_val will be set to NULL instead of an allocated empty string.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">name of the option to get.</param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be found in a child of obj.</param>
    /// <param name="chLayout">value of the option will be written here</param>
    /// <returns>>=0 on success, a negative error code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_get_channel_layout(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVOptionSearchFlags searchFlags, out AVChannelLayout chLayout);

    /// <summary>
    /// Those functions get a value of the option with the given name from an object.
    /// Note: The returned dictionary is a copy of the actual value and must
    /// be freed with av_dict_free() by the caller.
    /// </summary>
    /// <param name="obj">a struct whose first element is a pointer to an AVClass.</param>
    /// <param name="name">name of the option to get.</param>
    /// <param name="searchFlags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN
    /// is passed here, then the option may be found in a child of obj.</param>
    /// <param name="outVal">value of the option will be written here</param>
    /// <returns>>=0 on success, a negative error code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_get_dict_val(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        AVOptionSearchFlags searchFlags, out Ptr<AVDictionary> outVal);

    /// <summary>
    /// Gets a pointer to the requested field in a struct.
    /// This function allows accessing a struct even when its fields are moved or
    /// renamed since the application making the access has been compiled,
    /// </summary>
    /// <param name="cl"></param>
    /// <param name="obj"></param>
    /// <param name="name"></param>
    /// <returns>a pointer to the field, it can be cast to the correct type and read or written to.</returns>
    [DllImport(LibraryName)]
    public static extern IntPtr av_opt_ptr(ConstPtr<AVClass> cl, IntPtr obj,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// Free an AVOptionRanges struct and set it to NULL.
    /// </summary>
    /// <param name="ranges"></param>
    [DllImport(LibraryName)]
    public static extern void av_opt_freep_ranges(ref Ptr<AVOptionRanges> ranges);

    /// <summary>
    /// Get a list of allowed ranges for the given option.
    ///
    /// The returned list may depend on other fields in obj like for example profile.
    /// </summary>
    /// <param name="ranges">The result must be freed with av_opt_freep_ranges.</param>
    /// <param name="obj"></param>
    /// <param name="key"></param>
    /// <param name="flags">is a bitmask of flags, undefined flags should not be set and should be ignored
    /// AV_OPT_SEARCH_FAKE_OBJ indicates that the obj is a double pointer to a AVClass instead of a full instance
    /// AV_OPT_MULTI_COMPONENT_RANGE indicates that function may return more than one component, @see AVOptionRanges</param>
    /// <returns>number of compontents returned on success, a negative errro code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_query_ranges(out Ptr<AVOptionRanges> ranges, IntPtr obj,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string key, AVOptionSearchFlags flags);

    /// <summary>
    /// Copy options from src object into dest object.
    ///
    /// The underlying AVClass of both src and dest must coincide. The guarantee
    /// below does not apply if this is not fulfilled.
    ///
    /// Options that require memory allocation (e.g. string or binary) are malloc'ed in dest object.
    /// Original memory allocated for such options is freed unless both src and dest options points to the same memory.
    ///
    /// Even on error it is guaranteed that allocated options from src and dest
    /// no longer alias each other afterwards; in particular calling av_opt_free()
    /// on both src and dest is safe afterwards if dest has been memdup'ed from src.
    /// </summary>
    /// <param name="dest">Object to copy from</param>
    /// <param name="src">Object to copy into</param>
    /// <returns>0 on success, negative on error</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_copy(IntPtr dest, /* const */ IntPtr src);

    /// <summary>
    /// Get a default list of allowed ranges for the given option.
    ///
    /// This list is constructed without using the AVClass.query_ranges() callback
    /// and can be used as fallback from within the callback.
    /// </summary>
    /// <param name="ranges">The result must be freed with av_opt_free_ranges.</param>
    /// <param name="obj"></param>
    /// <param name="key"></param>
    /// <param name="flags">is a bitmask of flags, undefined flags should not be set and should be ignored
    /// AV_OPT_SEARCH_FAKE_OBJ indicates that the obj is a double pointer to a AVClass instead of a full instance
    /// AV_OPT_MULTI_COMPONENT_RANGE indicates that function may return more than one component, @see AVOptionRanges</param>
    /// <returns>number of components returned on success, a negative error code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_query_ranges_default(out Ptr<AVOptionRanges> ranges, IntPtr obj,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string key, AVOptionSearchFlags flags);

    /// <summary>
    /// Check if given option is set to its default value.
    /// Options o must belong to the obj. This function must not be called to check child's options state.
    /// @see av_opt_is_set_to_default_by_name().
    /// </summary>
    /// <param name="obj">AVClass object to check option on</param>
    /// <param name="o">option to be checked</param>
    /// <returns>>0 when option is set to its default, 0 when option is not set its default, &lt;0 on error</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_is_set_to_default(IntPtr obj, ConstPtr<AVOption> o);

    /// <summary>
    /// Check if given option is set to its default value.
    /// </summary>
    /// <param name="obj">AVClass object to check option on</param>
    /// <param name="name">option name</param>
    /// <param name="flags">combination of AV_OPT_SEARCH_*</param>
    /// <returns>>0 when option is set to its default, 0 when option is not set its default, &lt;0 on error</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_is_set_to_default_by_name(IntPtr obj,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string name, AVOptionSearchFlags flags);

    /// <summary>
    /// Serialize object's options.
    ///
    /// Create a string containing object's serialized options.
    /// Such string may be passed back to av_opt_set_from_string() in order to restore option values.
    /// A key/value or pairs separator occurring in the serialized value or
    /// name string are escaped through the av_escape() function.
    ///
    /// Warning: Separators cannot be neither '\\' nor '\0'. They also cannot be the same.
    /// </summary>
    /// <param name="obj">AVClass object to serialize</param>
    /// <param name="optFlags">serialize options with all the specified flags set (AV_OPT_FLAG)</param>
    /// <param name="flags">combination of AV_OPT_SERIALIZE_* flags</param>
    /// <param name="buffer">Pointer to buffer that will be allocated with string containg serialized options.
    /// Buffer must be freed by the caller when is no longer needed.
    /// </param>
    /// <param name="keyValSep">character used to separate key from value</param>
    /// <param name="pairSep">character used to separate two pairs from each other</param>
    /// <returns>>= 0 on success, negative on error</returns>
    [DllImport(LibraryName)]
    public static extern int av_opt_serialize(IntPtr obj, AVOptionFlags optFlags, AVOptionSerializeFlags flags,
        out Utf8StringPtr buffer, byte keyValSep, byte pairSep);
}
