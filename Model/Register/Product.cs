using Models.Register;
using Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


namespace Models.Register
{
    public class Product
    {

        public long? ProductId { get; set; }
        [DisplayName("Product")]
        public string Nome { get; set; }
        public long? SupplierId { get; set; }
        public long? CategoryId { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }

    }
}