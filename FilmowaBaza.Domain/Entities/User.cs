using System.Collections.Generic;

namespace FilmowaBaza.Domain.Entities
{
    public class User : BaseEntity<long> 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public bool IsActive { get; set; }
        public virtual IList<Rate> Rates { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public User(string email, string firstName, string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
