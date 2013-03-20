// UrlRewriter - A .NET URL Rewriter module
// Version 2.0
//
// Copyright 2011 Intelligencia
// Copyright 2011 Seth Yates
// 

using System;
using System.Configuration;
using System.Xml;
using Intelligencia.UrlRewriter.Actions;
using Intelligencia.UrlRewriter.Configuration;
using Intelligencia.UrlRewriter.Utilities;

namespace Intelligencia.UrlRewriter.Parsers
{
    /// <summary>
    ///     Parser for redirect actions.
    /// </summary>
    public sealed class RedirectActionParser : RewriteActionParserBase
    {
        /// <summary>
        ///     The name of the action.
        /// </summary>
        public override string Name
        {
            get { return Constants.ElementRedirect; }
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
            get { return true; }
        }

        /// <summary>
        ///     Parses the node.
        /// </summary>
        /// <param name="node">The node to parse.</param>
        /// <param name="config">The rewriter configuration.</param>
        /// <returns>The parsed action, or null if no action parsed.</returns>
        public override IRewriteAction Parse(XmlNode node, RewriterConfiguration config)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            string to = node.GetRequiredAttribute(Constants.AttrTo, true);

            bool permanent = true;
            XmlNode permanentNode = node.Attributes.GetNamedItem(Constants.AttrPermanent);
            if (permanentNode != null)
            {
                if (!bool.TryParse(permanentNode.Value, out permanent))
                {
                    throw new ConfigurationErrorsException(
                        MessageProvider.FormatString(Message.InvalidBooleanAttribute, Constants.AttrPermanent), node);
                }
            }

            var action = new RedirectAction(to, permanent);
            ParseConditions(node, action.Conditions, false, config);
            return action;
        }
    }
}