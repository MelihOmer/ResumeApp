using System.Linq.Expressions;

namespace ResumeApp.Core.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> filter);
        Task<T> GetById(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
