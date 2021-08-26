using System;
using System.Collections.Generic;
using System.Text;

namespace FilmowaBaza.Domain.Entities
{
    public class Actor : BaseEntity<long>
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public virtual IList<Movie> Movies { get; protected set; }
    }
}
