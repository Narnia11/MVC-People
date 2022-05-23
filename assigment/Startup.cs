using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using assignment.Models;
using assignment.Models;

namespace assigment
{
    public class Startup

    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            /* for sql connection*/
            services.AddDbContext<ExDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));

            /*End for sql connection*/

            /*add dependency injection*/
            services.AddScoped<IPeopleRepo, DatabasePeopleRepo>();
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<ICityRepo, DatabaseCityRepo>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryRepo, DatabaseCountryRepo>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ILanguageRepo, DatabaseLanguageRepo>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IPersonLanguageRepo, DatabasePersonLanguageRepo>();
            services.AddScoped<IPersonLanguageService, PersonLanguageService>();
            services.AddScoped<ExDBContext, ExDBContext>();
            /*End add dependency injection*/


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();//to able project to load local files

            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
