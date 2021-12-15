using System;
using System.Collections.Generic;

namespace FilmowaBaza.Domain.Entities
{
    public class Comment : BaseEntity<long>
    {
        public string Content { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsVisible { get; set; }
        public virtual User User { get; set; }
        public virtual IList<Comment> Comments { get; set; }
    }
}
