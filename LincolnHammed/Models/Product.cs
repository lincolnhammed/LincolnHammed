using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LincolnHammed.Models
{
    public class Product
    {
        public long? ProductId { get; set; }
        public string Nome { get; set; }
        public long? SupplierId { get; set; }
        public long? CategoryId { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }

    }
}