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

namespace events.tac.local.Controllers
{
    public class EventIntroController : Controller
    {
        // GET: EventIntro
        public ActionResult Index()
        {
            return View(CreateModel());
        }
        public static EventIntro CreateModel()
        {
            Item item = RenderingContext.Current.ContextItem;
            return new EventIntro()
            {

                ContentHeading = new HtmlString(FieldRenderer.Render(item, "ContentHeading")),
                ContentBody = new HtmlString(FieldRenderer.Render(item, "ContentBody")),
                EventImage = new HtmlString(FieldRenderer.Render(item, "EventImage", "mw=400")),
                Highlights = new HtmlString(FieldRenderer.Render(item, "Highlights")),
                ContentIntro = new HtmlString(FieldRenderer.Render(item, "ContentIntro")),
                StartDate = new HtmlString(FieldRenderer.Render(item, "StartDate", "format=MMMM dd, yyyy")),
                Duration = new HtmlString(FieldRenderer.Render(item, "Duration")),
                Difficulty = new HtmlString(FieldRenderer.Render(item, "Difficulty"))
            };
        }
    }
}