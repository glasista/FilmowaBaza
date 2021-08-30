using FilmowaBaza.Domain.Entities;
using FilmowaBaza.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FilmowaBaza.Domain.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }

        public Task<User> GetByEmail(string email)
        {
            return _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
