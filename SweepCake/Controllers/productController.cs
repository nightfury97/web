using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_data;
using Shop_data.Control;
using SweepCake.Models;

namespace SweepCake.Controllers
{
    public class productController : Controller
    {
        // GET: product
        public ActionResult products(string type )
        {
            if (type == "products") type = new Cake_Type_Control().ListFirst();
            List<string> ids = new Cake_Type_Control().ListCakes(type);

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

        // GET: product/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: product/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult checkout()
        {
            return View();
        }
        public ActionResult singlepage()
        {
            return View();
        }
        public ActionResult detail(string id)
        {
            Cake_Dentals cake = new Cake_Dentals();
            var product = new DentalProduct().GetByID(id);
            cake.ID = product.Cake_ID;
            cake.Name = product.Cake_Name;
            cake.Price = (float)product.Cake_Price;
            cake.Type = new DentalProduct().GetTypeName(product.Cake_Type_Code);
            cake.Discount = (float)product.Discount;
            cake.Decripsion = product.Cake_decripsion;
            cake.Images = new DentalProduct().Image(product.Cake_ID);
            relative(id);
            return View(cake);
        }
        public void relative(string id)
        {
            var cakeControl = new CakeControl();
            var dental = new DentalProduct();
            List<Cake> relative = cakeControl.ListRelatedProducts(id, 3);
            List<Cake_Dentals> cake_l = new List<Cake_Dentals>()
            {
                new Cake_Dentals(){ ID = relative[0].Cake_ID, Name=relative[0].Cake_Name, Image1 = dental.Image1(relative[0].Cake_ID),Price = (float)relative[0].Cake_Price,Decripsion = relative[0].Cake_decripsion,Type = relative[0].Cake_Type_Code},
                new Cake_Dentals(){ ID = relative[1].Cake_ID, Name=relative[1].Cake_Name, Image1 = dental.Image1(relative[1].Cake_ID),Price = (float)relative[1].Cake_Price,Decripsion = relative[1].Cake_decripsion,Type = relative[1].Cake_Type_Code},
    
            
            };

            ViewBag.RelCake = cake_l;
        }

    }
}
