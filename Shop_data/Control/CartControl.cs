using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_data.Control
{
    public class CartControl
    {
        DataDataContext data = null;
        public CartControl()
        {
            data = new DataDataContext();
        }
        public bool checkPayment(string userID,string number)
        {
           var flag = data.check_card(number,userID).SingleOrDefault();
            if (flag == null) return false;
            else return true;
        }
        public string paymentID(string userID,string number)
        {
            //var result = data.Customer_Payment_Methods.Where(x => x.Customer_ID == userID && x.Card_Number == number).Select(x=>x.Customer_Payment_ID);
            string ID = (from IDS in data.Customer_Payment_Methods
                         where IDS.Customer_ID == userID && IDS.Card_Number == number
                         select IDS.Customer_Payment_ID).First().ToString();

            return ID;
        }
        public string CartID(string UserID,DateTime a)
        {
            string ID = (from IDS in data.Carts
                         where IDS.Customer_ID == UserID && IDS.Payment_time == a
                         select IDS.Cart_ID).First().ToString();
            return ID;
        }
        public List<Cart> order(string userID)
        {
            return data.Carts.Where(x => x.Customer_ID == userID && x.Cart_Status != 0).ToList();
        }
        public bool insert(Customer_Payment_Method ua)
        {
            try
            {
                data.Customer_Payment_Methods.InsertOnSubmit(ua);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool insertorder(string ID,string paymentID,DateTime a,string name,string address,string phone,string email,int STT)
        {
            try
            {
                data.add_order(ID, paymentID, a,name,address, phone, email, STT);
                return true;
            }
            catch
            {
                return false;
            }
               
        }
        public bool insertcakes(Cart_Item it)
        {
            try
            {
                data.Cart_Items.InsertOnSubmit(it);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
