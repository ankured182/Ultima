using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ultima.Models.SpareParts
{
    public class OrdDetail
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }

        public int OrderId { get; set; }
        public OrderMaster Order { get; set; }
    }
}