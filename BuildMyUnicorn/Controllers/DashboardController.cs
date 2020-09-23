using System.Web.Mvc;
using BuildMyUnicorn.Business_Layer;
using Model_Layer.Models;

namespace BuildMyUnicorn.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetClientIdeaProgressData()
        {
            return Json(new Dashboard().GetIdeaProgressData(), JsonRequestBehavior.AllowGet);
        }
    }
}