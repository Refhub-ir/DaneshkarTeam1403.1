using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Refhub_Ir.Data.Context;
using Refhub_Ir.Data.Models;
using Refhub_Ir.Service.Implement;

using Refhub_Ir.Service.Interface;

using Refhub_Ir.Service.Interfaces;
using Refhub_Ir.Tools.ExtentionMethod;


namespace Refhub_Ir
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //Add  CUstomServices




            #region CustomExtentionMethod 
            builder.Services.AddCustomService();
            builder.Services.ConfigureContext(builder.Configuration);
            builder.Services.ConfigureCookie();
            builder.Services.ConfigureIdentity();
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();



            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
