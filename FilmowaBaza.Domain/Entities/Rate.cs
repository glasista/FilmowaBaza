using System;
using System.Collections.Generic;
using System.Text;

namespace FilmowaBaza.Domain.Entities
{
    public class Rate : BaseEntity<long>
    {
        public int Rating { get; protected set; }
        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
