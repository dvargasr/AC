using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinita.Data.Entities
{
    public class AdoptionStory
    {
        public int Id { get; set; }
        public Dog Dog { get; set; }
        public DateTime Date { get; set; }
        public String Location { get; set; }
    }
}
