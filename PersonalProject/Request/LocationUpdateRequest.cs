using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalProject.Request
{
    public class LocationUpdateRequest: LocationAddRequest
    {
        public int Id { get; set; }
    }
}