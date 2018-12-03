using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_data.Control;
using Shop_data.FrameWork;
using SweepCake.Common;
using SweepCake.Models;

namespace SweepCake.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //[CaptchaValidation("CaptchaCode", "registerCapcha", "Mã xác nhận không đúng!")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoginControl();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "ID is used");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email is used");
                }
                else
                {
                    bool result =  dao.register(model.UserName, model.Name, model.Phone, model.Email, model.Address, Encryptor.MD5Hash(model.Password));                  
                    if (result)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                  
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }

       
        public ActionResult register()
        {

            return View();
        }
    }
}