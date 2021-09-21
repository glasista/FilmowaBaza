using System.Collections.Generic;

namespace FilmowaBaza.Domain.Entities
{
    public class Actor : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual IList<Movie> Movies { get; set; }
    }
}
