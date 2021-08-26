using FilmowaBaza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmowaBaza.Domain.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity<long>
    {
        Task<T> GetAsyncById(long id);
        Task<IList<T>> GetAllAsListAsync();
        IQueryable<T> GetQueryable();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
