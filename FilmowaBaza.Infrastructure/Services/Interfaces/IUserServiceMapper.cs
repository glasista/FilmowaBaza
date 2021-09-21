using FilmowaBaza.Domain.Entities;
using FilmowaBaza.Infrastructure.Commands;
using FilmowaBaza.Infrastructure.DTOs;

namespace FilmowaBaza.Infrastructure.Services.Interfaces
{
    public interface IUserServiceMapper : IService
    {
        UserDTO MapToUserDTO(User userEntity);
        User MapCommandToEntity(RegisterUserCommand registerUserCommand);
    }
}
