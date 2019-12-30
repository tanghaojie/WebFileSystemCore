using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFileSystemCore.Web.Startup.JTConfigurerExtensions
{
    public static class Mvc
    {
        public static void JTConfigureMvc(this IServiceCollection services)
        {
            //services.AddMvc(options =>
            //{
            //    //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            //    options.Filters.AddService(typeof(JTAbpExceptionFilter), 1);
            //});

            services.AddControllersWithViews(options =>
            {
                //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                options.Filters.AddService(typeof(JTAbpExceptionFilter), 1);
            }).AddNewtonsoftJson();
        }

        public static void JTUseMvc(this IApplicationBuilder app)
        {
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
