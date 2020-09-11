using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rodenstock.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public Client client { get; set; }
        public List<Glasses> glasses { get; set; }
        public Orders()
        {
            glasses = new List<Glasses>();
        }
    }
}