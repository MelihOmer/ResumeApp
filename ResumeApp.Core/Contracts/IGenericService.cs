using System.Linq.Expressions;

namespace ResumeApp.Core.Contracts
{
    public interface IGenericService<T>
    {
        Task<IEnumerable<T>> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> filter);
        Task<T> GetById(int id);
        Task AddAsync(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
