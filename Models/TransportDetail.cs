using System;
using System.Collections.Generic;

namespace CAS_MVC_4.Models
{
    public partial class TransportDetail
    {
        public string Type { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverName { get; set; }
        public string ContactNumber { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    }
}
