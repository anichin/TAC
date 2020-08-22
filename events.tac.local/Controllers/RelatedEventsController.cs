using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using events.tac.local.Models;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;

namespace events.tac.local.Controllers
{
    public class RelatedEventsController : Controller
    {
        // GET: RelatedEvents
        public ActionResult Index()
        {
            Item context = RenderingContext.Current.ContextItem;
            MultilistField relatedEvents = context.Fields["RelatedEvents"];
            var events = relatedEvents.GetItems()
            .Select(i => new NavigationItem()
             {
                Title = i.DisplayName,
                URL = LinkManager.GetItemUrl(i)
             });

            return View(events);
        }
    }
}