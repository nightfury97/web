using Shop_data.Control;
using SweepCake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SweepCake.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;

            }
            return View(list);

        }
        public string Image1(string ID)
        {
            string a = new DentalProduct().Image1(ID);
            return a;
        }
        public void AddItem(string productId, int quantity)
        {
            var product = new DentalProduct().GetByID(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Cake.Cake_ID == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Cake.Cake_ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Cake = product;
                    item.Quantity = quantity;
                    item.price = (float)(product.Cake_Price * (1 - product.Discount));
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Cake = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            // chuyen ve trang dang dung
            //return Redirect(Request.UrlReferrer.ToString());
            //return RedirectToAction("Index");
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public void Delete(string productId, int quantity)
        {
            //var sessionCart = (List<CartItem>)Session[CartSession];
            //sessionCart.RemoveAll(x => x.Cake.Cake_ID == id);
            //Session[CartSession] = sessionCart;
            //return Json(new
            //{
            //    status = true
            //});
            var product = new DentalProduct().GetByID(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Cake.Cake_ID == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Cake.Cake_ID == productId)
                        {
                            item.Quantity -= quantity;
                        }
                    }
                }
            }

        }
        [HttpPost]
        public void Update(string cake_id, int quantity)
        {
            //var jsonCart = new JavaScriptSerializer().Deserialize<CartItem>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            //foreach (var item in sessionCart)
            //{
            //    var jsonItem = jsonCart.SingleOrDefault(x => x.Cake.Cake_ID == item.Cake.Cake_ID);
            //    if (jsonItem != null)
            //    {
            //        item.Quantity = jsonItem.Quantity;
            //    }
            //}

            var product = new DentalProduct().GetByID(cake_id);
            foreach (var item in sessionCart)
            {            
                if (product != null)
                {
                    item.Quantity = quantity;
                }
            }
            Session[CartSession] = sessionCart;
        }
        public ActionResult Checkout()
        {
            return View();
        }
    }
}