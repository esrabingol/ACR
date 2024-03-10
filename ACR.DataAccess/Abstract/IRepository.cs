using ACR.Entity.Concrete;
using System.Linq.Expressions;

namespace ACR.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int Id);
        IEnumerable<T> GetAll();
        List<T> GetAll(List<Func<T, bool>> filters, params Expression<Func<T, object>>[] expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
