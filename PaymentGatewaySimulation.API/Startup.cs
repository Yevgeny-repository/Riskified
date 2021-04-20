using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PaymentGatewaySimulation.API.Profiles;
using PaymentGatewaySimulation.BL;
using PaymentGatewaySimulation.Core;
using PaymentGatewaySimulation.Repository;
using System;
using System.Reflection;

namespace PaymentGatewaySimulation.API
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

            services.AddScoped<IHttpPostClient, HttpPostClient>();
            services.AddScoped<ChargeVisaCardRepository>();
            services.AddScoped<ChargeMasterCardRepository>();

            services.AddScoped<Func<string, IChargeRepository>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "visa":
                        return serviceProvider.GetService<ChargeVisaCardRepository>();

                    case "mastercard":
                        return serviceProvider.GetService<ChargeMasterCardRepository>();

                    default:
                        return serviceProvider.GetService<ChargeVisaCardRepository>();
                }
            });

            services.AddScoped<IChargeCardRepository, ChargeCardRepository>();
            services.AddScoped<IChargeCardService, ChargeCardService>();
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            services.AddHttpContextAccessor();

            services.AddMemoryCache();
            services.AddAutoMapper(Assembly.GetAssembly(typeof(ChargeCardProfile)));
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: allowCors, builder =>
            //    {
            //        builder.AllowAnyOrigin()
            //         .AllowAnyMethod()
            //         .AllowAnyHeader();
            //    });
            //});
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