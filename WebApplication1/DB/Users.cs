using System;
using System.Collections.Generic;

namespace WebApplication1.DB
{
    public partial class Users
    {
        public Users()
        {
            Roles = new HashSet<Roles>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Roles> Roles { get; set; }
    }
}
