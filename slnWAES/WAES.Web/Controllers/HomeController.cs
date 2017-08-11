using System.Web.Mvc;

namespace WAES.Web.Controllers
{
    /// <summary>
    /// Not used!
    /// </summary>
    [RoutePrefix("api/Home")]
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
