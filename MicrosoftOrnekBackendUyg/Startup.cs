using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MicrosoftOrnekBackendUyg.Data;
using MicrosoftOrnekBackendUyg.Data.UnitOfWorks;
using MicrosoftOrnekBackendUyg.Core.UnitOfWorks;
using MicrosoftOrnekBackendUyg.Core.Repositories;
using MicrosoftOrnekBackendUyg.Core.Services;
using MicrosoftOrnekBackendUyg.Service.Services;
using MicrosoftOrnekBackendUyg.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MicrosoftOrnekBackendUyg.Core;
using MicrosoftOrnekBackendUyg.Core.Models;
using Microsoft.AspNetCore.Identity;
using MicrosoftOrnekBackendUyg.Common;
using Serilog.Context;
using MicrosoftOrnekBackendUyg.RabbitMQ;
using RabbitMQ.Client;
using System.IO;

namespace MicrosoftOrnekBackendUyg
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
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceActivityService, InvoiceActivityService>();
            services.AddScoped<IUserService, UserService> ();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICreditCardsService, CreditCardsService>();
            //services.AddScoped<ILogService, LogService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton(serviceprovider => new ConnectionFactory() { Uri = new Uri(Configuration.GetConnectionString("RabbitMQLokal")), DispatchConsumersAsync = true });

            services.AddSingleton<RabbitMQClientService>();
            services.AddSingleton<RabbitMQPublisher>();
            services.AddSingleton<IPaymentService, PaymentService>();

            //services.AddSingleton<RabbitMQClientService>();
            //services.AddSingleton<RabbitMQPublisher>();

            //services.AddScoped<IPaymentService, PaymentService>();
            //services.AddTransient<IPaymentService, PaymentService>();
            //services.AddSingleton<IPaymentService, PaymentService>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(),o=> {
                    o.MigrationsAssembly("MicrosoftOrnekBackendUyg.Data");
                });
            });


            services.AddIdentity<UserApp, IdentityRole>(Opt =>
            {
                Opt.User.RequireUniqueEmail = true;
                Opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.Configure<CustomTokenOption>(Configuration.GetSection("TokenOption"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
            {
                var tokenOptions = Configuration.GetSection("TokenOption").Get<CustomTokenOption>();
                opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience[0],
                    IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),

                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddHostedService<OnlinePaymentProcessBackgroundService>();
            services.AddControllers();
           
            services.AddCors();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.Use(async (httpContext, next) =>
            {
                var UserName = httpContext.User.Identity.IsAuthenticated ? httpContext.User.Identity.Name : "Guest"; //Gets user Name from user Identity  
                LogContext.PushProperty("UserName", UserName); //Push user in LogContext;  
                await next.Invoke();
            }
            );
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
