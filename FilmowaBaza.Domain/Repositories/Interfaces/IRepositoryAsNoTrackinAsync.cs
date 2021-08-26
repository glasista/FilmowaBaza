using FilmowaBaza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmowaBaza.Domain.Repositories.Interfaces
{
    public interface IRepositoryAsNoTrackinAsync<T> where T : BaseEntity<long>
    {
        Task<T> GetByIdAsNoTrackingAsync(long id);
        Task<IList<T>> GetAllAsListAsNoTrackingAsync();
    }
}
