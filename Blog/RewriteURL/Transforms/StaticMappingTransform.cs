// UrlRewriter - A .NET URL Rewriter module
// Version 2.0
//
// Copyright 2011 Intelligencia
// Copyright 2011 Seth Yates
// 

using System.Collections.Specialized;

namespace Intelligencia.UrlRewriter.Transforms
{
    /// <summary>
    ///     Default RewriteMapper, reads its maps from config.
    ///     The mapping is CASE-INSENSITIVE.
    /// </summary>
    public sealed class StaticMappingTransform : IRewriteTransform
    {
        private readonly StringDictionary _map;
        private readonly string _name;

        /// <summary>
        ///     Default constructor.
        /// </summary>
        /// <param name="name">The name of the mapping.</param>
        /// <param name="map">The mappings.</param>
        public StaticMappingTransform(string name, StringDictionary map)
        {
            _name = name;
            _map = map;
        }

        /// <summary>
        ///     Maps the specified value in the specified map to its replacement value.
        /// </summary>
        /// <param name="input">The value being mapped.</param>
        /// <returns>The value mapped to, or null if no mapping could be performed.</returns>
        public string ApplyTransform(string input)
        {
            return _map[input];
        }

        /// <summary>
        ///     The name of the action.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
    }
}