using MediatR;
using RoomReservas.Application.DTOs.Reservas;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Queries.Reservas.BuscarReservasPorSala
{
    public class BuscarReservasPorSalaHandler(IReservaRepository reservaRepository) : IRequestHandler<BuscarReservasPorSalaQuery, List<BuscarReservaResponse>>
    {
        public async Task<List<BuscarReservaResponse>> Handle(BuscarReservasPorSalaQuery request, CancellationToken cancellationToken)
        {
            var reservas = await reservaRepository.ObterReservasPorSalaAsync(request.salaId);
            return reservas.Select(r => new BuscarReservaResponse
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
        }
    }
}
