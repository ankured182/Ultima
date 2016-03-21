using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ultima.DataLayer;
using Ultima.Models.SpareParts;

namespace Ultima.Controllers
{
    public class PlaceOrderController : Controller
    {
        UltimaDb _db = new UltimaDb();
        //
        // GET: /PlaceOrder/
        public ActionResult Index()
        {
            return View();
        }
         [HttpPost]
        public JsonResult GetPrice(OrdDetail o)
        {
            bool status = false;
           string returnVal="3";

            var model = from i in _db.ItemSuppliers
                        where i.ItemPt.Name == o.ItemName
                        && i.IsActivated==1
                        select i;
            if (model.Count() > 0)
            {
                string x = model.First().SalePrice.ToString();
                string y = model.First().Id.ToString();
               
                returnVal = model.First().SalePrice.ToString();
                string partSupId = y;
                status = true;
                

                return new JsonResult { Data = new { status = status, returnVal = returnVal, partSupId = partSupId } };
            }
            else
            {

                return new JsonResult { Data = new { status = status, returnVal = '3', partSupId = "2" } };
            }
        }

        [HttpPost]

        public JsonResult SaveOrder(OrderMaster o)
        {
            bool status = false;
            string returnVal = "9999";
            List<OrderMaster> ml = new List<OrderMaster>();

            if (ModelState.IsValid)
            {
                using (UltimaDb p = new UltimaDb())
                {
                    OrderMaster m = new OrderMaster { OrderNo = o.OrderNo };
                    foreach (var i in o.OrdDetails)
                    {
                        //i.Order = m;
                        //i.OrderId = m.Id;
                        m.OrdDetails.Add(i);
                        //p.Entry(m.OrdDetails).State = EntityState.Added;
                    }
                    //p.Entry(m).State = EntityState.Added;

                    p.OrderMasters.Add(m);
                    p.SaveChanges();
                    status = true;
                    
                }
            }
            return new JsonResult { Data = new { status = status,returnVal=returnVal } };
        }
	}
}