using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Storage.Application.Abstractions;
using Storage.Infrastructure.Repositories;

namespace Storage.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection")!;
            services.AddDbContext<ApplicationDbContext>((sp, opt) =>
            {
                opt.UseSqlServer(connection);
            });
            services.AddScoped<IFileModelRepository, FileModelRepository>();


            return services;
        }

    }
}
