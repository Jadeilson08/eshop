using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Infra.IoC.Dependecies
{
    public static class ExtensionIoC
    {
        public static void InfraExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.InfraDbContext(configuration);
        }

        private static void InfraDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("product_api");
            services
                .AddDbContext<MySqlDbContext>
                (options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 29))));
        }
    }
}
