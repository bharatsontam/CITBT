using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CITBT
{
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// Short hand way to do AutoMapper's MapFrom.
        /// </summary>
        /// <typeparam name="TSource">Object to map from</typeparam>
        /// <typeparam name="TTarget">Object to map to</typeparam>
        /// <param name="mappingExpression">The fluent mapping expression that AutoMapper uses</param>
        /// <param name="member">The expression that represents the targetted member</param>
        /// <param name="source">The expression that represents the source to map from</param>
        /// <returns>The fluent mapping expression</returns>
        public static IMappingExpression<TSource, TTarget> MapFrom<TSource, TTarget>(
            this IMappingExpression<TSource, TTarget> mappingExpression,
            Expression<Func<TTarget, object>> member,
            Expression<Func<TSource, object>> source)
        {
            return mappingExpression.ForMember(member, action => action.MapFrom(source));
        }

        /// <summary>
        /// Short hand way to do AutoMapper's Ignore
        /// </summary>
        /// <typeparam name="TSource">Object to map from</typeparam>
        /// <typeparam name="TTarget">Object to map to</typeparam>
        /// <param name="mappingExpression">The fluent mapping expression that AutoMapper uses</param>
        /// <param name="member">The expression that represents the targetted member</param>
        /// <returns>The fluent mapping expression</returns>
        public static IMappingExpression<TSource, TTarget> Ignore<TSource, TTarget>(
            this IMappingExpression<TSource, TTarget> mappingExpression, Expression<Func<TTarget, object>> member)
        {
            return mappingExpression.ForMember(member, action => action.Ignore());
        }
    }
}