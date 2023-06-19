// Programmeurs: Quinten Schaap, S1190289. Robin Kantier, S1186143.


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using MVCLibraryApp.Interfaces;
using MVCLibraryApp.Services;
using MVCLibraryApp.Data;

namespace MVCLibraryApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider(); 

            builder.Services.AddSession(); 

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDefaultIdentity<BezoekerModel>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

     
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Bezoeker/Login";
                options.LoginPath = "/Bezoeker/Login";
            });

        
            builder.Services.AddScoped<IAccountService, AccountService>();

          
            builder.Services.AddScoped<IUserRedirectionService, UserRedirectionService>(); 

            builder.Services.AddScoped<IGenerateInvoiceService, GenerateInvoiceService>();

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            
            app.UseSession();

          
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

         
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
