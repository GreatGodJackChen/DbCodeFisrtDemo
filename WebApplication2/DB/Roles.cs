using System;
using System.Collections.Generic;

namespace WebApplication2.DB
{
    public partial class Roles
    {
        public int IdP { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
