using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace online_shopping.Models
{
    public class category
    {
        [Key]
        public int categorynom { get; set; }
        public string categoryname { get; set; }

        public virtual List<product> products { get; set; }
    }
}