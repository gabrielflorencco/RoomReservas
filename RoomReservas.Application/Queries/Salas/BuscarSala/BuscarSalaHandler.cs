using MediatR;
using RoomReservas.Application.DTOs.Salas;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Queries.Salas.BuscarSala
{
    public class BuscarSalaHandler(ISalaRepository salaRepository) : IRequestHandler<BuscarSalaQuery, BuscarSalaResponse>
    {
        public async Task<BuscarSalaResponse> Handle(BuscarSalaQuery request, CancellationToken cancellationToken)
        {
            var sala = await salaRepository.BuscarPorIdAsync(request.Id);

            if (sala == null)
                throw new KeyNotFoundException("Sala não encontrada.");

            return new BuscarSalaResponse
            {
                Id = sala.Id,
                Nome = sala.Nome,
                Capacidade = sala.Capacidade,
                Ativa = sala.Ativa
            };
        }
    }
}
