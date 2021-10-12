using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shared.StaticConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserService.Common.StaticConstants;
using UserService.Infrastructure.DataAccess;
using UserService.Repository.Implementations;
using UserService.Repository.Interfaces;
using UserService.Repository.UnitOfWorkAndBaseRepo;
using UserService.Services.Implementations;
using UserService.Services.Interfaces;

namespace UserService
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

            services.AddSingleton(Configuration);
            services.AddDbContext<IEHDbContext>(options => options.UseSqlServer(Constants.DbConn));

            services.AddControllers();

            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<HttpClient, HttpClient>();

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

            app.UseRouting();
            app.UseCors("AllowAll");
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

            SharedConstants.Authority = Configuration["Authentication:Authority"];
            SharedConstants.APIName = Configuration["Authentication:APIName"];
            SharedConstants.TwilioAccountSid = Configuration["Twilio:AccountSid"];
            SharedConstants.TwilioAuthToken = Configuration["Twilio:AuthToken"];
            SharedConstants.FromNumber = Configuration["Twilio:FromNumber"];


        }
    }   
}

