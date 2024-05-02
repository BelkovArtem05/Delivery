using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Delivery.Model.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Food = new HashSet<Food>();
        }

        public int IdCategory { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Food> Food { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
