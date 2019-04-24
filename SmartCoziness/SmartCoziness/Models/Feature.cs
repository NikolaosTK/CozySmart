using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCoziness.Models
{
    public class Feature
    {
        public Feature()
        {
            this.Accommodations = new HashSet<Accommodation>();
        }

        public  int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Accommodation> Accommodations { get; set; }    
        
    }
}