using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace online_shopping.Models
{
    public class Onlineshop: DbContext
    {
        public DbSet<user> users { get; set; }
        public DbSet<category> categories { get; set; }
        public DbSet<product> products { get; set; }
    }
}