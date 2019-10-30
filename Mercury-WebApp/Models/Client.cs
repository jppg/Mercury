using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Client
    {
        public Client()
        {
            Allocation = new HashSet<Allocation>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public virtual ICollection<Allocation> Allocation { get; set; }
    }
}
