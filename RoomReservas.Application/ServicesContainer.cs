using Microsoft.Extensions.DependencyInjection;

namespace RoomReservas.Application
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ServicesContainer).Assembly));

            // FluentValidation registration can be added here if needed in the future
            // services.AddValidatorsFromAssembly(typeof(ServicesContainer).Assembly);

            return services;
        }
    }
}
