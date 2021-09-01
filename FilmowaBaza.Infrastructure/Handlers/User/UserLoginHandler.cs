using FilmowaBaza.Domain.Exceptions;
using FilmowaBaza.Domain.Repositories.Interfaces;
using FilmowaBaza.Infrastructure.DTOs;
using FilmowaBaza.Infrastructure.Queries;
using FilmowaBaza.Infrastructure.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FilmowaBaza.Infrastructure.Handlers.User
{
    public class UserLoginHandler : IRequestHandler<UserLoginQuery, AuthDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jWTService;
        private readonly IPasswordService _passwordService;
        public UserLoginHandler(IUserRepository userRepository, IJWTService jWTService, IPasswordService passwordService)
        {
            this._userRepository = userRepository;
            this._jWTService = jWTService;
            this._passwordService = passwordService;
        }
        public async Task<AuthDTO> Handle(UserLoginQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(query.Email);

            if(user == null)
            {
                throw new AppException(ErrorCode.NotFound);
            }

            _passwordService.VerifyPassword(query.Password, user.HashedPassword);

            var token = _jWTService.CreateToken(user.Id);
            return new AuthDTO(token, user.FirstName, user.LastName);
        }
    }
}
