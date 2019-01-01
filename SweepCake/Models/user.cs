using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SweepCake.Models
{
    [Serializable]
    public class user
    {
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
    }
}