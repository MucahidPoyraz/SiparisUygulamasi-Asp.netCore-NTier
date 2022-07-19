using Farmasi.BL.Abstract;
using Farmasi.BL.Concrete;
using Farmasi.DAL.Abstract;
using Farmasi.DAL.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Farmasi.UI
{
    public class Startup
    {
   
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddTransient(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddTransient(typeof(IGenericRepository<>), typeof(EfGenericepository<>));

            services.AddScoped<IUrunService, UrunService>();
            services.AddScoped<ISiparisService, SiparisService>();
            services.AddScoped<IAltKategoriService, AltKategoriService>();
            services.AddScoped<IUrunSepetService, UrunSepetService>();
            services.AddScoped<IUrunSepetRepository, EfUrunSepetRespository>();
            services.AddScoped<IUrunSiparisService, UrunSiparisService>();
            services.AddScoped<IUrunSiparisRepository, EfUrunSiparisRepository>();


            services.AddSession(option =>
            {
                //Süre 60 dk olarak belirlendi
                option.IdleTimeout = TimeSpan.FromMinutes(60);
            });
            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(optinos =>
            {
                optinos.LoginPath = "/Yonetim/Index/";
            });

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
            }
            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseDeveloperExceptionPage();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
