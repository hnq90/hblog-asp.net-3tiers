// UrlRewriter - A .NET URL Rewriter module
// Version 2.0
//
// Copyright 2011 Intelligencia
// Copyright 2011 Seth Yates
// 

namespace Intelligencia.UrlRewriter
{
    /// <summary>
    ///     Interface for executable actions.  Actions must be thread-safe as there is a single
    ///     instance of each action.  This means that you must not make any changes to fields/properties
    ///     on the action once its created.
    /// </summary>
    public interface IRewriteAction
    {
        /// <summary>
        ///     Executes the action.
        /// </summary>
        /// <remarks>
        ///     It is important to set the correct properties on the context
        ///     (e.g., StatusCode, Location), rather than directly implementing the action
        ///     (e.g., RewritePath).  This allows for the correct pipeline processing of
        ///     all the specified rules.
        /// </remarks>
        /// <returns>
        ///     The Processing directive determines how the rewriter should continue
        ///     processing after this action has executed.
        /// </returns>
        /// <param name="context">The context to execute the action on.</param>
        RewriteProcessing Execute(RewriteContext context);
    }
}