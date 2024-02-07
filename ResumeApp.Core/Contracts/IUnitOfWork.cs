using ResumeApp.Core.Common;

namespace ResumeApp.Core.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        IGenericRepository<T> GetRepository<T>() where T : class,new();
    }
}
