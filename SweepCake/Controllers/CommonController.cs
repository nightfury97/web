using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_data.Control;
using SweepCake.Common;
using SweepCake.Models;

namespace SweepCake.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Index()
        {
            if (CommonConstant.USER_SESSION != null)
                ViewBag.User = Session[CommonConstant.USER_SESSION];
            //ViewBag.Name = 
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult Cake_Type()
        {
            var model = new Cake_Type_Control().ListAll();
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult Cart()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }
        //[ChildActionOnly]
        //public PartialViewResult Header()
        //{
        //    var user = Session[CommonConstant.USER_SESSION];
        //    var customer = new user();
        //    if (user != null)
        //    {

        //    }

        //    return PartialView(list);
        //}
        [ChildActionOnly]
        public PartialViewResult Cake_List(string code)
        {
            int total = 0;
            List<string> ids = new Cake_Type_Control().ListCakes(code, ref total);

            List<Cake_Dentals> cakes = new List<Cake_Dentals>();

            foreach (string ID in ids)
            {
                Cake_Dentals cake = new Cake_Dentals();
                var product = new DentalProduct().GetByID(ID);
                cake.ID = product.Cake_ID;
                cake.Name = product.Cake_Name;
                cake.Price = (float)product.Cake_Price;
                cake.Type = new DentalProduct().GetTypeName(product.Cake_Type_Code);
                cake.Discount = (float)product.Discount;
                cake.Decripsion = product.Cake_decripsion;
                cake.Images = new DentalProduct().Image(product.Cake_ID);
                cakes.Add(cake);

            }
            return PartialView(cakes);
        }
        [HttpPost]
        public ActionResult Search(string key, int page = 1, int pageSize = 9)
        {
            int totalRecord = 0;
            List<string> ids = new CakeControl().Search(key, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.page = page;
            List<Cake_Dentals> cakes = new List<Cake_Dentals>();

            foreach (string ID in ids)
            {
                Cake_Dentals cake = new Cake_Dentals();
                var product = new DentalProduct().GetByID(ID);
                cake.ID = product.Cake_ID;
                cake.Name = product.Cake_Name;
                cake.Price = (float)product.Cake_Price;
                cake.Type = new DentalProduct().GetTypeName(product.Cake_Type_Code);
                cake.TypeCode = product.Cake_Type_Code;
                cake.Discount = (float)product.Discount;
                cake.Decripsion = product.Cake_decripsion;
                cake.Image1 = new DentalProduct().Image1(product.Cake_ID);
                cakes.Add(cake);

            }


            return View(cakes);
        }
    }
}