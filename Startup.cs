using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDK._01._01_PR_38
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public static List<ItemsBasket> BasketItem = new List<ItemsBasket>();
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICategories, Data.DataBase.DBCategories>();
            services.AddTransient<IItems, Data.DataBase.DBItems>();

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();


            var provider = new FileExtensionContentTypeProvider();
            // Add new mappings
            provider.Mappings[".less"] = "text/css";

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = provider
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "items",
                    template: "{controller=Items}/{action=List}/{id?}");

                routes.MapRoute(
                    name: "additem",
                    template: "{controller=Items}/{action=Add}/");

                routes.MapRoute(
                    name: "test",
                    template: "{controller=Items}/{action=Test}/");

                routes.MapRoute(
                    name: "categories",
                    template: "{controller=Categories}/{action=List}/{id?}");
            });
        }
    }
}
