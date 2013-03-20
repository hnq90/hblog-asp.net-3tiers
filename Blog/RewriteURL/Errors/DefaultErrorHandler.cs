// UrlRewriter - A .NET URL Rewriter module
// Version 2.0
//
// Copyright 2011 Intelligencia
// Copyright 2011 Seth Yates
// 

using System;
using System.Web;

namespace Intelligencia.UrlRewriter.Errors
{
    /// <summary>
    ///     The default error handler.
    /// </summary>
    public class DefaultErrorHandler : IRewriteErrorHandler
    {
        private readonly string _url;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="url">Url of the error page.</param>
        public DefaultErrorHandler(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }
            _url = url;
        }

        /// <summary>
        ///     Handles the error by rewriting to the error page url.
        /// </summary>
        /// <param name="context">The context.</param>
        public void HandleError(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            context.Server.Execute(_url);
        }
    }
}