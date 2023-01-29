using FilmowaBaza.Domain.Exceptions;
using FilmowaBaza.Domain.Repositories.Interfaces;
using FilmowaBaza.Infrastructure.Commands.UserCommands;
using FilmowaBaza.Infrastructure.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FilmowaBaza.Infrastructure.Handlers.User
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, long>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private Domain.Entities.User user;
        private readonly IUserServiceMapper userServiceMapper;
        public RegisterUserHandler(IUserRepository userRepository, IPasswordService passwordService, IUserServiceMapper userServiceMapper)
        {
            this._userRepository = userRepository;
            this._passwordService = passwordService;
            this.userServiceMapper = userServiceMapper;
        }
        public async Task<long> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.IsEmailAlreadyExists(command.Email))
            {
                throw new AppException(ErrorCode.UserExist);
            }
            user = userServiceMapper.MapCommandToEntity(command);

            user.HashedPassword = _passwordService.HashPassword(command.Password);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return default;
        }
    }
}
