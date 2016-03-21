using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ultima.Models.SpareParts
{
    public class ItemPart
    {
        public ItemPart()
        {
            ItemSuppliers = new List<ItemSupplier>();
        }
        public int Id { get; set; }

        [Display(Name = "Part Name")]
        public string Name { get; set; }
       
        [Display(Name = "Description")]
        public string Dscrp { get; set; }

        public List<ItemSupplier> ItemSuppliers { get; set; }
    }
}