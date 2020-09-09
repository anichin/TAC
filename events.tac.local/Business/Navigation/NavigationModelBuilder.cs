using events.tac.local.Models;
using System.Linq;
using TAC.Utils.Abstractions;

namespace events.tac.local.Business.Navigation
{
    public class NavigationModelBuilder
    {
        public NavigationMenu CreateNavigationMenu(IItem root, IItem current)
        {
            NavigationMenu menu = new NavigationMenu()
            {
                Title = root.DisplayName,
                URL = root.GetUrl(),
                Children = root.GetChildren().Select(i => CreateNavigationMenu(i, current))
            };

            return menu;
        }
    }
}