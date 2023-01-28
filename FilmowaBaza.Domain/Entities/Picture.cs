using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmowaBaza.Domain.Entities
{
    public class Picture : BaseEntity<long>
    {
        public string Name { get; set; }
    }
}
