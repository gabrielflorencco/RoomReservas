using MediatR;
using RoomReservas.Domain.Entities;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Commands.Salas.CriarSala
{
    public class CriarSalaHandler(ISalaRepository salaRepository) : IRequestHandler<CriarSalaCommand, Guid>
    {
        public async Task<Guid> Handle(CriarSalaCommand request, CancellationToken cancellationToken)
        {
            var sala = new Sala(request.Nome, request.Capacidade, request.Ativa);
            await salaRepository.AdicionarAsync(sala);
            return sala.Id;
        }
    }
}
