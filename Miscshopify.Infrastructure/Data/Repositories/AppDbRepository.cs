using Microsoft.EntityFrameworkCore;

namespace Miscshopify.Infrastructure.Data.Repositories
{
    public class AppDbRepository : IAppDbRepository
    {
        protected DbContext Context { get; set; }

        public AppDbRepository(MiscshopifyContext context)
        {
            Context = context;
        }

        protected DbSet<T> DbSet<T>() where T : class
        {
            return this.Context.Set<T>();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public IQueryable<T> AllAsNoTracking<T>() where T : class
        {
            return DbSet<T>().AsQueryable().AsNoTracking();
        }

        public void Delete<T>(T entity) where T : class
        {
            Context.Set<T>().Remove(entity);
        }

        public async Task DeleteAsync<T>(object id) where T : class
        {
            T entity = await GetByIdAsync<T>(id);

            Delete<T>(entity);
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        public async Task<T> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.Context.SaveChangesAsync();
        }

        public void Update<T>(T entity) where T : class
        {
            this.DbSet<T>().Update(entity);
        }

        


    }
}
