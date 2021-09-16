

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
using NotificationService.Common.StaticConstants;
using NotificationService.Infrastructure.DataAccess;
using NotificationService.Repository.Implementations;
using NotificationService.Repository.Interfaces;
using NotificationService.Repository.UnitOfWorkAndBaseRepo;
using NotificationService.Services.Implementations;
using NotificationService.Services.Interfaces;
using Shared.StaticConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotificationService
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

            services.AddDbContext<IEHDbContext>(options => options.UseSqlServer(Constants.DbConn));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NotificationService", Version = "v1" });
            });

            services.AddControllers();

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddScoped<ICallService, CallService>();
            services.AddScoped<ICallRepository, CallRepository>();
            services.AddTransient<INotificationService, NotificationServiceClass>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<HttpClient, HttpClient>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NotificationService v1"));
            }

            app.UseHttpsRedirection();

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
        }

        private void ReadConfigMessages()
        {
            //##################################### Shared ####################################################
            //############################ Error Messages ############################################

            IEHMessages.GeneralException = Configuration["Messages:GeneralException"];
            IEHMessages.RecordNotFound = Configuration["Messages:RecordNotFound"];
            IEHMessages.SavedSuccessfully = Configuration["Messages:SavedSuccessfully"];
            IEHMessages.UpdatedSuccessfully = Configuration["Messages:UpdatedSuccessfully"];
            IEHMessages.DeletedSuccessfully = Configuration["Messages:DeletedSuccessfully"];
            IEHMessages.VerificationRequired = Configuration["Messages:VerificationRequired"];
            IEHMessages.RegistrationRequired = Configuration["Messages:RegistrationRequired"];
            IEHMessages.RecordAlreadyExists = Configuration["Messages:RecordAlreadyExists"];
            IEHMessages.DateGreaterThanNowError = Configuration["Messages:DateGreaterThanNowError"];
            IEHMessages.OperationSuccessful = Configuration["Messages:OperationSuccessful"];
            IEHMessages.AccountNotExist = Configuration["Messages:AccountNotExist"];
            IEHMessages.InvalidUser = Configuration["Messages:InvalidUser"];
            IEHMessages.AccountAlreadyExist = Configuration["Messages:AccountAlreadyExist"];
            IEHMessages.InvalidToken = Configuration["Messages:InvalidToken"];
            IEHMessages.EmailAlreadyVerified = Configuration["Messages:EmailAlreadyVerified"];
            IEHMessages.AccountBlocked = Configuration["Messages:AccountBlocked"] + IEHMessages.SupportEmail;
            IEHMessages.EmailAccountExist = Configuration["Messages:EmailAccountExist"];
            IEHMessages.AccessDenied = Configuration["Messages:AccessDenied"];
            IEHMessages.InvalidPassword = Configuration["Messages:InvalidPassword"];
            IEHMessages.ImageUploaded = Configuration["Messages:ImageUploaded"];
            IEHMessages.UnauthorizedUser = Configuration["Messages:UnauthorizedUser"];
            IEHMessages.UserNotFound = Configuration["Messages:UserNotFound"];
            IEHMessages.EmailorPasswordWrong = Configuration["Messages:EmailorPasswordWrong"];
            IEHMessages.RestrictAdminLogin = Configuration["Messages:RestrictAdminLogin"];
            IEHMessages.RestrictReviewerLogin = Configuration["Messages:RestrictReviewerLogin"];
            IEHMessages.LoginSuspendedMessage = Configuration["Messages:LoginSuspendedMessage"];
        }
    }
}
