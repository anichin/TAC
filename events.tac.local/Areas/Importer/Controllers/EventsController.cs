using events.tac.local.Areas.Importer.Models;
using Newtonsoft.Json;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Areas.Importer.Controllers
{
    public class EventsController : Controller
    {
        // GET: Importer/Events
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string parentPath)
        {
            IEnumerable<Event> events = null;
            string message = null;
            using (var reader = new StreamReader(file.InputStream))
            {
                var contents = reader.ReadToEnd();
                try
                {
                    events = JsonConvert.DeserializeObject<IEnumerable<Event>>(contents);
                    var database = Sitecore.Configuration.Factory.GetDatabase("master");
                    Item parentItem = database.GetItem(parentPath);
                    TemplateID templateID = new TemplateID(new ID("{04FAF783-9B3E-4A1A-897E-D3F1E3B85BA8}"));

                    using (new SecurityDisabler())
                    {
                        foreach (var ev in events)
                        {
                            string name = ItemUtil.ProposeValidItemName(ev.Name);
                            Item item = parentItem.Add(name, templateID);
                            item.Editing.BeginEdit();
                            //assign values for all the fields, for example for ContentHeading:
                            item["ContentHeading"] = ev.ContentHeading;
                            item["ContentIntro"] = ev.ContentIntro;
                            item["Highlights"] = ev.Highlights;
                            item["StartDate"] = Sitecore.DateUtil.ToIsoDate(ev.StartDate);
                            item["Duration"] = ev.Duration.ToString();
                            item["Difficulty"] = ev.Difficulty.ToString();

                            item[FieldIDs.Workflow] = "{FCB15A5D-59C5-48A4-8016-6AC593BE40A6}";
                            item[FieldIDs.WorkflowState] = "{AD8C8540-F021-44A1-A02C-4824C2AD06D7}";
                            item.Editing.EndEdit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }
    }
}