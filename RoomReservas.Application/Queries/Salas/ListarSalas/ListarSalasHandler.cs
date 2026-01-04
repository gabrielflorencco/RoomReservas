using MediatR;
using RoomReservas.Application.DTOs.Salas;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Queries.Salas.ListarSalas
{
    public class ListarSalasHandler(ISalaRepository salasRepository) : IRequestHandler<ListarSalasQuery, List<ListarSalasResponse>>
    {
        public async Task<List<ListarSalasResponse>> Handle(ListarSalasQuery request, CancellationToken cancellationToken)
        {
            var salas = await salasRepository.ListarTodosAsync();
            return new List<ListarSalasResponse>(salas.Select(s => new ListarSalasResponse
            {
                Id = s.Id,
                Nome = s.Nome,
                Capacidade = s.Capacidade,
                Ativa = s.Ativa
            }));
        }
    }
}
