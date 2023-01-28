using AutoMapper;
using FilmowaBaza.Domain.Repositories.Interfaces;
using FilmowaBaza.Infrastructure.DTOs;
using FilmowaBaza.Infrastructure.Queries;
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
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, ICollection<MovieDTO>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        private IList<dbEntity> _movies;
        public GetMoviesQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            this._movieRepository = movieRepository;
            this._mapper = mapper;
        }
        public async Task<ICollection<MovieDTO>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            await Task.Run( () => GetMoviesQuery(), cancellationToken );
            return DtoResponse();   
        }

        private ICollection<MovieDTO> DtoResponse()
        {
            return _mapper.Map<IList<MovieDTO>>(_movies);
        }

        private async void GetMoviesQuery()
        {
            _movies = await _movieRepository.GetAllAsListAsync();
        }
    }
}
