using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ultima.Models.SpareParts
{
    public class OrderMaster
    {
        public OrderMaster()
        {
            OrdDetails = new List<OrdDetail>();
        }
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public List<OrdDetail> OrdDetails { get; set; }

    }
}