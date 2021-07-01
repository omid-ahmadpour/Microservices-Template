namespace Slice.Services.Identity.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Slice.Framework.Common.General;
    using Slice.Services.Identity.Infrastructure.Db;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var appOptions = configuration.GetSection(nameof(AppOptions)).Get<AppOptions>();

            services.AddScoped((serviceProvider) =>
            {
                var option = CreateContextOptions(appOptions.DatabaseConnectionString);
                return new AppDbContext(option);
            });

            DbContextOptions<AppDbContext> CreateContextOptions(string connectionString)
            {
                var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
                                     .UseSqlServer(connectionString)
                                     .Options;

                return contextOptions;
            }

            return services;
        }
    }
}
