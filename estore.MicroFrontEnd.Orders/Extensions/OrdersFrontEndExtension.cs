using estore.MicroFrontEnd.Orders.Options;
using estore.MicroFrontEnd.Orders.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class OrdersFrontEndExtension
    {
        public static IServiceCollection AddOrdersFrontEnd(this IServiceCollection services, Action<ApiOptions> setupAction)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.Configure(setupAction);
            return services;
        }
    }
}
