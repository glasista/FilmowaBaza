using FilmowaBaza.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmowaBaza.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator) : base(mediator)
        {
            this._mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] UserLoginQuery query)
            => Ok(await Handle(query));
    }
}
