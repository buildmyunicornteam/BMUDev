using buildmyunicorn.Helper;
using System.Web.Mvc;
using buildmyunicorn.Models;


namespace buildmyunicorn.Controllers
{
    public class DashboardController : Controller
    {
     //  [CustomAuthorize]
        // GET: Dashboard
        public ActionResult Index(Customer M)
        {
            return View();
        }
    }
}