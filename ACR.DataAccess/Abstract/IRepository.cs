namespace ACR.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int Id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
