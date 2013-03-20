// UrlRewriter - A .NET URL Rewriter module
// Version 2.0
//
// Copyright 2011 Intelligencia
// Copyright 2011 Seth Yates
// 

using System.Xml;
using Intelligencia.UrlRewriter.Actions;
using Intelligencia.UrlRewriter.Configuration;
using Intelligencia.UrlRewriter.Utilities;

namespace Intelligencia.UrlRewriter.Parsers
{
    /// <summary>
    ///     Parser for not allowed actions.
    /// </summary>
    public sealed class NotAllowedActionParser : RewriteActionParserBase
    {
        /// <summary>
        ///     The name of the action.
        /// </summary>
        public override string Name
        {
            get { return Constants.ElementNotAllowed; }
        }

        /// <summary>
        ///     Whether the action allows nested actions.
        /// </summary>
        public override bool AllowsNestedActions
        {
            get { return false; }
        }

        /// <summary>
        ///     Whether the action allows attributes.
        /// </summary>
        public override bool AllowsAttributes
        {
            get { return false; }
        }

        /// <summary>
        ///     Parses the node.
        /// </summary>
        /// <param name="node">The node to parse.</param>
        /// <param name="config">The rewriter configuration.</param>
        /// <returns>The parsed action, or null if no action parsed.</returns>
        public override IRewriteAction Parse(XmlNode node, RewriterConfiguration config)
        {
            return new MethodNotAllowedAction();
        }
    }
}