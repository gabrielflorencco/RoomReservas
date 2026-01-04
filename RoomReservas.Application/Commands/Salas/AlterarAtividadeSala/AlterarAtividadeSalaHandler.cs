using MediatR;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Commands.Salas.AlterarAtividadeSala
{
    public class AlterarAtividadeSalaHandler(ISalaRepository salaRepository) : IRequestHandler<AlterarAtividadeSalaCommand, Unit>
    {
        public async Task<Unit> Handle(AlterarAtividadeSalaCommand request, CancellationToken cancellationToken)
        {
            var sala = await salaRepository.BuscarPorIdAsync(request.Id);
            if (sala == null)
                throw new KeyNotFoundException("Sala não encontrada");
            if (sala.Ativa)
            {
                await salaRepository.DesativarAsync(request.Id);
            }
            else
            {
                await salaRepository.AtivarAsync(request.Id);
            }

            return Unit.Value;
        }
    }
}
