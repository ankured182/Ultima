using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ultima.Models.SpareParts
{
    public class ItemSupplier
    {
        public int Id { get; set; }


        public ItemPart ItemPt { get; set; }
        [Display(Name = "Part No:")]
        public int ItemPtId { get; set; }

     
        public Supplier ItemSup { get; set; }
     
        public int ItemSupId { get; set; }


         [Display(Name = "Buy Price")]
        public decimal BuyPrice { get; set; }
        public decimal SalePrice { get; set; }

        public decimal ListPrice { get; set; }

        public string ImgUrl { get; set; }

        public string Comments { get; set; }
        public int IsActivated { get; set; }


    }
}