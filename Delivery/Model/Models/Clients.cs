using System;
using System.Collections.Generic;
using System.Xml.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Delivery.Model.Models
{
    public partial class Clients
    {
        public Clients()
        {
            Orders = new HashSet<Orders>();
        }

        public int IdClient { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fathername { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        public override string ToString()
        {
            return $"{Lastname} {Firstname} {Fathername}";
        }
    }
}
