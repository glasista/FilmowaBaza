using FilmowaBaza.Domain.Entities;
using FilmowaBaza.Domain.Repositories.Interfaces;

namespace FilmowaBaza.Domain.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
