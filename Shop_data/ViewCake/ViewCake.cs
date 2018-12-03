//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Shop_data.ViewCake
{
    public class ViewCake
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