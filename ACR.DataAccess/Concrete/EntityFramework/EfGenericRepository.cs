using ACR.DataAccess.Abstract;
using ACR.DataAccess.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ACR.DataAccess.Concrete.EntityFramework
{
	public class EfGenericRepository<T> : IRepository<T>
		where T : class
	{
		protected readonly ACRContext _context;
		public EfGenericRepository(ACRContext context)
		{
			_context = context;
		}
		public void Add(T entity)
		{
			_context.Set<T>().Add(entity);
			_context.SaveChanges();
		}
		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
			_context.SaveChanges();
		}
		public IEnumerable<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}
		public T GetById(int Id)
		{
			return _context.Set<T>().Find(Id);
		}
		public void Update(T entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			_context.SaveChanges();
		}
		public List<T> GetAll(List<Func<T, bool>> filters, params Expression<Func<T, object>>[] expression)
		{
			var query = _context.Set<T>().AsQueryable();

			if (expression != null)
			{
				query = query.IncludeMultiple(expression);
			}

			if (filters != null && filters.Any())
			{
				foreach (var filter in filters)
				{
					query = query.Where(filter).AsQueryable();
				}
			}

			return query.ToList();
		}
	}
}