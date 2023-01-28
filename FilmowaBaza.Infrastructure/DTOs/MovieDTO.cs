using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmowaBaza.Infrastructure.DTOs
{
    public class MovieDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public DateTime ReleadeDate { get; set; }
    }
}
