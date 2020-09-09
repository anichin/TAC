using System.Linq;
using System.Web.Mvc;
using events.tac.local.Business.Navigation;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace events.tac.local.Controllers
{
    public class NavigationController : Controller
    {
        private readonly NavigationModelBuilder _modelBuilder;
        private readonly RenderingContext _renderingContext;
        public NavigationController(NavigationModelBuilder modelBuilder, RenderingContext renderingContext)
        {
            _modelBuilder = modelBuilder;
            _renderingContext = renderingContext;
        }

        // GET: Navigation
        public ActionResult Index()
        {
            Item currentItem = _renderingContext.ContextItem;
            Item section = currentItem.Axes.GetAncestors()
                .FirstOrDefault(i => i.TemplateName == "Event Section");
            var model = _modelBuilder.CreateNavigationMenu(section, currentItem);

            return View();
        }
    }
}