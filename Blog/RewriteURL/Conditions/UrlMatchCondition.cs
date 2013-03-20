// UrlRewriter - A .NET URL Rewriter module
// Version 2.0
//
// Copyright 2011 Intelligencia
// Copyright 2011 Seth Yates
// 

using System;
using System.Text.RegularExpressions;

namespace Intelligencia.UrlRewriter.Conditions
{
    /// <summary>
    ///     Matches on the current URL.
    /// </summary>
    public sealed class UrlMatchCondition : IRewriteCondition
    {
        private readonly string _pattern;
        private Regex _regex;

        /// <summary>
        ///     Default constructor.
        /// </summary>
        /// <param name="pattern"></param>
        public UrlMatchCondition(string pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }
            _pattern = pattern;
        }

        /// <summary>
        ///     The pattern to match.
        /// </summary>
        public string Pattern
        {
            get { return _pattern; }
        }

        /// <summary>
        ///     Determines if the condition is matched.
        /// </summary>
        /// <param name="context">The rewriting context.</param>
        /// <returns>True if the condition is met.</returns>
        public bool IsMatch(RewriteContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            // Use double-checked locking pattern to synchronise access to the regex.
            if (_regex == null)
            {
                lock (this)
                {
                    if (_regex == null)
                    {
                        _regex = new Regex(context.ResolveLocation(Pattern), RegexOptions.IgnoreCase);
                    }
                }
            }

            Match match = _regex.Match(context.Location);
            if (match.Success)
            {
                context.LastMatch = match;
            }

            return match.Success;
        }
    }
}