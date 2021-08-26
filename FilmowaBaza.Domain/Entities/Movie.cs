using System;
using System.Collections.Generic;

namespace FilmowaBaza.Domain.Entities
{
    public class Movie : BaseEntity<long>
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Rating { get; protected set; }
        public DateTime ReleaseDate { get; protected set; }
        public virtual IList<Category> Categories { get; protected set; }
        public virtual IList<Actor> Actors { get; protected set; }
        public virtual IList<Rate> Rates { get; protected set; }
        public virtual IList<Comment> Comments { get; protected set; }
    }
}
