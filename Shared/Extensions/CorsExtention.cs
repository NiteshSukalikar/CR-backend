using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Extentions
{
    public static class CorsExtention
    {
        public static IServiceCollection UseCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.WithOrigins("https://stagingwin.com:9430", "http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
            return services;
        }

        public static IApplicationBuilder UseCors(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseCors("CorsPolicy");
            return app;
        }

    }
}
