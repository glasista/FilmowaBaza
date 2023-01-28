using FilmowaBaza.Infrastructure.Command;
using MediatR;

namespace FilmowaBaza.Infrastructure.Commands.MovieCommands
{
    public class DeleteMovieCommand : AbstractAuthCommand, IRequest<long>
    {
        public long Id { get; set; }
    }
}
