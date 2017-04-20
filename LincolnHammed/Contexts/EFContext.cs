using LincolnHammed.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LincolnHammed.Contexts
{
    public class EFContext : DbContext
    {
        #region[DbSet Properties]

        public DbSet<Category> Category { get; set; }

       // vamos ter uma propriedade Supplier isso vai setar uma tabela
        public DbSet<Supplier> Supplier { get; set; }
        #endregion

        #region[Constructor]
       // connection String
        public EFContext():base("Asp_Net_MVC_CS")
        {

        }
        #endregion
    }
}