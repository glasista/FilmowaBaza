namespace FilmowaBaza.Domain.Entities
{
    public class Rate : BaseEntity<long>
    {
        public int Rating { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
