using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PublisherAPI.Model;
using Swashbuckle.AspNetCore.Swagger;
using PublisherAPI.Repository;

namespace PublisherAPI
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
            services.Configure<Settings>(options => options.ConnectionString= Configuration.GetSection("MongoDbConection:ConnectionString").Value);
            services.Configure<Settings>(options => options.Database = Configuration.GetSection("MongoDbConection:Database").Value);
            services.AddSingleton<IPublisherDBContext, PublisherDBContext>();
            services.AddSingleton<IAuthorRepository, AuthorRepository>();
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<IAddressRepositry, AddressRepositry>();
            
            services.AddMvc();
            services.AddSwaggerGen(swg => swg.SwaggerDoc("V1", new Info { Title = "My API Test", Version = "V1" }));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(swg => 
                {
                    swg.SwaggerEndpoint("/swagger/V1/swagger.json", "My API Test");
                    //swg.RoutePrefix = string.Empty;
                });
            
            app.UseMvc();
        }
    }
}
