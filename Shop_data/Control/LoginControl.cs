using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_data.Control
{
    public class LoginControl
    {
        DataDataContext data = null;
        public LoginControl()
        {
            data = new DataDataContext();
        }
        public int login(string user,string pass)
        {
            var res = data.check_login(user, pass).SingleOrDefault();
            if (res == null)
                return 0;
            else
            {
                return Convert.ToInt32(data.isRule(user, pass).ToString());
            }                
        }
        public LoginSystem GetByID(string userName)
        {
            return data.LoginSystems.SingleOrDefault(x => x.ID == userName);
        }
        public Customer GetCustomerByID(string userName)
        {
            return data.Customers.SingleOrDefault(x => x.Customer_ID == userName);
        }
        public bool CheckUserName(string userName)
        {
            return data.LoginSystems.Count(x => x.ID == userName) > 0;
        }
        public bool CheckEmail(string Email)
        {
            return data.Customers.Count(x => x.Customer_Email == Email) > 0;
        }
        public bool register(string user,string name,string phone,string email,string address, string pass)
        {
            var a = data.add_customer(user, pass, name, phone, email, address);
            if (a>0)
                return false;
            else return true;
        }
    }
}
