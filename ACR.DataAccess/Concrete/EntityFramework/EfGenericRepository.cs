using ACR.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Concrete.EntityFramework
{
    public class EfGenericRepository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext, new()
    {
        private readonly TContext _context;

        public EfGenericRepository(TContext context)
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
    }
}