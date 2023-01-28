using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FilmowaBaza.Infrastructure.Commands.MovieCommands;
using FilmowaBaza.Infrastructure.DTOs;
using FilmowaBaza.Infrastructure.Queries;


namespace FilmowaBaza.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class MovieController : BaseController
    {
        public MovieController(IMediator mediatr) : base(mediatr) { }

        [HttpGet(Name = "GetAll")]
        public async Task<ActionResult<ICollection<MovieDTO>>> GetAll()
        {
            var response = await Handle(new GetMoviesQuery());
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<long>> Post([FromBody] AddMovieCommand command)
            => Ok(await Handle(command));

        [HttpPost("Put")]
        public async Task<ActionResult<long>> Update([FromBody] UpdateMovieCommand command)
            => Ok(await Handle(command));

        [HttpPost("Delete")]
        public async Task<ActionResult> Delete([FromBody] DeleteMovieCommand command)
            => Ok(await Handle(command));
    }
}