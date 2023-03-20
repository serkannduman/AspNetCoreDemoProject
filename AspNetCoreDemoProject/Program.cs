using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Net;

namespace AspNetCoreDemoProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();



            builder.Services.AddMvc(config =>   //T�m projeye eri�im engeli koyuyor , Login controllerda index metoduna AllowAnonymous attribute'i koyduk giri� yapt�ktan sonra di�er actionlara eri�im engelini kald�r�caz 
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            builder.Services.AddMvc();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index"; // Giri� yapmayan kullanc�lar� di�er sayfalara t�klad�g�nda  Login/Index action'�na y�nlendirdik.
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();



            app.UseRouting();

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