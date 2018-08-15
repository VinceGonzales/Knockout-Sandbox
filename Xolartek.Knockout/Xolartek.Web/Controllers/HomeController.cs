using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xolartek.Web.Models;

namespace Xolartek.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewModel viewmodel = new ViewModel();
            return View(viewmodel);
        }
    }
}