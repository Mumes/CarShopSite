using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testSite.Data;
using testSite.Data.Interfaces;
using testSite.Data.Mocks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using testSite.Data.Repository;
using testSite.Data.Models;

namespace testSite
{
    public class Startup
    {
        private IConfigurationRoot confString;


        public Startup(IHostingEnvironment env)
        {

            confString = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars,CarRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor> ();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();            
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(route => {
                route.MapRoute("default", "{controller=Home}/{action = Index}/{id?}");
                route.MapRoute("categoryFilter", "{controller=Car}/{action = List}/{category?}");
           
                });
            using (var scope = app.ApplicationServices.CreateScope())
            {
               AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
               DBOblects.Initial(content);
            }
        }
    }
}
