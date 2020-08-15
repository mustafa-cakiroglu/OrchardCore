using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Apis;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.ProductModule.Migrations;
using OrchardCore.ProductModule.Models;

namespace OrchardCore.ProductModule
{
    public class Startup: StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataMigration, Migration>();
            services.AddScoped<INavigationProvider, AdminMenu>();
        }
    }
}
