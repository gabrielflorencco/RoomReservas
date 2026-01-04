using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomReservas.API.Requests.Reserva;
using RoomReservas.Application.Commands.Reservas.AlterarStatusReserva;
using RoomReservas.Application.Commands.Reservas.CriarReserva;
using RoomReservas.Application.Commands.Reservas.DeletarReserva;
using RoomReservas.Application.Queries.Reservas.BuscarReserva;
using RoomReservas.Application.Queries.Reservas.BuscarReservaPorUsuario;
using RoomReservas.Application.Queries.Reservas.BuscarReservasPorPeriodo;
using RoomReservas.Application.Queries.Reservas.BuscarReservasPorSala;
using RoomReservas.Application.Queries.Reservas.ListarReservas;

namespace RoomReservas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ============================
        // GETs (Queries)
        // ============================

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new ListarReservasQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new BuscarReservaQuery(id));
            return Ok(result);
        }

        [HttpGet("por-sala/{salaId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBySala(Guid salaId)
        {
            var result = await _mediator.Send(new BuscarReservasPorSalaQuery(salaId));
            return Ok(result);
        }

        [HttpGet("por-sala/{salaId:guid}/periodo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBySalaEPeriodo(
            Guid salaId,
            [FromQuery] DateTime inicio,
            [FromQuery] DateTime fim)
        {
            var query = new BuscarReservasPorSalaEPeriodoQuery(salaId, inicio, fim);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("por-usuario/{usuarioId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByUsuario(Guid usuarioId)
        {
            var result = await _mediator.Send(new BuscarReservasPorUsuarioQuery(usuarioId));
            return Ok(result);
        }

        // ============================
        // POST (Command)
        // ============================

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CriarReservaRequest request)
        {
            var command = new CriarReservaCommand(
                request.UsuarioId,
                request.SalaId,
                request.DataHoraInicio,
                request.DataHoraFim
            );

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        // ============================
        // PATCH (Command)
        // ============================

        [HttpPatch("{id:guid}/status")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AlterarStatus(
            Guid id,
            [FromBody] AlterarStatusReservaRequest request)
        {
            var command = new AlterarStatusReservaCommand(id, request.Status);

            await _mediator.Send(command);

            return NoContent();
        }

        // ============================
        // DELETE (Command)
        // ============================

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeletarReservaCommand(id));
            return NoContent();
        }
    }
}
