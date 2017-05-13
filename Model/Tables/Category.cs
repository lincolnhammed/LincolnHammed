using Models.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Tables
{
    public class Category
    {

        public long? CategoryId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}