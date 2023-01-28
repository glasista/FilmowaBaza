using AutoMapper;
using FilmowaBaza.Domain.Repositories;
using FilmowaBaza.Domain.Repositories.Interfaces;
using FilmowaBaza.Infrastructure.Commands.MovieCommands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using dbEntities = FilmowaBaza.Domain.Entities;

namespace FilmowaBaza.Infrastructure.Handlers.Movie
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, long>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        private dbEntities.Movie _updateMovie;

        public UpdateMovieCommandHandler(MovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }


        public async Task<long> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            _updateMovie = await GetMovie(request.Id);
            UpdateMovie(request, _updateMovie);


            await _movieRepository.UpdateAsync(_updateMovie);
            await _movieRepository.SaveChangesAsync();

            return _updateMovie.Id;
        }

        private void UpdateMovie(UpdateMovieCommand model, dbEntities.Movie dbMovie)
        {
            _mapper.Map(model, dbMovie);
        }

        private Task<dbEntities.Movie> GetMovie(long Id)
        {
            return _movieRepository.GetAsyncById(Id);
        }

    }
}
