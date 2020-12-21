using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DomainModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Helpers
{
   public class DiModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            // services.AddDbContextPool<LamazonDbContext>(ob => ob.UseSqlServer(connectionString));
            services.AddDbContext<LamazonDbContext>(ob => ob.UseSqlServer(connectionString));//, ServiceLifetime.Transient);
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
            })
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<LamazonDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IUserRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Invoice>, InvoiceRepository>();
            services.AddTransient<IRepository<OrderProduct>, OrderProductRepository>();

                return services;
        }
    }
}
