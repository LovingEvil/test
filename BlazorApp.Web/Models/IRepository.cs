using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Web.Data;

namespace BlazorApp.Web.Models
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Get(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(string[] includes);
        Task<PaginatedList<TEntity>> GetPaged(int? pageNumber);
        Task<PaginatedList<TEntity>> GetPaged(int? pageNumber, string[] includes);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
    }
}