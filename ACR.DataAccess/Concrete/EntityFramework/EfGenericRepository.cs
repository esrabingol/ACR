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
        public void Add(T entity)
        {

            using( var context = new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();

            }
        }

        public void Delete(T entity)
        {
            using( var context  = new TContext()) 
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll()
        {
            //sayfalama olacak
            using (var context = new TContext())
            {
              return context.Set<T>().ToList();
            }
        }

        public T GetById(int Id)
        {
            using( var context = new TContext())
            {
                return context.Set<T>().Find(Id);
            }
        }

        public void Update(T entity)
        {
           using( var context= new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
