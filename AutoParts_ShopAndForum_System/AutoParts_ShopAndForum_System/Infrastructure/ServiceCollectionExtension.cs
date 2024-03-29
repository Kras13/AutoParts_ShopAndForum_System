﻿using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Services;
using AutoParts_ShopAndForum.Infrastructure.Data;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutoParts_ShopAndForum_System.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationDbContext(
            this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection ConfigureContextIdentity(this IServiceCollection services)
        {
            services
                .AddDefaultIdentity<User>(
                options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.SignIn.RequireConfirmedEmail = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

        public static IServiceCollection ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISubcategoryService, SubcategoryService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ITownService, TownService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IForumCategoryService, ForumCategoryService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
