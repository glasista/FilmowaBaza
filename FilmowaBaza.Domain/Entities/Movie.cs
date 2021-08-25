using System;
using System.Collections.Generic;
using System.Text;

namespace FilmowaBaza.Domain.Entities
{
    public class Movie : BaseEntity<long>
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Rating { get; protected set; }
        public DateTime ReleaseDate { get; protected set; }
        public virtual List<Category> Categories { get; protected set; }
        public virtual List<Actor> Actors { get; protected set; }
        public virtual List<Rate> Rates { get; protected set; }
        public virtual List<Comment> Comments { get; protected set; }
    }
}
