// UrlRewriter - A .NET URL Rewriter module
// Version 2.0
//
// Copyright 2011 Intelligencia
// Copyright 2011 Seth Yates
// 

namespace Intelligencia.UrlRewriter
{
    /// <summary>
    ///     Processing flag. Tells the rewriter how to continue processing (or not).
    /// </summary>
    public enum RewriteProcessing
    {
        /// <summary>
        ///     Continue processing at the next rule.
        /// </summary>
        ContinueProcessing,

        /// <summary>
        ///     Halt processing.
        /// </summary>
        StopProcessing,

        /// <summary>
        ///     Restart processing at the first rule.
        /// </summary>
        RestartProcessing
    }
}