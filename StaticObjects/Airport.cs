using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Airport
    {
        public string id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string IATACode { get; set; }

        public string ICAOCode { get; set; }

        public string RegionName { get; set; }

        public string Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Altitude { get; set; }               
    }
}
