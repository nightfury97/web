using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_data.Control
{
    public class Cake_Type_Control
    {
        DataDataContext db = null;
        public  Cake_Type_Control()
        {
            db = new DataDataContext();
        }
        public List<Cake_Type> ListAll()
        {
            return db.Cake_Types.Where(x => x.Status == true).OrderBy(x => x.The_Order).ToList();
        }
        public List<string> ListCakes(string code)
        {
            return db.Cakes.Where(x => x.Cake_Type_Code == code).OrderByDescending(x=>x.CreateDate).Select(x=>x.Cake_ID).ToList();
        }
        public string ListFirst()
        {
            return db.Cake_Types.Where(x => x.Status == true).OrderBy(x => x.The_Order).Select(x => x.Cake_Type_Code).FirstOrDefault().ToString();
        }
    }
}
