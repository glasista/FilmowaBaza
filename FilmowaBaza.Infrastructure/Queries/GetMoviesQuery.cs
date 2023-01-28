using FilmowaBaza.Infrastructure.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmowaBaza.Infrastructure.Queries
{
    public class GetMoviesQuery : IRequest<IList<MovieDTO>>
    {
        public GetMoviesQuery() { }
    }
}
