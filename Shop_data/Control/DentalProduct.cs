using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_data.Control
{
    public class DentalProduct
    {
        DataDataContext data = null;
        public DentalProduct()
        {
            data = new DataDataContext();
        }
        public Cake GetByID(string ID)
        {
            return data.Cakes.SingleOrDefault(x => x.Cake_ID == ID);
        }
        public string GetTypeName(string code)
        {
            Cake_Type a = data.Cake_Types.SingleOrDefault(x => x.Cake_Type_Code == code);
            return a.Cake_Type_Name;
        }
        public List<string> Image(string ID)
        {
            List<Cake_Image> aa = data.Cake_Images.Where(x => x.Cake_ID == ID).ToList();
            List<string> image = new List<string>();
            foreach(Cake_Image a in aa)
            {
                image.Add(a.Cake_Image1.ToString());
            }
            return image;
        }
        public string Image1(string ID)
        {
            var aa = data.Cake_Images.Where(x => x.Cake_ID == ID).FirstOrDefault();
            if(aa!=null)
            { 
            string a = aa.Cake_Image1.ToString();
            return a;
            }
            return "/Images/logo.png";
        }
    }
}
