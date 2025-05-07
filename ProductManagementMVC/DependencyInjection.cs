using DataAccessObjects;
using Repositories;
using Services;

namespace ProductManagementMVC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext
            services.AddSqlServer<MyStoreContext>(configuration.GetConnectionString("MyStockDB"));

            // Register DAOs
            services.AddScoped<CategoryDAO>();
            services.AddScoped<ProductDAO>();
            services.AddScoped<AccountDAO>();

            // Register Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            // Register Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
