﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Compeer.Core.Data;
using Compeer.Core.Interfaces;
using Compeer.Core.Entities;
using Compeer.Core.Services;
using RiotSharp.Interfaces;
using RiotSharp;
<<<<<<< HEAD
using Compeer.API.Model;
using Compeer.API.Interfaces;
=======
>>>>>>> d9f66de2b85c929f4372bd2d37077447efacf2f8
using Compeer.API.Services;

namespace Compeer.API
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
            services.AddDbContext<CompeerContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

<<<<<<< HEAD
            ConfigureToken(services, new TokenSetting(this.Configuration));

=======
>>>>>>> d9f66de2b85c929f4372bd2d37077447efacf2f8
            //Dependency configs
            ConfigureDependencies(services);
        }

        public void ConfigureToken(IServiceCollection services, TokenSetting tokenSetting)
        {
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option => {
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters{
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = tokenSetting.Issuer,
                    ValidAudience = tokenSetting.Audience,
                    IssuerSigningKey = tokenSetting.SigningCredentials.Key
                };

                option.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context => 
                    {
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context => 
                    {
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorization(option => 
            {
                option.AddPolicy("CompeerUser", 
                policy => policy.RequireClaim("User"));
            });            
        }

        public void ConfigureDependencies(IServiceCollection services)
        {
            services.AddTransient<ITokenService,TokenService>();

            services.AddTransient<IService<Queue>, QueueService>();

            services.AddTransient<IService<User>, UserService>();

            services.AddTransient<ITokenService, TokenService>();
            
            services.AddTransient<TokenSetting>();
            
            services.AddTransient<UtilService>();

            services.AddTransient<IRiotApi, RiotApi>(s => RiotApi.GetDevelopmentInstance(Configuration["RiotKey"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CompeerContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseMvc();

            dbContext.Database.EnsureCreated();
        }
    }
}
