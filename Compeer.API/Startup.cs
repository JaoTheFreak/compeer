using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
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


            //Dependency configs
            ConfigureDependencies(services);
        }

        public void ConfigureToken(IServiceCollection services)
        {
            
        }

        public void ConfigureDependencies(IServiceCollection services)
        {
            services.AddTransient<IService<Queue>, QueueService>();

            services.AddTransient<IService<User>, UserService>();

            services.AddTransient<UtilService>();

            services.AddTransient<IRiotApi, RiotApi>(s => RiotApi.GetDevelopmentInstance("RGAPI-73e9d8c7-8d74-448a-9545-6f1b7efedf8a"));
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
            app.UseMvc();

            dbContext.Database.EnsureCreated();
        }
    }
}
