using FilmowaBaza.Domain.Entities;
using FilmowaBaza.Domain.Repositories.Interfaces;

namespace FilmowaBaza.Domain.Repositories
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        private readonly AppDbContext _context;
        public ActorRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
