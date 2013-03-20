// UrlRewriter - A .NET URL Rewriter module
// Version 2.0
//
// Copyright 2011 Intelligencia
// Copyright 2011 Seth Yates
// 

using System.Web;

namespace Intelligencia.UrlRewriter
{
    /// <summary>
    ///     Interface for rewriter error handlers.
    /// </summary>
    public interface IRewriteErrorHandler
    {
        /// <summary>
        ///     Handles the error.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        void HandleError(HttpContext context);
    }
}