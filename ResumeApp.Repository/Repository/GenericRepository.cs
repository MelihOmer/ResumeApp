using Microsoft.EntityFrameworkCore;
using ResumeApp.Core.Common;
using ResumeApp.Core.Contracts;
using System.Linq.Expressions;

namespace ResumeApp.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
          return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
          return  await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
           _dbSet.Update(entity);
        }

        public  IQueryable<T> Where(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter).AsQueryable();
        }
    }
}
