using System.Text.Json.Serialization;

namespace FilmowaBaza.Infrastructure.Queries
{
    public abstract class AbstractAuthQuery
    {
        [JsonIgnore]
        public long UserId { get; set; }
    }
}
