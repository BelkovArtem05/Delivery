using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Delivery.Model.Models
{
    public partial class Food
    {
        public Food()
        {
            Orders = new HashSet<Orders>();
        }

        public int IdFood { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
