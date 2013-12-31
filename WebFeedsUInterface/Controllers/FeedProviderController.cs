using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFeedsDomain.Concrete;
using WebFeedsDomain.Domain;
using WebFeedsUI.Models;

namespace WebFeedsUInterface.Controllers
{
    public class FeedProviderController : Controller
    {
        //
        // GET: /FeedProvider/
        
        public ActionResult Index(int feedProviderID)
        {
            FeedsManager manager = new FeedsManager(new EFFeedsProviderRepository());
            FeedsReader feedReader = manager.FeedsReaders.Find(f => f.FeedsProvider.ID == feedProviderID);
            feedReader.LoadFeeds();
            return View(feedReader);
        }

    }
}
