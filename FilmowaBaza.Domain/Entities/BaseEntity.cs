using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
