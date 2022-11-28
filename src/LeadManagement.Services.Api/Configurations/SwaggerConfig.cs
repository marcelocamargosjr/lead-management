using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace LeadManagement.Services.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services, string environmentName)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = $"{environmentName} - v1 - {DateTime.Now}",
                    Title = "Lead Management",
                    Description = "Lead Management API Swagger surface",
                    Contact = new OpenApiContact { Name = "Marcelo Camargos da Silva Júnior", Email = "marcelocamargosjr@gmail.com", Url = new Uri("http://www.marcelocamargos.com.br") }
                });

                s.DescribeAllParametersInCamelCase();
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app is null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.DocExpansion(DocExpansion.None);
            });
        }
    }
}