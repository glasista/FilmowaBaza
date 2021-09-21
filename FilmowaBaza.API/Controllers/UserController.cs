using FilmowaBaza.Infrastructure.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmowaBaza.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserCommand command)
            => Ok(await Handle(command));
    }
}
