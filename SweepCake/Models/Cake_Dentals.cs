using Shop_data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SweepCake.Models
{
    public class Cake_Dentals
    {
        public List<string> Images { get; set; }
        public string Image1 { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public string Decripsion { get; set; }
        public float Discount { get; set; }
        public string Type { get; set; }
        public string TypeCode { get; set; }
        public string Meta_Title { get; set; }
    }
}