using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VitruviSoft.BLL;
using VitruviSoft.BLL.Interfaces;
using VitruviSoft.BLL.Models;
using VitruviSoft.BLL.Services;
using VitruviSoft.DAL;
using VitruviSoft.DAL.Entities;
using VitruviSoft.DAL.Interfaces;
using VitruviSoft.DAL.Repositories;

namespace VitruviSoft.PresentationLayer
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
            services.AddDbContext<GroupContext>( options => options.UseSqlServer(Configuration["DB"], b => b.MigrationsAssembly("VitruviSoft.PresentationLayer")));
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IProviderService, ProviderService>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Group}/{action=AllGroups}/{id?}");
            });
        }
    }
}
