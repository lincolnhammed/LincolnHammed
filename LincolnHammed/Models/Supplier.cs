using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LincolnHammed.Models
{
    public class Supplier
    {
        [Key]
        public long SupplierId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}