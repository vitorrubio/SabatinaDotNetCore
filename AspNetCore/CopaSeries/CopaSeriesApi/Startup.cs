using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaSeriesApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }

        /// <summary>
        /// para detectar se está rodando no IIS
        /// https://stackoverflow.com/questions/42272021/check-if-asp-netcore-application-is-hosted-in-iis
        /// </summary>
        /// <returns></returns>
        private static bool IsRunningInsideIIS(IWebHostEnvironment env) =>
            System.Environment.GetEnvironmentVariable("APP_POOL_ID") is string apppoolid &&
            apppoolid.Contains(env.ApplicationName) &&
            apppoolid.Contains("AppPool");

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
 
                
            services.AddControllers()
                //pra deixar o json com propriedades em PascalCase / primeira maiúscula
                ;//.AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null); 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CopaSeriesApi", Version = "v1" });
            });


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                            //.WithOrigins("https://localhost:44394", "https://localhost:6001")
                            .WithOrigins("*") //vamos permitir todas as origens por enquanto pra poder trabalhar 
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                if (IsRunningInsideIIS(env))
                {
                    ConfigureSwaggerInIIS(app);
                }
                else
                {
                    ConfigureSwaggerNotIIS(app);
                }  
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void ConfigureSwaggerInIIS(IApplicationBuilder app)
        {
#if DEBUG
            //para uso do swagger no iis, melhor a url raiz/prefixo vir da config
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "CopaSeriesApi v1"); // will be relative to route prefix, which is itself relative to the application basepath
            });
#endif
        }

        private static void ConfigureSwaggerNotIIS(IApplicationBuilder app)
        {
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CopaSeriesApi v1"));
        }
    }

}
