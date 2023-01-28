using FilmowaBaza.Infrastructure.Command;
using MediatR;

namespace FilmowaBaza.Infrastructure.Commands.MovieCommands
{
    public class UpdateMovieCommand : AbstractAuthCommand, IRequest<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
