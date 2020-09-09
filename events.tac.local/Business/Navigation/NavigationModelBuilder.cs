using events.tac.local.Models;
using Sitecore.Data.Items;
using Sitecore.Links;
using System.Linq;

namespace events.tac.local.Business.Navigation
{
    public class NavigationModelBuilder
    {
        public NavigationMenu CreateNavigationMenu(Item root, Item current)
        {
            NavigationMenu menu = new NavigationMenu()
            {
                Title = root.DisplayName,
                URL = LinkManager.GetItemUrl(root),
                Children = root.Axes.IsAncestorOf(current) ?
                root.GetChildren().Select(i => CreateNavigationMenu(i, current)) : null
            };

            return menu;
        }
    }
}