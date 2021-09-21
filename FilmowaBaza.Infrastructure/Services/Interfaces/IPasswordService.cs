namespace FilmowaBaza.Infrastructure.Services.Interfaces
{
    public interface IPasswordService : IService
    {
        string HashPassword(string password);
        void VerifyPassword(string password, string passwordHash);
    }
}
