using FilmowaBaza.Infrastructure.Command;
using FilmowaBaza.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmowaBaza.API.Controllers
{
    [Route("api")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private long UserId => GetLoggedUserId();
        protected BaseController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        protected async Task<T> Handle<T>(IRequest<T> request)
        {
            if(request is AbstractAuthQuery)
            {
                (request as AbstractAuthQuery).UserId = UserId;
            }
            if(request is AbstractAuthCommand)
            {
                (request as AbstractAuthCommand).UserId = UserId;
            }

            return await _mediator.Send(request);
        }
        private long GetLoggedUserId()
        {
            if(User?.Identity?.IsAuthenticated == true)
            {
                var userIdString = this.User.Identity.Name;
                if(long.TryParse(userIdString, out long userId))
                {
                    return userId;
                }
            }
            return -1;
        }
    }
}
