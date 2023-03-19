﻿using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using MH.Api.Authentication;
using MH.Api.Dependency;
using MH.Api.Middleware;
using MH.Application.Dependency;
using MH.Domain.Constant;
using MH.Domain.DBModel;
using MH.Domain.Mapping;
using MH.Infrastructure.Dependency;
using MH.Infrastructure.DBContext;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Hangfire;
using MH.Domain.Settings;
using Hangfire.Dashboard;
using MH.Api.Filter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Authentication.Facebook;
using System.Configuration;
using MH.Api.Dependency.Setting;

namespace MH.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })
                .AddFluentValidation(opt =>
                {
                    // Validate child properties and root collection elements
                    opt.ImplicitlyValidateChildProperties = false;
                    opt.ImplicitlyValidateRootCollectionElements = false;

                    // Automatic registration of validators in assembly
                    opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

            // For Entity Framework  
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString(ConfigOptions.DbConnName),
                            options => options.EnableRetryOnFailure())
                );
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString(ConfigOptions.DbConnName)));
            services.AddHangfireServer();

            services.AddServices();
            services.AddRepositories();
            services.ApplicationServices();
            services.TokenAuthentication(Configuration);

            //Appsettings Bind to Singleton Class
            services.AddFacebookAuthSettingService(Configuration);
            services.AddGoogleAuthSettingService(Configuration);
            services.AddMailSettingService(Configuration);

            

            services.AddAutoMapper(typeof(ApplicationUserMapping).Assembly);
            //services.Configure<CookiePolicyOptions>(options =>
            //{

            //    // prevent access from javascript 
            //    options.HttpOnly = HttpOnlyPolicy.Always;

            //    // If the URI that provides the cookie is HTTPS, 
            //    // cookie will be sent ONLY for HTTPS requests 
            //    // (refer mozilla docs for details) 
            //    options.Secure = CookieSecurePolicy.SameAsRequest;

            //    // refer "SameSite cookies" on mozilla website 
            //    options.MinimumSameSitePolicy = SameSiteMode.None;

            //});
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    {
                        builder.WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.AddEndpointsApiExplorer();
            services.AddHttpClient();
            services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.",
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsProduction())
            {
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
            }
            app.UseSwagger();
            app.UseSwaggerUI();

            var hangFireDashboardOptions = new DashboardOptions
            {
                DashboardTitle = "Scheduler",
                AppPath = null,
                //Authorization = new IDashboardAuthorizationFilter[]
                //{
                //    new HangfireAuthorizationFilter("Admin")
                //}
            };
            app.UseHangfireDashboard("/job/hangfire", hangFireDashboardOptions);
            app.UseRouting();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}