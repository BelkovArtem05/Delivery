using System;
using System.Collections.Generic;
using System.Xml.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Delivery.Model.Models
{
    public partial class Orders
    {
        public int IdOrder { get; set; }
        public int? FoodId { get; set; }
        public int? WorkerId { get; set; }
        public int? ClientId { get; set; }
        public int? DeliveryPrice { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }

        public virtual Clients Client { get; set; }
        public virtual Food Food { get; set; }
        public virtual Workers Worker { get; set; }

        public override string ToString()
        {
            return $"{IdOrder}";
        }
    }
}
