using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using MVCLibraryApp.Interfaces;
using MVCLibraryApp.Services;

namespace MVCLibraryApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider(); // Add this line

            builder.Services.AddSession(); // Add this line

            // Register the ApplicationDbContext DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register the ApplicationDbContext DbContext and Identity services
            builder.Services.AddDefaultIdentity<BezoekerModel>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Configure cookies and authentication options
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Bezoeker/Login";
                options.LoginPath = "/Bezoeker/Login";
            });

            // Register the Account Service
            builder.Services.AddScoped<IAccountService, AccountService>();

            // Register the User Redirection Service
            builder.Services.AddScoped<UserRedirectionService>(); // Add this line before building the app

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Use Session here
            app.UseSession(); // Add this line

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


            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                var userManager = services.GetRequiredService<UserManager<BezoekerModel>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await DbInitializer.Initialize(context, userManager, roleManager);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }

            app.Run();
        }
    }
}
