using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var audienceConfig = Configuration.GetSection("Audience");

            var mySecret = "Y2F0Y2hlciUyMHdvbmclMjBsb3ZlJTIwLm5ldA==";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = mySecurityKey,
                ValidateIssuer = true,
                ValidIssuer = "http://www.c-sharpcorner.com/members/catcher-wong",
                ValidateAudience = true,
                ValidAudience = "Catcher Wong",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
            };

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = "TestKey";
            })
            .AddJwtBearer("TestKey", x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = tokenValidationParameters;
            });
            services.AddOcelot(Configuration);
            services.AddControllers().AddNewtonsoftJson();
            services.AddSingleton(Configuration);

            services.AddCors(confg =>
             confg.AddPolicy("AllowAll",
                 p => p.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin());
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseOcelot().Wait();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
