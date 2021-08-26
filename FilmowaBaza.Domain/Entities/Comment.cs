﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FilmowaBaza.Domain.Entities
{
    public class Comment : BaseEntity<long>
    {
        public string Content { get; protected set; }
        public DateTime AddedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual IList<Comment> Comments { get; protected set; }
    }
}
