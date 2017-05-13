using Models.Register;
using System.Collections.Generic;

namespace Models.Register
{
    public class Supplier
    {
        public long? SupplierId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}