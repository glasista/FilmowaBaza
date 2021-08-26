using FilmowaBaza.Domain.Entities;
using System.Threading.Tasks;

namespace FilmowaBaza.Domain.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
