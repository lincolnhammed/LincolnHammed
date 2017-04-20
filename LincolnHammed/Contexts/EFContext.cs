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

        public DbSet<Category> Categories { get; set; }

        // vamos ter uma propriedade Supplier isso vai setar uma tabela
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }
        #endregion

        #region[Constructor]
        // connection String
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(
                new DropCreateDatabaseIfModelChanges<EFContext>()
                );
        }

        #endregion
    }
}