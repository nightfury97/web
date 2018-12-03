using Shop_data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SweepCake.Models
{
    [Serializable]
    public class CartItem
    {        
        public Cake Cake { set; get; }
        public int Quantity { set; get; }
        public string image { set; get; }
        public float price { set; get; }
        public string other { set; get; }
    }
}