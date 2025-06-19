using gamer_world.Core.Interfaces;
using gamer_world.Infrastructure.Data;
using gamer_world.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace gamer_world.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        // apply Unit Of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<AppDbContext>(builder =>
        {
            builder.UseSqlServer(configuration.GetConnectionString("GamerWorldDatabase"));
        });
        return services;
    }
}