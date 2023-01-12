using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TREKS.SeKompletno.DataAccess.Context;
using TREKS.SeKompletno.DataAccess.Repositories.Classes;
using TREKS.SeKompletno.DataAccess.Repositories.Interfaces;
using TREKS.SeKompletno.DomainModels.Models;
using TREKS.SeKompletno.Services.Classes;
using TREKS.SeKompletno.Services.Interfaces;

namespace TREKS.SeKompletno.IoC
{
    public static class IoCContainer
    {
        public static IServiceCollection ConfigureIoCContainer(IServiceCollection services,
                                            string connectionString)
        {
            services.AddDbContext<SeKompletnoAppDbContext>(x =>
            {
                x.UseSqlServer(connectionString);   
            });

            services.AddTransient<IRepository<Admin>, AdminRepository>();
            services.AddTransient<IRepository<Customer>, CustomerRepository>();
            services.AddTransient<IRepository<Manufacturer>, ManufacturerRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Product>, ProductRepository>();


            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();


            return services;
        }
    }
}
