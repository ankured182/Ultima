using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ultima.Models.SpareParts
{
    public class Supplier
    {
        public Supplier()
        {
            ItemSuppliers = new List<ItemSupplier>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }
        public List<ItemSupplier> ItemSuppliers { get; set; }
    }

}