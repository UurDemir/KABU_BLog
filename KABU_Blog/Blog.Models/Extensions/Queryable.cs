using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Blog.Models.Extensions
{
    public static class Queryable
    {
        public static IQueryable<T> IncludeRange<T, TProperty>(this IQueryable<T> query, params Expression<Func<T, TProperty>>[] includes)
        {
            foreach (var expression in includes)
            {
                query.Include(expression);
            }
            return query;
        }
    }
}
