using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using buildmyunicorn.Models;
using buildmyunicorn.Business_Layer;
using System.Web.Security;

namespace buildmyunicorn.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public string ValidateUser(Customer Model)
        {
            return new CustomerManager().ValidateCustomerLogin(Model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}