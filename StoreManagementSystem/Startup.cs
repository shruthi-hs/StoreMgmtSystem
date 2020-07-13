using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StoreManagementSystem.BLL;
using StoreManagementSystem.BLL.Interface;
using StoreManagementSystem.DAL;
using StoreManagementSystem.DAL.Interface;
using StoreManagementSystem.Model.DBContext;

namespace StoreManagementSystem
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

            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<InventoryDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("InventoryDBConnection"));
            });


            services.AddTransient<IProductDAL, ProductDAL>();
            services.AddTransient<IProductBLL, ProductBLL>();
            services.AddTransient<IStaffDAL, StaffDAL>();
            services.AddTransient<IStaffBLL, StaffBLL>();
            services.AddTransient<IStockDAL, StockDAL>();
            services.AddTransient<IStockBLL, StockBLL>();
            services.AddTransient<IUserDAL, UserDAL>();
            services.AddTransient<IUserBLL, UserBLL>();
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
