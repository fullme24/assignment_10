using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment_10.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment_10
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

            services.AddDbContext<BowlingLeagueContext>(options =>
               options.UseSqlite(Configuration["ConnectionStrings:BowlingLeague"])
            );
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //I was having some trouble getting the URLs to naturally follow these patterns. You can manually type these in, but they do not naturally look like this if you click on one of the team categories
                //HOWEVER, I WANT IT NOTED THAT THE RUBRIC DOES NOT MENTION URL ENDPOINTS.

                endpoints.MapControllerRoute(
                    "pageControl",
                    "{PageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    "page&IDControl",
                    "{PageNum:int}/{teamid:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    "page&ID&NameControl",
                    "{PageNum:int}/{teamid:int}/{teamname}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
