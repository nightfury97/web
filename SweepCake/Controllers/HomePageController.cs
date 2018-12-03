using Shop_data;
using Shop_data.Control;
using SweepCake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweepCake.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult index()
        {
            var cakeControl = new CakeControl();
            var dental = new DentalProduct();
            List<Cake> NewCake = cakeControl.ListNewProduct(3);
            List<Cake_Dentals> cake_n = new List<Cake_Dentals>()
            {
                new Cake_Dentals(){ ID = NewCake[0].Cake_ID, Name=NewCake[0].Cake_Name, Image1 = dental.Image1(NewCake[0].Cake_ID),Price = (float)NewCake[0].Cake_Price,Decripsion = NewCake[0].Cake_decripsion,Type = NewCake[0].Cake_Type_Code},
                new Cake_Dentals(){ ID = NewCake[1].Cake_ID, Name=NewCake[1].Cake_Name, Image1 = dental.Image1(NewCake[1].Cake_ID),Price = (float)NewCake[1].Cake_Price,Decripsion = NewCake[1].Cake_decripsion,Type = NewCake[1].Cake_Type_Code},
                new Cake_Dentals(){ ID = NewCake[2].Cake_ID, Name=NewCake[2].Cake_Name, Image1 = dental.Image1(NewCake[2].Cake_ID),Price = (float)NewCake[2].Cake_Price,Decripsion = NewCake[2].Cake_decripsion,Type = NewCake[2].Cake_Type_Code}
            };
            List<Cake> HotCake = cakeControl.ListHotProduct(4);
            List<Cake_Dentals> cake_h = new List<Cake_Dentals>()
            {
                new Cake_Dentals(){ ID = HotCake[0].Cake_ID, Name=HotCake[0].Cake_Name, Image1 = dental.Image1(HotCake[0].Cake_ID),Price = (float)HotCake[0].Cake_Price,Decripsion = HotCake[0].Cake_decripsion,Type = HotCake[0].Cake_Type_Code},
                new Cake_Dentals(){ ID = HotCake[1].Cake_ID, Name=HotCake[1].Cake_Name, Image1 = dental.Image1(HotCake[1].Cake_ID),Price = (float)HotCake[1].Cake_Price,Decripsion = HotCake[1].Cake_decripsion,Type = HotCake[1].Cake_Type_Code},
                new Cake_Dentals(){ ID = HotCake[2].Cake_ID, Name=HotCake[2].Cake_Name, Image1 = dental.Image1(HotCake[2].Cake_ID),Price = (float)HotCake[2].Cake_Price,Decripsion = HotCake[2].Cake_decripsion,Type = HotCake[2].Cake_Type_Code},
                new Cake_Dentals(){ ID = HotCake[3].Cake_ID, Name=HotCake[3].Cake_Name, Image1 = dental.Image1(HotCake[3].Cake_ID),Price = (float)HotCake[2].Cake_Price,Decripsion = HotCake[3].Cake_decripsion,Type = HotCake[3].Cake_Type_Code}
            };

            ViewBag.NewCake = cake_n;
            ViewBag.HotCake = cake_h;
            return View();
        }

        public ActionResult login()
        {
            return View();
        }
        public ActionResult about()
        {
            return View();
        }
        public ActionResult contact()
        {
            return View();
        }
        public ActionResult myaccount()
        {
            return View();
        }
        public ActionResult register()
        {
            return View();
        }
    }
}