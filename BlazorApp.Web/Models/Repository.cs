using System;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Web.Models
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _appDbContext;
        private DbSet<TEntity> entities;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            entities = _appDbContext.Set<TEntity>();
        }

        public async Task<TEntity> Get(int id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return entities.AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get entities: {ex.Message}");
            }
        }

        public IQueryable<TEntity> GetAll(string[] includes)
        {
            try
            {
                var query = entities.AsQueryable();
                foreach (var include in includes)
                    query = query.Include(include);
                return query.AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get entities with includes: {ex.Message}");
            }
        }

        public async Task<PaginatedList<TEntity>> GetPaged(int? pageNumber)
        {
            try
            {
                int pageSize = 5;
                var response = GetAll();
                return await PaginatedList<TEntity>
                    .CreateAsync(response.AsNoTracking(), pageNumber ?? 1, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get paged entities: {ex.Message}");
            }
        }
        public async Task<PaginatedList<TEntity>> GetPaged(int? pageNumber, string[] includes)
        {
            try
            {
                int pageSize = 5;
                var response = GetAll(includes);
                return await PaginatedList<TEntity>
                    .CreateAsync(response.AsNoTracking(), pageNumber ?? 1, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get paged entities with includes: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                var result = await entities.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                var entry = entities.First(e => e.Id == entity.Id);
                _appDbContext.Entry(entry).CurrentValues.SetValues(entity);
                await _appDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
        public async Task<TEntity> DeleteAsync(int id)
        {
            try
            {
                var entity = await entities.FindAsync(id);
                if (entity != null)
                {
                    entities.Remove(entity);
                    await _appDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
    }
}