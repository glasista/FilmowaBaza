using AutoMapper;
using FilmowaBaza.Domain.Repositories.Interfaces;
using FilmowaBaza.Infrastructure.Commands.MovieCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dbEntity = FilmowaBaza.Domain.Entities.Movie;

namespace FilmowaBaza.Infrastructure.Handlers.Movie
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, long>
    {
        private readonly IMovieRepository _MovieRepository;
        private readonly IMapper _mapper;

        private dbEntity _deletepost;
        public DeleteMovieCommandHandler(IMovieRepository MovieRepository, IMapper mapper)
        {
            this._MovieRepository = MovieRepository;
            this._mapper = mapper;
        }
        public async Task<long> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            _deletepost = await GetMovie(request.Id);
            await _MovieRepository.DeleteAsync(_deletepost);

            return 1;
        }
        private Task<dbEntity> GetMovie(long id)
        {
            return _MovieRepository.GetAsyncById(id);
        }
    }
}
