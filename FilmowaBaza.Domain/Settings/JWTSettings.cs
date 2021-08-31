namespace FilmowaBaza.Domain.Settings
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public int TimeToExpiry { get; set; }
        public string Issuer { get; set; }
    }
}
