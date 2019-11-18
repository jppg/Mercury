using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Config
    {
        public int ConfigId { get; set; }
        public string Keyname { get; set; }
        public decimal Keyvalue { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
    }
}
