﻿using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using Abp.Extensions;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using WebFileSystemCore.EntityFrameworkCore;
using WebFileSystemCore.Web.Startup.JTConfigurerExtensions;

namespace WebFileSystemCore.Web.Startup
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.JTAddAbpDbContext();
            services.JTConfigureCors();
            services.JTConfigureMvc();
            services.JTConfigureSwagger();
            services.JTAddDirectoryBrowser();
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
            app.JTUseCors();
            app.JTUseMvc();
            app.JTUseSwagger(_config["SwaggerBasePath"]);

            var root = Path.Combine(Directory.GetCurrentDirectory(), WebFileSystemCoreConsts.FilePathBase);
            if (!Directory.Exists(root)) { Directory.CreateDirectory(root); }
            var shareOption = new SharedOptions
            {
                FileProvider = new PhysicalFileProvider(root),
                RequestPath = new PathString($"/{WebFileSystemCoreConsts.FilePathBase}")
            };
            app.JTUseStaticFiles(new JTStaticFileOptions(shareOption)
            {
                UseDefault = false
            });
            app.JTUseDirectoryBrowser(new DirectoryBrowserOptions(shareOption));
        }
    }
}
