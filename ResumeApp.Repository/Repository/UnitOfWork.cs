using ResumeApp.Core.Common;
using ResumeApp.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeApp.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class, new()
        {
            return new GenericRepository<T>(_context);
        }
    }
}
