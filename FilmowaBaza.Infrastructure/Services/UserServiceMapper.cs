using FilmowaBaza.Domain.Entities;
using FilmowaBaza.Infrastructure.Commands;
using FilmowaBaza.Infrastructure.DTOs;
using FilmowaBaza.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmowaBaza.Infrastructure.Services
{
    public class UserServiceMapper : IUserServiceMapper
    {
        public UserDTO MapToUserDTO(User userEntity)
        {
            return new UserDTO
            {
                Email = userEntity.Email,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName
            };
        }
        public User MapCommandToEntity(RegisterUserCommand registerUserCommand)
        {
            return new User(registerUserCommand.Email, registerUserCommand.FirstName, registerUserCommand.LastName);
        }
    }
}
