using Shop_data;
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
        //public string Image1(string ID)
        //{
        //    var aa = data.Cake_Images.Where(x => x.Cake_ID == ID).FirstOrDefault();
        //    if (aa != null)
        //    {
        //        string a = aa.Cake_Image1.ToString();
        //        return a;
        //    }
        //    return "/Images/logo.png";
        //}
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
                            item.price = (float)(product.Cake_Price * (1 - product.Discount));
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
                item.price=(float)(product.Cake_Price * (1 - product.Discount));
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
                if (product != null && product.Cake_ID==item.Cake.Cake_ID)
                {
                    item.Quantity = quantity;
                }
            }
            Session[CartSession] = sessionCart;
        }
        [HttpPost]
        public void Remove(string cake_id)
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
                if (product != null && product.Cake_ID == item.Cake.Cake_ID)
                {
                    sessionCart.Remove(item);
                    break;
                }
            }
            Session[CartSession] = sessionCart;
        }
        public ActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShippingInfo(string firstname,string email,string address, string phone,string cardname,string cardnumber,string expmonth,string expyear,string cvv,bool payment = false)
        {
            var dao = new CartControl();
            var listCart = (List<SweepCake.Models.CartItem>)Session[SweepCake.Common.CommonConstant.CartSession];
            var userlogin = (UserLogin)Session[SweepCake.Common.CommonConstant.USER_SESSION];
            // add phuong thuc thanh toan

            if (payment == true)
            {
                if (dao.checkPayment(userlogin.UserID, cardnumber) == false)
                {
                    Customer_Payment_Method CPM = new Customer_Payment_Method();
                    CPM.Customer_ID = userlogin.UserID;
                    CPM.Payment_Menthod_Code = "CS";
                }
            }
            else
            {
                if(dao.checkPayment(userlogin.UserID,cardnumber)==false)
                {
                    Customer_Payment_Method CPM = new Customer_Payment_Method();
                    CPM.Customer_ID = userlogin.UserID;
                    CPM.Card_Number = cardnumber;
                    CPM.Expmonth = expmonth;
                    CPM.Expyear = CPM.Expyear;
                    CPM.Payment_Menthod_Code = "VS";
                    CPM.CVV = cvv;
                    dao.insert(CPM);
                }
            }
            dao.paymentID(userlogin.UserID, cardnumber);
            //add don hang
            DateTime a = DateTime.Now;
            if (payment == true)
            {
                dao.insertorder(userlogin.UserID, dao.paymentID(userlogin.UserID, cardnumber),a, firstname, address, phone, email, 1);
            }
            else
            {
                dao.insertorder(userlogin.UserID, dao.paymentID(userlogin.UserID, cardnumber), a,firstname, address, phone, email, 2);
            }
            //add gio hang
            int IDorder = Convert.ToInt32(dao.CartID(userlogin.UserID, a));
            
            foreach(var item in listCart)
            {
                var itemcart = new Cart_Item();
                itemcart.Cart_ID = IDorder;
                itemcart.Cake_ID = item.Cake.Cake_ID;
                itemcart.Price = item.price;
                itemcart.Quantity = item.Quantity;
                dao.insertcakes(itemcart);
            }
            Session[SweepCake.Common.CommonConstant.CartSession] = null;
           
            return Redirect("/HomePage/Index");
        }
    }
}