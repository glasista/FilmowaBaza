using System.Collections.Generic;

namespace FilmowaBaza.Domain.Entities
{
    public class Actor : BaseEntity<long>
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public virtual IList<Movie> Movies { get; protected set; }
    }
}
