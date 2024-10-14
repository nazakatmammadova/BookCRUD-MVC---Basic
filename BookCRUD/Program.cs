using Microsoft.AspNetCore.Rewrite;
using Microsoft.Data.SqlClient;

namespace BookCRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();


            app.UseStaticFiles();
            app.MapControllerRoute(
               name: "bookDetail",
               pattern: "Home/BookDetail",
               defaults: new { controller = "Home", action = "BookDetail" });

            app.MapControllerRoute(
                name: "default",
                pattern:"{Controller=Home}/{Action=Index}/{id?}"
             );

            app.Run();
        }
    }
}
