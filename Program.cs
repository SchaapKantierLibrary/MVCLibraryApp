using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MVCLibraryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register the ApplicationDbContext DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register the ApplicationDbContext DbContext and Identity services
            builder.Services.AddDefaultIdentity<BezoekerModel>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Configure cookies and authentication options
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Bezoeker/Login";
                options.LoginPath = "/Bezoeker/Login";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Add authentication
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "logout",
                pattern: "Account/Logout",
                defaults: new { controller = "Bezoeker", action = "Logout" }
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );
            app.MapControllerRoute(
    name: "dashboard",
    pattern: "Bezoeker/Dashboard",
    defaults: new { controller = "Bezoeker", action = "Dashboard" }
);


            app.Run();
        }
    }
}