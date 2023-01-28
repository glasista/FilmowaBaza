using System;
using System.Collections.Generic;

namespace FilmowaBaza.Domain.Entities
{
    public class Movie : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual IList<Category> Categories { get; set; }
        public virtual IList<Actor> Actors { get; set; }
        public virtual IList<Rate> Rates { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<Picture> Pictures { get; set; }
    }
}
