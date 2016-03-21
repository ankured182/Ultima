using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Ultima.Models.SpareParts;

namespace Ultima.DataLayer
{
    public class UltimaDb:DbContext
    {
        public UltimaDb(): base("DefaultConnection")
        {

        }

        public DbSet<ItemPart> ItemParts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ItemSupplier> ItemSuppliers { get; set; }
        public DbSet<OrderMaster> OrderMasters { get; set; }
        public DbSet<OrdDetail> OrderDetails { get; set; }
    }
}