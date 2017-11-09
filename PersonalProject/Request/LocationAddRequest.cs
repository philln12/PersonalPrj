using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalProject.Request
{
    public class LocationAddRequest
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public string LocationUrl { get; set; }
    }
}