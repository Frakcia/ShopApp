using Microsoft.EntityFrameworkCore;
using ShopApp.Business.EntityServices;
using ShopApp.Contracts.EntityServices;
using ShopApp.Infrastructure;

namespace ShopApp.Web.StartupConfigurations
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddDependecyInjectionContainers(this IServiceCollection services, ConfigurationManager configuration)
    {
      //services.AddDbContext<DbAppContext>(options =>
      //    options.UseNpgsql(configuration.GetConnectionString("postgresConnection")), ServiceLifetime.Scoped);

      services.AddScoped<IDeliveryAdressService, DeliveryAdressService>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IOrderService, OrderService>();
      services.AddScoped<IOrderCreatingService, OrderCreatingService>();
      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<IProductCommentService, ProductCommentService>();

      return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
      services
        .AddEndpointsApiExplorer()
        .AddSwaggerGen();

      return services;
    }
  }
}
