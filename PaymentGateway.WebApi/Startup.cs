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
using PaymentGateway.Domain.Entities;
using PaymentGateway.Infrastructure.Data;
using PaymentGateway.Application.Interfaces;
using PaymentGateway.Application;
using PaymentGateway.Domain.Interfaces.Services;
using PaymentGateway.Domain.Interfaces.Repositories;
using PaymentGateway.Infrastructure.Data.Repositories;
using PaymentGateway.Domain.Services;
using Infrastructure.CrossCuting.HttpClient;

namespace PaymentGateway.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<PaymentGatewayContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("PaymentGatewayContext")));

            services.AddTransient<ISaleServiceApp, SaleServiceApp>();

            services.AddTransient<IAcquirerService, AcquirerService>();
            services.AddTransient<ICreditCardService, CreditCardService>();
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IStoreAcquirerService, StoreAcquirerService>();
            services.AddTransient<IAcquirerSaleService, AcquirerSaleService>();
            services.AddTransient<IAcquirerSaleService, AcquirerSaleService>();

            services.AddTransient<IRepositoryAcquirer, RepositoryAcquirer>();
            services.AddTransient<IRepositoryCreditCard, RepositoryCreditCard>();
            services.AddTransient<IRepositoryStore, RepositoryStore>();
            services.AddTransient<IRepositoryStoreAcquirer, RepositoryStoreAcquirer>();
            services.AddTransient<IRepositoryAcquirerSale, RepositoryAcquirerSale>();

            services.AddTransient<IHttpUtility, HttpUtility>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, PaymentGatewayContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            DbInitializer.Initialize(context);

        }
    }
}
