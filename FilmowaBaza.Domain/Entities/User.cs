using System;
using System.Collections.Generic;
using System.Text;

namespace FilmowaBaza.Domain.Entities
{
    public class User : BaseEntity<long> 
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public string HashedPassword { get; protected set; }
        public bool IsActive { get; protected set; }
        public virtual IList<Rate> Rates { get; protected set; }
        public virtual IList<Comment> Comments { get; protected set; }
    }
}
