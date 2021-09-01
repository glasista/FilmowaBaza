namespace FilmowaBaza.Infrastructure.Services.Interfaces
{
    public interface IPasswordService : IService
    {
        string HashedPassword(string password);
        void VerifyPassword(string password, string passwordHash);
    }
}
