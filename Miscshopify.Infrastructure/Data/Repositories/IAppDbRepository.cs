using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Infrastructure.Data.Repositories
{
    public interface IAppDbRepository : IDisposable
    {
        IQueryable<T> All<T>()
            where T : class;

        IQueryable<T> AllAsNoTracking<T>()
            where T : class;

        Task<T> GetByIdAsync<T>(object id)
            where T : class;

        Task AddAsync<T>(T entity)
            where T : class;

        void Update<T>(T entity)
            where T : class;

        Task DeleteAsync<T>(object id)
            where T : class;

        void Delete<T>(T entity)
            where T : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
