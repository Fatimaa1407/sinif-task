using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.DAL;

namespace WebApplication4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            var app = builder.Build();
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{Controller=Dashboard}/{Action=Index}/{Id?}");
            app.MapControllerRoute(
                name: "Default",
                pattern: "{Controller=Home}/{Action=Index}/{Id?}");
            app.UseStaticFiles();
            app.Run();
        }
    }
}
