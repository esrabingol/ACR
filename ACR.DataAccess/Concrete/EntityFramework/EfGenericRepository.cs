using ACR.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

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
    }
}