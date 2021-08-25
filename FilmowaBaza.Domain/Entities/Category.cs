using System;
using System.Collections.Generic;
using System.Text;

namespace FilmowaBaza.Domain.Entities
{
    public class Category : BaseEntity<long>
    {
        public string Name { get; protected set; }
        public virtual List<Movie> Movies { get; protected set; }
    }
}
