using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CozySmart.Models
{
    public class Amenity
    {
        public Amenity()
        {
            this.Accommodations = new HashSet<Accommodation>();
        }

        public  int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Accommodation> Accommodations { get; set; }    
        
    }
}