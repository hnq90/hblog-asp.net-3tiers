// UrlRewriter - A .NET URL Rewriter module
// Version 2.0
//
// Copyright 2011 Intelligencia
// Copyright 2011 Seth Yates
// 

using System.Collections.Generic;

namespace Intelligencia.UrlRewriter.Actions
{
    /// <summary>
    ///     Rewrites in-place.
    /// </summary>
    public sealed class RewriteAction : SetLocationAction, IRewriteCondition
    {
        private readonly IList<IRewriteCondition> _conditions = new List<IRewriteCondition>();
        private readonly RewriteProcessing _processing;

        /// <summary>
        ///     Default constructor.
        /// </summary>
        /// <param name="location">The location to set.</param>
        /// <param name="processing">The processing directive.</param>
        public RewriteAction(string location, RewriteProcessing processing)
            : base(location)
        {
            _processing = processing;
        }

        /// <summary>
        ///     Conditions that must hold for the rule to fire.
        /// </summary>
        public IList<IRewriteCondition> Conditions
        {
            get { return _conditions; }
        }

        /// <summary>
        ///     Determines if the rewrite rule matches.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool IsMatch(RewriteContext context)
        {
            // Ensure the conditions are met.
            foreach (IRewriteCondition condition in Conditions)
            {
                if (!condition.IsMatch(context))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Executes the action.
        /// </summary>
        /// <param name="context">The rewrite context.</param>
        public override RewriteProcessing Execute(RewriteContext context)
        {
            base.Execute(context);
            return _processing;
        }
    }
}