using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_shopping.Models
{
    public class product
    {
        public int Id { get; set; }
        public string  Productname { get; set; }
        public string productdesc { get; set; }
        public int productprice { get; set; }

        public string Image { get; set; }
        public int categorynom { get; set; }
        public virtual category category { get; set; }
    }
}