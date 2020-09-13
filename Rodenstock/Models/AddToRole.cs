using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rodenstock.Models
{
    public class AddToRole
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public List<string> Roles { get; set; }

        public AddToRole()
        {
            Roles = new List<string>();
        }
    }
}