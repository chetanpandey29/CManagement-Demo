using System;
using System.Collections.Generic;

namespace CAS_MVC_4.Models
{
    public partial class TransportAllocation
    {
        public int ScholarNumber { get; set; }
        public string Type { get; set; }
        public string SourceLocation { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> LeftDate { get; set; }
        public virtual Student Student { get; set; }
    }
}
