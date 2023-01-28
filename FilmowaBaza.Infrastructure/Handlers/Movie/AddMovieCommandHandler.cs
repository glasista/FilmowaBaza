using AutoMapper;
using FilmowaBaza.Domain.Repositories;
using FilmowaBaza.Domain.Repositories.Interfaces;
using FilmowaBaza.Infrastructure.Commands.MovieCommands;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dbEntities = FilmowaBaza.Domain.Entities;

namespace FilmowaBaza.Infrastructure.Handlers.Movie
{
    public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, long>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        private dbEntities.Movie _newMovie;

        public AddMovieCommandHandler(MovieRepository movieRepository, IMapper mapper)        
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }


        public async Task<long> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            _newMovie = CreateNewMovie(request);

            await _movieRepository.AddAsync(_newMovie);
            await _movieRepository.SaveChangesAsync();

            return _newMovie.Id;
        }

        private dbEntities.Movie CreateNewMovie(AddMovieCommand model)
        {
            var movie = _mapper.Map<dbEntities.Movie>(model);

            return movie;
        }
    }
}
