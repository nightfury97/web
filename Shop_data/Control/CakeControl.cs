using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_data.ViewCake;


namespace Shop_data.Control
{
    public class CakeControl
    {
        DataDataContext data = null;
        public CakeControl()
        {
            data = new DataDataContext();
        }
        public List<Cake> ListNewProduct(int top)
        {
            return data.Cakes.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public List<string> ListName(string keyword)
        {
            return data.Cakes.Where(x => x.Cake_Name.Contains(keyword)).Select(x => x.Cake_Name).ToList();
        }
        public List<Cake> ListRelatedProducts(string Id,int top)
        {
            var product = data.Cakes.Where(x=> x.Cake_ID==Id).FirstOrDefault();
            return data.Cakes.Where(x => x.Cake_ID != Id && x.Cake_Type_Code == product.Cake_Type_Code).Take(top).ToList();
        }
        public List<Cake> ListHotProduct(int top)
        {
            return data.Cakes.OrderByDescending(x => x.Sold).Take(top).ToList();
        }
        //public List<ViewCake> Search(string keyword, ref int totalRecord/*, int pageIndex = 1, int pageSize = 2*/)
        //{
        //    totalRecord = data.Cakes.Where(x => x.Cake_Name == keyword).Count();
        //    var model = (from a in data.Cakes
        //                 join b in data.Cake_Types
        //                 on a.Cake_Type_Code equals b.Cake_Type_Code
        //                 where a.Cake_Name.Contains(keyword)
        //                 select new
        //                 {
        //                     CateMetaTitle = b.Meta_Title,
        //                     CateName = b.Cake_Type_Name,
        //                     CreatedDate = a.CreateDate,
        //                     ID = a.Cake_ID,
        //                     Images = newDentalProduct,
        //                     Name = a.Name,
        //                     MetaTitle = a.MetaTitle,
        //                     Price = a.Price
        //                 }).AsEnumerable().Select(x => new ProductViewModel()
        //                 {
        //                     CateMetaTitle = x.MetaTitle,
        //                     CateName = x.Name,
        //                     CreatedDate = x.CreatedDate,
        //                     ID = x.ID,
        //                     Images = x.Images,
        //                     Name = x.Name,
        //                     MetaTitle = x.MetaTitle,
        //                     Price = x.Price
        //                 });
        //    model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //    return model.ToList();
        //}
    }
}
