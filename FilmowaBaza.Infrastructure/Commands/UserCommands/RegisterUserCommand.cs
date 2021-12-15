using MediatR;

namespace FilmowaBaza.Infrastructure.Commands
{
    public class RegisterUserCommand : IRequest<long>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

    }
}
