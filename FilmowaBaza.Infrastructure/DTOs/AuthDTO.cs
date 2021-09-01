namespace FilmowaBaza.Infrastructure.DTOs
{
    public class AuthDTO
    {
        public string Token { get; set; }
        public string FullName { get; set; }

        public AuthDTO(string token, string firstName, string lastName)
        {
            this.Token = token;
            this.FullName = firstName + ' ' + lastName;
        }
    }
}
