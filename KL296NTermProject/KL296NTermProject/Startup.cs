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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KL296NTermProject.Models;

namespace KL296NTermProject
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
            services.AddIdentity<AppUser, IdentityRole>()
           .AddEntityFrameworkStores<DataDbContext>()
           .AddDefaultTokenProviders();

            services.AddControllersWithViews();

            services.AddDbContext<DataDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:SQLServerConnection"]));
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

            var services = app.ApplicationServices;
            var context = services.GetRequiredService<DataDbContext>();
            var usr = services.GetRequiredService<UserManager<AppUser>>();
            var role = services.GetRequiredService<RoleManager<IdentityRole>>();
            // var role = services.GetRequiredService<UserManager<IdentityRole>>();
            Seed.starter(context, usr, role);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // add authentication 
            app.UseAuthentication();
            // then authorization
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
