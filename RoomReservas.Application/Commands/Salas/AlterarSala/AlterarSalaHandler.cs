using MediatR;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Commands.Salas.AlterarSala
{
    public class AlterarSalaHandler(ISalaRepository salaRepository) : IRequestHandler<AlterarSalaCommand, Unit>
    {
        public async Task<Unit> Handle(AlterarSalaCommand request, CancellationToken cancellationToken)
        {
            var sala = await salaRepository.BuscarPorIdAsync(request.Id);
            if (sala == null)
            {
                throw new KeyNotFoundException("Sala não encontrada.");
            }

            sala.Atualizar(request.Nome, request.Capacidade);

            await salaRepository.AlterarAsync(sala);
            return Unit.Value;
        }
    }
}
