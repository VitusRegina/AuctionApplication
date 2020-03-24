using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionsApp.BL;
using AuctionsApp.DAL;
using AuctionsApp.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuctionsApp
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
            services.AddDbContext<MyDbContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("AuctionDatabase")));

            services.AddSignalR();

            services.AddTransient<IThingRepo, ThingRepo>();
            services.AddTransient<ThingManager, ThingManager>();
            services.AddTransient<IAuctionRepo, AuctionRepo>();
            services.AddTransient<AuctionManager, AuctionManager>();
            services.AddTransient<IBidRepo, BidRepo>();
            services.AddTransient<BidManager, BidManager>();
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:3000");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<MyHub>("/signalRHub");
            });
        }
    }
}
