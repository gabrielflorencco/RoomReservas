using MediatR;
using RoomReservas.Application.DTOs.Reservas;

namespace RoomReservas.Application.Queries.Reservas.BuscarReservasPorPeriodo
{
    public record BuscarReservasPorSalaEPeriodoQuery(Guid idSala, DateTime dataInicio, DateTime dataFim) : IRequest<List<BuscarReservaResponse>>;
}
