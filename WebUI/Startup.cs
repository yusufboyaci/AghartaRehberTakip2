using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
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
            services.AddScoped<IKisiRepository, KisiRepository>();
            services.AddScoped<IAdresRepository, AdresRepository>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=.;database=AghartaDb;uid=yusuf;pwd=123"));
           
            
            services.AddDistributedMemoryCache();/*�nbelle�e al�nan de�erler, uygulaman�n �al��t��� sunucudaki uygulama �rne�i �zerinde saklan�r. Asl�nda tam olarak da��t�k bir yap� de�ildir.

Tavsiye edilen kullan�m alanlar�:

Development ve Test senaryolar�
Herhangi bir b�l�m�n�n �al��mad���nda, sistemin �al��maya devam edebilmesi gerekti�inde

Startup.cs dosyas�nda kullan�m�

1
services.AddDistributedMemoryCache();*/
            services.AddSession();
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
            app.UseSession();
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
