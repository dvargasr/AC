using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinita.Models
{
    public class AdoptionStoryModel
    {
        public int AdoptionStoryId { get; set; }
        public DogModel Dog { get; set; }
        public DateTime Date { get; set; }
        public String Location { get; set; }
    }
}
