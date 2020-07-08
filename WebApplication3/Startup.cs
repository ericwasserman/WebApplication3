using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WebApp.Data.Repositories.Interfaces;
using WebApp.Data.Repositories;
using WebApp.Service;
using WebApp.Service.Interfaces;

namespace WebApplication3
{
    using WebApp.Database;

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
            var result = Deployer.DeployDatabase(Configuration.GetConnectionString("DefaultConnection"));
            if (!result.Successful)
            {
                throw result.Error;
            }

            services.AddControllers().AddNewtonsoftJson();
            services.AddControllersWithViews();

            services.AddScoped(typeof(IDriverRepository), typeof(DriverRepository));
            services.AddScoped(typeof(IDriverService), typeof(DriverService));

            services.AddScoped(typeof(IRiderRepository), typeof(RiderRepository));
            services.AddScoped(typeof(IRiderService), typeof(RiderService));

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
