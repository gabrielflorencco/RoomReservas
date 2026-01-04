using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RoomReservas.Domain.RepositoriesInterfaces;
using RoomReservas.Infrastructure.Data;
using RoomReservas.Infrastructure.Repositories;

namespace RoomReservas.Infrastructure
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<RoomReservasDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositorios
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>)); // Repositorio generico
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ISalaRepository, SalaRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();

            return services;
        }
    }
}
