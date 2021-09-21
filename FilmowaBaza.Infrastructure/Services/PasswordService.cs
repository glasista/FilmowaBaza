using FilmowaBaza.Domain.Exceptions;
using FilmowaBaza.Infrastructure.Services.Interfaces;
using System;

namespace FilmowaBaza.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return null;
            }
            else
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }
        }

        public void VerifyPassword(string password, string passwordHash)
        {
            if(!BCrypt.Net.BCrypt.Verify(password,passwordHash))
            {
                throw new AppException(ErrorCode.InvalidPassword);
            }
        }
    }
}
