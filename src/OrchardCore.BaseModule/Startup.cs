using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;

namespace OrchardCore.BaseModule
{
    public class Startup: StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

        }

        //public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        //{
        //    builder.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapAreaControllerRoute(
        //        name: "sites",
        //        areaName: "BaseModule",
        //        pattern: "sites/{action}",
        //        defaults: new { controller = "Home", action = "Index" }
        //    );
        //    });
        //}
    }
}