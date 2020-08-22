using events.tac.local.Models;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc.Helpers;
using Sitecore.Links;

namespace events.tac.local.Controllers
{
    public class BreadcrumbController : Controller
    {
        // GET: Breadcrumb
        public ActionResult Index()
        {
            return View(CreateModel());
        }

        public IEnumerable<NavigationItem> CreateModel()
        {
            Item item = RenderingContext.Current.ContextItem;
            Item homeItem = Sitecore.Context.Database.GetItem("/sitecore/Content/Events/Home");
            IEnumerable<Item> breadcrumb = item.Axes.GetAncestors()
                .Where(i => i.Axes.IsDescendantOf(homeItem))
                .Concat(new Item[] { item });

            IEnumerable<NavigationItem> NavigationList = breadcrumb.Select(s => new NavigationItem
            {
                Title = s.DisplayName,
                URL = LinkManager.GetItemUrl(s),
                Active = (s.ID == item.ID)
            });

            return NavigationList;
        }
    }
}