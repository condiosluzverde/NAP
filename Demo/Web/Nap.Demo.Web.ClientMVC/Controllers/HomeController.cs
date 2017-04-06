using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Nap.Demo.Web.ClientMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
