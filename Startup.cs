using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using APIConsume.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System;


namespace APIConsume
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<SIATMAX_SISTERContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());
            services.AddDbContext<DATA_SISTERContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DataSisterConnection")).EnableSensitiveDataLogging());
            services.AddDbContext<DATA_SISTERContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SIATMA_UAJYConnection")).EnableSensitiveDataLogging());
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddProgressiveWebApp();
            services.AddControllers().AddNewtonsoftJson();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {

                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                //nampaknya yang dibawah ini tidak berfungsi
                endpoints.MapControllerRoute(
                    name: "SemuaDosen",
                    pattern: "{controller=SemuaDosenController}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                  name: "SimkaHome",
                  pattern: "{controller=SimkaHomeController}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
               name: "SimkaPengembangan",
               pattern: "{controller=SimkaPengembanganController}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }


}