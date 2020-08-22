using events.tac.local.Models;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class OverviewController : Controller
    {
        // GET: Overview
        public ActionResult Index()
        {
            var model = new OverviewList();
            var children = RenderingContext.Current.ContextItem
                .GetChildren(Sitecore.Collections.ChildListOptions.SkipSorting)
                .OrderBy(i => i.Created);
            model.AddRange(children.Select(i => new OverviewItem() { 
                URL = LinkManager.GetItemUrl(i),
                ContentHeading = new HtmlString(FieldRenderer.Render(i,"contentheading")),
                DecorationBanner = new HtmlString(FieldRenderer.Render(i, "decorationbanner", "mw=500&mh=333"))
            }));

            return View(model);
        }
    }
}