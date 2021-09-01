namespace FilmowaBaza.Infrastructure.Services.Interfaces
{
    public interface IJWTService : IService
    {
        string CreateToken(long userId);
    }
}
