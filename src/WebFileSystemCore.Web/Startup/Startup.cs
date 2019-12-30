using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Globalization;
using WebFileSystemCore.EntityFrameworkCore;
using WebFileSystemCore.Web.Startup.JTConfigurerExtensions;

namespace WebFileSystemCore.Web.Startup
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.JTAddAbpDbContext();
            services.JTConfigureMvc();
            services.JTConfigureCors();
            services.JTConfigureSwagger();

          
            return services.JTAddAbp();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp();
            if (env.IsDevelopment())
            {
                app.UseDevException();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.JTUseCors();
            app.JTUseMvc();
            app.JTUseSwagger();
        }
    }
}
