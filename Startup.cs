using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
namespace TodoApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Registered the swagger generator, defining 1 or more swagger documents
            services.AddSwaggerGen(c=>
            {c.SwaggerDoc("v1",new OpenApiInfo{Title = "Todo Api",Version ="v1",Description = "A simple example ASP.NET Core Web API",
            Contact = new OpenApiContact
            {
                Name = "Subhojit Tarafdar",
                Email = "subhojit.tarafdar@tcs.com",
            
            },});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Enable middleware to serve swagger -UI (HTML,JS,CSS, etc.)
            //specifying the  swagger JSON endpoint
            app.UseSwagger();
            app.UseSwaggerUI(c=>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix=string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
