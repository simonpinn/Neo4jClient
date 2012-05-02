﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Neo4jClient.Gremlin
{
    public static class BasicSteps
    {
        public static IGremlinNodeQuery<TNode> OutV<TNode>(this IGremlinQuery query)
        {
            var newQuery = query.AddBlock(".outV");
            return new GremlinNodeEnumerable<TNode>(newQuery);
        }

        public static IGremlinNodeQuery<TNode> OutV<TNode>(this IGremlinQuery query, IEnumerable<Filter> filters, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            var newQuery = query.AddFilterBlock(".outV", filters, comparison);
            return new GremlinNodeEnumerable<TNode>(newQuery);
        }

        public static IGremlinNodeQuery<TNode> OutV<TNode>(this IGremlinQuery query, Expression<Func<TNode, bool>> filter, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            var filters = FilterFormatters.TranslateFilter(filter);
            return query.OutV<TNode>(filters, comparison);
        }

        public static IGremlinNodeQuery<TNode> InV<TNode>(this IGremlinQuery query)
        {
            var newQuery = query.AddBlock(".inV");
            return new GremlinNodeEnumerable<TNode>(newQuery);
        }

        public static IGremlinNodeQuery<TNode> InV<TNode>(this IGremlinQuery query, IEnumerable<Filter> filters , StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            var newQuery = query.AddFilterBlock(".inV", filters, comparison);
            return new GremlinNodeEnumerable<TNode>(newQuery);
        }

        public static IGremlinNodeQuery<TNode> InV<TNode>(this IGremlinQuery query, Expression<Func<TNode, bool>> filter, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            var filters = FilterFormatters.TranslateFilter(filter);
            return query.InV<TNode>(filters, comparison);
        }

        public static IGremlinRelationshipQuery OutE(this IGremlinQuery query)
        {
            var newQuery = query.AddBlock(".outE");
            return new GremlinRelationshipEnumerable(newQuery);
        }

        public static IGremlinRelationshipQuery OutE(this IGremlinQuery query, string label)
        {
            var filter = new Filter
            {
                ExpressionType = ExpressionType.Equal,
                PropertyName = "label",
                Value = label
            };

            var newQuery = query.AddFilterBlock(".outE", new[] { filter }, StringComparison.Ordinal);
            return new GremlinRelationshipEnumerable(newQuery);
        }

        public static IGremlinRelationshipQuery<TData> OutE<TData>(this IGremlinQuery query)
            where TData : class, new()
        {
            var newQuery = query.AddBlock(".outE");
            return new GremlinRelationshipEnumerable<TData>(newQuery);
        }

        public static IGremlinRelationshipQuery<TData> OutE<TData>(this IGremlinQuery query, IEnumerable<Filter> filters, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
            where TData : class, new()
        {
            var newQuery = query.AddFilterBlock(".outE", filters, comparison);
            return new GremlinRelationshipEnumerable<TData>(newQuery);
        }

        public static IGremlinRelationshipQuery<TData> OutE<TData>(this IGremlinQuery query, Expression<Func<TData, bool>> filter, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
            where TData : class, new()
        {
            var filters = FilterFormatters.TranslateFilter(filter);
            return query.OutE<TData>(filters, comparison);
        }

        public static IGremlinRelationshipQuery<TData> OutE<TData>(this IGremlinQuery query, string label)
            where TData : class, new()
        {
            return query.OutE<TData>(label, new Filter[0], StringComparison.Ordinal);
        }

        public static IGremlinRelationshipQuery<TData> OutE<TData>(this IGremlinQuery query, string label, IEnumerable<Filter> filters, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
            where TData : class, new()
        {
            // TODO: This filter should always be case sensitive, irrespective of how the rest are compared
            var filter = new Filter
            {
                ExpressionType = ExpressionType.Equal,
                PropertyName = "label",
                Value = label
            };

            filters = filters.Concat(new[] { filter });

            var newQuery = query.AddFilterBlock(".outE", filters, comparison);
            return new GremlinRelationshipEnumerable<TData>(newQuery);
        }

        public static IGremlinRelationshipQuery<TData> OutE<TData>(this IGremlinQuery query, string label, Expression<Func<TData, bool>> filter, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
            where TData : class, new()
        {
            var filters = FilterFormatters.TranslateFilter(filter);
            return query.OutE<TData>(label, filters, comparison);
        }

        public static IGremlinRelationshipQuery InE(this IGremlinQuery query)
        {
            var newQuery = query.AddBlock(".inE");
            return new GremlinRelationshipEnumerable(newQuery);
        }

        public static IGremlinRelationshipQuery InE(this IGremlinQuery query, string label)
        {
            var filter = new Filter
                {
                    ExpressionType = ExpressionType.Equal,
                    PropertyName = "label",
                    Value = label
                };

            var newQuery = query.AddFilterBlock(".inE", new[] { filter }, StringComparison.Ordinal);
            return new GremlinRelationshipEnumerable(newQuery);
        }

        public static IGremlinNodeQuery<TNode> In<TNode>(this IGremlinQuery query, string label)
        {
            var newQuery = query.AddBlock(".in({0})", label);
            return new GremlinNodeEnumerable<TNode>(newQuery);
        }

        public static IGremlinRelationshipQuery<TData> InE<TData>(this IGremlinQuery query)
            where TData : class, new()
        {
            var newQuery = query.AddBlock(".inE");
            return new GremlinRelationshipEnumerable<TData>(newQuery);
        }

        public static IGremlinRelationshipQuery<TData> InE<TData>(this IGremlinQuery query, string label)
            where TData : class, new()
        {
            var filter = new Filter
            {
                ExpressionType = ExpressionType.Equal,
                PropertyName = "label",
                Value = label
            };

            var newQuery = query.AddFilterBlock(".inE", new[] { filter }, StringComparison.Ordinal);
            return new GremlinRelationshipEnumerable<TData>(newQuery);
        }

        public static IGremlinNodeQuery<TNode> Out<TNode>(this IGremlinQuery query, string label)
        {
            var newQuery = query.AddBlock(".out({0})", label);
            return new GremlinNodeEnumerable<TNode>(newQuery);
        }

        public static IGremlinNodeQuery<TNode> Out<TNode>(this IGremlinQuery query, string label, IEnumerable<Filter> filters, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            var newQuery = query.AddBlock(".out({0})", label);
            var filterQuery = newQuery.AddFilterBlock(string.Empty, filters, comparison);
            return new GremlinNodeEnumerable<TNode>(filterQuery);
        }

        public static IGremlinNodeQuery<TNode> Out<TNode>(this IGremlinQuery query, string label, Expression<Func<TNode, bool>> filter, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            var newQuery = query.AddBlock(".out({0})", label);
            var filters = FilterFormatters.TranslateFilter(filter);
            var filterQuery = newQuery.AddFilterBlock(string.Empty, filters, comparison);
            return new GremlinNodeEnumerable<TNode>(filterQuery);
        }

        public static IGremlinNodeQuery<TNode> In<TNode>(this IGremlinQuery query, string label, IEnumerable<Filter> filters, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            var newQuery = query.AddBlock(".in({0})", label);
            var filterQuery = newQuery.AddFilterBlock(string.Empty, filters, comparison);
            return new GremlinNodeEnumerable<TNode>(filterQuery);
        }

        public static IGremlinNodeQuery<TNode> In<TNode>(this IGremlinQuery query, string label, Expression<Func<TNode, bool>> filter, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            var newQuery = query.AddBlock(".in({0})", label);
            var filters = FilterFormatters.TranslateFilter(filter);
            var filterQuery = newQuery.AddFilterBlock(string.Empty, filters, comparison);
            return new GremlinNodeEnumerable<TNode>(filterQuery);
        }

        public static int GremlinCount(this IGremlinQuery query)
        {
            if (query.Client == null)
                throw new DetachedNodeException();

            var queryText = string.Format("{0}.count()", query.QueryText);
            var scalarResult = query.Client.ExecuteScalarGremlin(queryText, query.QueryParameters);

            int result;
            if (!int.TryParse(scalarResult, out result))
                throw new ApplicationException(string.Format(
                    "Query returned an unexpected value. Expected an integer. Received: {0}",
                    scalarResult));

            return result;
        }
    }
}