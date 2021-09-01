using System.ComponentModel.DataAnnotations;
using FilmowaBaza.Infrastructure.DTOs;
using MediatR;

namespace FilmowaBaza.Infrastructure.Queries
{
    public class UserLoginQuery : IRequest<AuthDTO>
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invaild email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(30, ErrorMessage = "Password must be between 6 and 30 characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
