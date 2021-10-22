using AuthService.Common.StaticConstants;
using AuthService.Infrastructure.DataAccess;
using AuthService.Repository.Implementations;
using AuthService.Repository.Interfaces;
using AuthService.Repository.UnitOfWorkAndBaseRepo;
using AuthService.Services.Implementations;
using AuthService.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Shared.StaticConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthService
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
            ReadConfigSettings();

            services.AddControllers();

            services.AddTransient<IAuthService, AuthServices>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<HttpClient, HttpClient>();


            services.AddSingleton(Configuration);

            services.AddDbContext<IEHDbContext>(options => options.UseSqlServer(Constants.DbConn));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthService", Version = "v1" });
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthService v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(builder => builder
                             .AllowAnyHeader()
                             .AllowAnyMethod()
                             .AllowAnyOrigin());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ReadConfigSettings()
        {
            Constants.DbConn = Configuration["App:DbConn"];
            Constants.AzureDbConn = Configuration["UploadDocument:DbConn"];
            Constants.FolderName = Configuration["UploadDocument:FolderName"];
            Constants.ImagePath = Configuration["UploadDocument:ImagePath"];


            SharedConstants.IdentityURL = Configuration["Identity:IdentityURL"];
            SharedConstants.ClientId = Configuration["Identity:ClientId"];
            SharedConstants.ClientSecret = Configuration["Identity:ClientSecret"];
            SharedConstants.Scope = Configuration["Identity:Scope"];

            SharedConstants.Authority = Configuration["Authentication:Authority"];
            SharedConstants.APIName = Configuration["Authentication:APIName"];

            Constants.AccountSid = Configuration["Twilio:AccountSid"];
            Constants.AuthToken = Configuration["Twilio:AuthToken"];
            Constants.VerificationSid = Configuration["Twilio:VerificationSid"];


            //Constants.TokenIssuer = Configuration["App:TokenIssuer"];
            //Constants.TokenAudience = Configuration["App:TokenAudience"];
            //Constants.TokenExpiryDays = Convert.ToInt32(Configuration["App:TokenExpiryDays"]);
            //Constants.TokenSecretKey = Configuration["App:TokenSecretKey"];
        }
    }
}
