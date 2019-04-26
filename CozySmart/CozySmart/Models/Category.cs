using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CozySmart.Models
{
    public class Category
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        public ICollection<Accommodation> Accommodations { get; set; }
    }
}