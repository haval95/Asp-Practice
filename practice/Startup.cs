using DataStore.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using practice.Filtters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            if (_env.IsDevelopment())
            {
                //THIS IS DEPENDENCY INJECTION 
                //THIS IS PASSED TO THE OPTIONS WE HAVE IN BUGScONTEXT CLASS 
                services.AddDbContext<BugsContext>(options => {
                    options.UseInMemoryDatabase("Bugs");
                });
            };

          
            services.AddControllers(
            /*    options =>
            {
                options.Filters.Add<Version1StoppingResourceFilter>();
            }*/
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,BugsContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Creating the In memory database
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
