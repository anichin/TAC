using events.tac.local.Business.Navigation;
using events.tac.local.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Mvc.Presentation;

namespace events.tac.local.Business
{
    public class ServicesConfigurator : Sitecore.DependencyInjection.IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<NavigationModelBuilder>();
            serviceCollection.AddTransient<NavigationController>();
            serviceCollection.AddTransient<RenderingContext>((r) => RenderingContext.Current);
        }
    }
}