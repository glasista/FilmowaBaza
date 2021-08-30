namespace FilmowaBaza.Domain.Entities
{
    public class Rate : BaseEntity<long>
    {
        public int Rating { get; protected set; }
        public virtual Movie Movie { get; protected set; }
        public virtual User User { get; protected set; }
    }
}
