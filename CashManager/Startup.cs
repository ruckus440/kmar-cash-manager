/*
 * Author: Mike Ruckert
 * Date: 7/26/2021
 * Submitted for consideration of the position of Programmer and Systems Developer at K-MAR-105 Association.
 * 
 * This program is an API that supports user login and the maintenance of cash records.
 * It targets the .NET 5 framework.
 * To ensure completeness, I created a SQL Server database according to the table structure I was given.
 * For this, I used Microsoft SQL Server Management Studio and SQL Server 2019.
 * The database was hosted locally on my machine. The connection string can be found in the Connection.cs file.
 * 
 * For testing, I used Postman to submit HTTP requests to the API.
 * The API listens on http://localhost:5000. The endpoints "api/users", "api/records", "api/years", and "api/login" can be hit with HTTP requests.
 * The API expects the request body to be formatted as JSON. Notes on specific formatting can be found in each controller class.
 */
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CashManager
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

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
