using MediatR;
using RoomReservas.Domain.Entities;
using RoomReservas.Domain.Exceptions;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Commands.Reservas.CriarReserva
{
    public class CriarReservaHandler(IReservaRepository reservaRepository, ISalaRepository salaRepository, IUsuarioRepository usuarioRepository) : IRequestHandler<CriarReservaCommand, Guid>
    {
        public async Task<Guid> Handle(CriarReservaCommand request, CancellationToken cancellationToken)
        {
            var sala = await salaRepository.BuscarPorIdAsync(request.salaId);

            if (sala is null || !sala.Ativa)
                throw new DomainException("Sala inválida ou inativa.");

            var usuario = await usuarioRepository.BuscarPorIdAsync(request.usuarioId);

            if (usuario is null)
                throw new DomainException("Usuário inválido.");

            var atingiuLimite = await usuarioRepository.UsuarioAtingiuLimiteDeReserva(request.usuarioId);

            if (atingiuLimite)
                throw new DomainException("Usuário atingiu o limite de reservas ativas.");

            var conflito = await reservaRepository
                .ExisteConflitoDeHorarioAsync(
                    request.salaId,
                    request.inicio,
                    request.fim);

            if (conflito)
                throw new DomainException("Já existe uma reserva para essa sala no período informado.");

            var reserva = new Reserva(
                request.usuarioId,
                request.salaId,
                request.inicio,
                request.fim);

            await reservaRepository.AdicionarAsync(reserva);

            return reserva.Id;
        }
    }
}
