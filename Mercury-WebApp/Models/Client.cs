using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Client
    {
        public Client()
        {
            Employee = new HashSet<Employee>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
