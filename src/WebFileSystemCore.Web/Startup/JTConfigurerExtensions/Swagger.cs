using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebFileSystemCore.Web.Startup.JTConfigurerExtensions
{
    public static class Swagger
    {
        public static void JTConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                //options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, });

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1",
                    //Description = "接口文档说明",
                });
                options.DocInclusionPredicate((docName, description) => true);

                //options.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                //{
                //    Description = "Bearer {token}",
                //    Name = "Authorization",
                //    In = "header",
                //    Type = "apiKey"
                //});

                options.CustomSchemaIds(x => x.FullName);
            });
        }

        public static void JTUseSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                //options.IndexStream = () => Assembly.GetExecutingAssembly().GetManifestResourceStream("RLCore.Web.wwwroot.swagger.ui.index.html");
            });
        }
    }
}
