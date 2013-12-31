using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFeedsDomain.Concrete;
using WebFeedsUI.Models;

namespace WebFeedsUInterface.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            FeedsManager manager = new FeedsManager(new EFFeedsProviderRepository());
            List<FeedsReader> itemsList = manager.FeedsReaders;

            return View(itemsList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
