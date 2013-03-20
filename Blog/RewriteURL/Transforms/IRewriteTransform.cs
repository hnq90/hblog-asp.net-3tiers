// UrlRewriter - A .NET URL Rewriter module
// Version 2.0
//
// Copyright 2011 Intelligencia
// Copyright 2011 Seth Yates
// 

namespace Intelligencia.UrlRewriter
{
    /// <summary>
    ///     Interface for transforming replacements.
    /// </summary>
    public interface IRewriteTransform
    {
        /// <summary>
        ///     The name of the transform.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Applies a transformation to the input string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The transformed string.</returns>
        string ApplyTransform(string input);
    }
}