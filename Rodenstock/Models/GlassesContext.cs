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
        public DbSet<Client> Clients { get; set; }
        public DbSet<Orders> Orders { get; set; }

        public GlassesContext() : base("Default Connection") { }
        public static GlassesContext Create()
        {
            return new GlassesContext();
        }
    }
}