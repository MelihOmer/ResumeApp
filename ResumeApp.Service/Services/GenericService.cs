using ResumeApp.Core.Contracts;
using System.Linq.Expressions;

namespace ResumeApp.Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class,new()
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(T entity)
        {
            await _unitOfWork.GetRepository<T>().AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(T entity)
        {
            _unitOfWork.GetRepository<T>().Delete(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _unitOfWork.GetRepository<T>().GetAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _unitOfWork.GetRepository<T>().GetById(id);
        }

        public async Task Update(T entity)
        {
           _unitOfWork.GetRepository<T>().Update(entity); 
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> filter)
        {
            return _unitOfWork.GetRepository<T>().Where(filter);
        }
    }
}
