using MediatR;
using RoomReservas.Application.DTOs.Reservas;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Queries.Reservas.ListarReservas
{
    internal class ListarReservasHandler(IReservaRepository reservaRepository) : IRequestHandler<ListarReservasQuery, List<ListarReservasResponse>>
    {
        public async Task<List<ListarReservasResponse>> Handle(ListarReservasQuery request, CancellationToken cancellationToken)
        {
            var reservas = await reservaRepository.ListarTodosAsync();
            var response = reservas.Select(r => new ListarReservasResponse
            {
                Id = r.Id,
                UsuarioId = r.UsuarioId,
                SalaId = r.SalaId,
                Inicio = r.Inicio,
                Fim = r.Fim,
                ValorTotal = r.ValorTotal,
                Status = r.Status,
                DataCriacao = r.DataCriacao
            }).ToList();

            return response;
        }
    }
}
