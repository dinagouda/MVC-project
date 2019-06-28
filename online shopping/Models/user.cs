using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace online_shopping.Models
{
    public class user
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string password { get; set; }
        public string email { get; set; }

        public int age { get; set; }
    }
}