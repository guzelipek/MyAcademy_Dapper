using DapperApp.Web.Context;
using DapperApp.Web.Services.Categories;
using DapperApp.Web.Services.Products;

namespace DapperApp.Web.Extensions
{
    public static class ServiceRegistrations
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
