﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ACR.DataAccess.Helper
{
	public static class LinqHelper
	{
		public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
		{
			if (includes != null)
				query = includes.Aggregate(query, (current, include) => current.Include(include));

			return query;
		}
	}
}
