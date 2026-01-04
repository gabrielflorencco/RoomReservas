
using Microsoft.OpenApi.Models;
using RoomReservas.Application;
using RoomReservas.Infrastructure;

namespace RoomReservas.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Controllers
            builder.Services.AddControllers();

            // Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RoomReservas API",
                    Version = "v1",
                    Description = "API para gerenciamento de salas e reservas"
                });
            });

            // Infra - Injection de Dependência e EF Core
            builder.Services.AddInfrastructureServices(
                builder.Configuration.GetConnectionString("DefaultConnection")
            );

            // Application - MediatR e FluentValidation
            builder.Services.AddApplicationServices();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RoomReservas API v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}
