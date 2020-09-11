using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rodenstock.Models
{
    public class Glasses
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string Sex { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
    }
}