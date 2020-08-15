using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrchardCore.Apis;
using OrchardCore.Modules;
using OrchardCore.ProductModule.Models;

namespace OrchardCore.Web
{
    [RequireFeatures("OrchardCore.Apis.GraphQL")]
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Orchard Gelecek
            services.AddOrchardCms();
            services.AddObjectGraphType<Product, ProductObjectType>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseOrchardCore();

        }
    }
}
