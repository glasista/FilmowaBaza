using FilmowaBaza.Domain.Entities;
using FilmowaBaza.Domain.Repositories.Interfaces;

namespace FilmowaBaza.Domain.Repositories
{
    public class RateRepository : BaseRepository<Rate>, IRateRepository
    {
        private readonly AppDbContext _context;
        public RateRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
