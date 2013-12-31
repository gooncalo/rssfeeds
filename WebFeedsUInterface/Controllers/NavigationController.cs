using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFeedsDomain.Concrete;
using WebFeedsDomain.DAL;
using WebFeedsUI.Models;

namespace WebFeedsUInterface.Controllers
{
    public class NavigationController : Controller
    {
        //
        // GET: /Navigation/

        public PartialViewResult Index()
        {
            return PartialView();
        }

        public ViewResult Home()
        {
            FeedsManager manager = new FeedsManager(new EFFeedsProviderRepository());
            List<FeedsReader> itemsList = manager.FeedsReaders;

            return View(itemsList);
        }

        public ViewResult All()
        {
            FeedsManager manager = new FeedsManager(new EFFeedsProviderRepository());
            List<FeedsReader> itemsList = manager.FeedsReaders;
            return View(itemsList);
        }
    }
}
