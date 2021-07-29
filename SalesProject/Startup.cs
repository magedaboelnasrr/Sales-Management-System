using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesProject.BL.Interface;
using SalesProject.BL.Mapper;
using SalesProject.BL.Repository;
using SalesProject.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject
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
            services.AddControllersWithViews();

            // DbContext
            services.AddDbContext<DbContainer>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DbErpSsystemConnection")));

            // Auto Mapper
            services.AddAutoMapper(a => a.AddProfile(new DomainProfile()));

            // Category Controller Instance
            services.AddScoped<ICategoryRep, CategoryRep>();

            // Supplier Controller Instance
            services.AddScoped<ISupplierRep, SupplierRep>();

            // Purchase Controller Instance
            services.AddScoped<IPurchaseRep, PurchaseRep>();

            // Customer Controller Instance
            services.AddScoped<ICustomerRep, CustomerRep>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
