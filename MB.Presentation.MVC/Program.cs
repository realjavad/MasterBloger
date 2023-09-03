using MB.Domain.ArticleCategoryApp.Exception;
using MB.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace MB.Presentation.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            ConfigurationManager configuration = builder.Configuration;


            Bootstrapper.Config(builder.Services, configuration.GetConnectionString("MasterBlogDB"));

            builder.Services.AddRazorPages();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                //app.UseExceptionHandler("/Error");
                app.UseStatusCodePages("text/plain", "you have error {0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}