using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rodenstock.Models
{
    public class Orders
    {
        public Client client { get; set; }
        public List<Glasses> glasses { get; set; }
        public Orders()
        {
            glasses = new List<Glasses>();
        }
    }
}