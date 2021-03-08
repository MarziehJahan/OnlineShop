using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PresentationHost.Models;
using PresentationHost.PaymentSystems;
using TK.Core.ApplicationService;
using TK.Core.Contracts.Pay;
using TK.Core.Contracts.Repository;
using TK.Core.Contracts.Service;
using TK.Core.Entites;
using TK.Infrastruture.Data;
using TK.Infrastruture.Sql;

namespace PresentationHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DemoContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("ShopCS"));
            });
            services.AddDbContext<IdentityContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("IdentityCS"));
            });
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.AddSession();
            services.AddTransient<IPayment, PayIr>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProdctService, ProductService>();

            services.AddTransient<Cart>(sp => SessionCart.GetCart(sp));

            services.AddScoped<IOrderRepository, OrederRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IDealerRepository, DealerRepository>();
            services.AddScoped<IDealerService, DealerService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

           
            app.UseAuthentication();
            
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
     
            
       
        }
    }
}
