using gamer_world.Core.Interfaces;
using gamer_world.Core.Services;
using gamer_world.Infrastructure.Data;
using gamer_world.Infrastructure.Repositories;
using gamer_world.Infrastructure.Repositories.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace gamer_world.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        // apply Unit Of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IImageManagementService, ImageManagementService>();
        services.AddSingleton<IFileProvider>(
            new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
            );
        services.AddDbContext<AppDbContext>(builder =>
        {
            builder.UseSqlServer(configuration.GetConnectionString("GamerWorldDatabase"));
        });
        return services;
    }
}