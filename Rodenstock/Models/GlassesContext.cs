using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rodenstock.Models
{
    public class GlassesContext: DbContext
    {
        public DbSet<Glasses> Glasses { get; set; }

        public GlassesContext() : base("Default Connection") { }
        public static GlassesContext Create()
        {
            return new GlassesContext();
        }
    }
}