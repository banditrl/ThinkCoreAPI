using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using ThinkCoreBE.Domain.Interfaces;
using ThinkCoreBE.Infrastructure.Persistance;

namespace ThinkCoreBE.Infrastructure
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbConnection>(sp =>
                new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IThinkCoreDbContext, ThinkCoreDbContext>();

            return services;
        }
    }
}
