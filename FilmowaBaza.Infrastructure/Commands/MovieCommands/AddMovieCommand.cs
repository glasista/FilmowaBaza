using FilmowaBaza.Infrastructure.Command;
using MediatR;

namespace FilmowaBaza.Infrastructure.Commands.MovieCommands
{
    public class AddMovieCommand : AbstractAuthCommand, IRequest<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
