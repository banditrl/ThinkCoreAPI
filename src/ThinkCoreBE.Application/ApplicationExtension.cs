using Microsoft.Extensions.DependencyInjection;
using ThinkCoreBE.Application.Interfaces;
using ThinkCoreBE.Application.Services;

namespace ThinkCoreBE.Application
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
