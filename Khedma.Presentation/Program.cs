using Keadma.DataAccess.Data;
using Keadma.DataAccess.Helpers;
using Keadma.DataAccess.Implementation;
using Khedma.Entites.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Khedma.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure database context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Register Unit of Work and Helper
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IHelper, Helper>();

            // Configure session with custom options
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
                options.Cookie.HttpOnly = true; // Protect session cookie
                options.Cookie.IsEssential = true; // Mark session cookie as essential
            });

            // Add authentication using Cookies (this is important for session-based authentication)
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login"; // Path to redirect users who are not authenticated
                    options.LogoutPath = "/Account/Logout"; // Path to log users out
                    options.AccessDeniedPath = "/Account/Unauthorized"; // Path when access is denied
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Account/Error");
                app.UseHsts();
            }

            // Ensure the session is used before routing
            app.UseSession();

            //app.UseMiddleware<ErrorHandler>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Enable authentication and authorization
            app.UseAuthentication();  // Enables authentication
            app.UseAuthorization();   // Enables authorization

            // Set default route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
