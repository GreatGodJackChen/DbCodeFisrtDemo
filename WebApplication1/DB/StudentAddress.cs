using System;
using System.Collections.Generic;

namespace WebApplication1.DB
{
    public partial class StudentAddress
    {
        public int StudentAddressId { get; set; }
        public int StudentId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual Students Student { get; set; }
    }
}
