using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExCore.Sample.EF;
using ExpCore.Core.Data;
using ExpCore.ListRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ExpCore
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
            //registration area
            services.AddTransient<IReadOnlyRepository<Employee>, ListReadOnlyRepository<Employee>>();
            services.AddTransient<IReadWriteRepository<Employee>, ListReadWriteRepository<Employee>>();

            //configure cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            //configure mvc
            services.AddMvc().AddJsonOptions(y => y.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;

            //configure ef
            var connection = @"Server=(local);Database=ExCore.Sample.SqlDB;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<CustomerOrderContext>
                (options => options.UseSqlServer(connection, b=> b.MigrationsAssembly("ExCore.Sample.EF")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("CorsPolicy");
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
