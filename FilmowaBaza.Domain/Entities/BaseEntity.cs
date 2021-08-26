using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

//Moved to the same namespace of entities to avoid using its reference on inherit
namespace FilmowaBaza.Domain.Entities
{
    public abstract class BaseEntity<Tkey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Tkey Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? ModifiedAt { get; protected set; }
    }
}
