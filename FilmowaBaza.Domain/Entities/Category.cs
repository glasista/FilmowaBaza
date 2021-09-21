using System.Collections.Generic;

namespace FilmowaBaza.Domain.Entities
{
    public class Category : BaseEntity<long>
    {
        public string Name { get; set; }
        public virtual IList<Movie> Movies { get; set; }
    }
}
