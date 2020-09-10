using buildmyunicorn.Business_Layer;
using buildmyunicorn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace buildmyunicorn.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignupSuccess()
        {
            return View();
        }


        public ActionResult ResetPasswordEmailSuccess()
        {
            return View();
        }

        public ActionResult EmailVerification()
        {
          
            if (Request.QueryString["refid"] != null)
            {


                string[] returnvalue = new string[3];
                returnvalue = new CustomerManager().ConfirmEmail(Request.QueryString["refid"].ToString());

                if (returnvalue[0] == "OK")
                {
                    ViewBag.CustomerID = returnvalue[1];
                    ViewBag.ConfirmationID = returnvalue[2];
                    ViewBag.CustomerName = returnvalue[3];
                    return View();
                }
                else
                {
                    return PartialView("_BadRequest");

                }
            }
            else
            {
                return PartialView("_BadRequest");

            }
        }


        public ActionResult ForgotPassword()
        {
            return View();
        }

      
        public ActionResult ResetPassword()
        {

            if (Request.QueryString["refid"] != null)
            {


                string[] returnvalue = new string[3];
                returnvalue = new CustomerManager().ConfirmResetPassword(Request.QueryString["refid"].ToString());

                if (returnvalue[0] == "OK")
                {
                    ViewBag.CustomerID = returnvalue[1];
                    ViewBag.ConfirmationID = returnvalue[2];
                    ViewBag.CustomerName = returnvalue[3];
                    return View();
                }
                else
                {
                    return PartialView("_BadRequest");

                }
            }
            else
            {
                return PartialView("_BadRequest");

            }
        }


        public string UpdatePassword(Customer Model)
        {
            new CustomerManager().UpdateCustomerEmailConfirmation(Model);
            FormsAuthentication.SetAuthCookie(Model.CustomerID.ToString(), true);
            return new CustomerManager().UpdateCustomerPassword(Model);
        }

        public string UpdateForgotPassword(Customer Model)
        {
            new CustomerManager().UpdateCustomerCustomerForgotPassword(Model);

            return new CustomerManager().UpdateCustomerPassword(Model);
        }
        

        public string AddCustomer(Customer Model)
        {

             return  new CustomerManager().AddNewCustomer(Model);
        
        }
        public string SendPasswordResetLink(String Email)
        {
           
            return new CustomerManager().SendPasswordRestLink(Email);
        }
        
        public JsonResult GetCountryList()
        {
           
            IEnumerable<Country> countryList = new CountryManager().GetCountryList();
            return Json(new { country = countryList }, JsonRequestBehavior.AllowGet);
        }
    }
}