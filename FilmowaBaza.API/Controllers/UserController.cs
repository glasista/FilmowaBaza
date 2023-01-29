using FilmowaBaza.Infrastructure.Commands.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
