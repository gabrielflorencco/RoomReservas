using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomReservas.API.Requests.Sala;
using RoomReservas.Application.Commands.Salas.AlterarAtividadeSala;
using RoomReservas.Application.Commands.Salas.AlterarSala;
using RoomReservas.Application.Commands.Salas.CriarSala;
using RoomReservas.Application.Queries.Salas.BuscarSala;
using RoomReservas.Application.Queries.Salas.ListarSalas;

namespace RoomReservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController(IMediator mediator) : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var query = new ListarSalasQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new BuscarSalaQuery(id);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CriarSalaRequest request)
        {
            var command = new CriarSalaCommand(
                request.Nome,
                request.Capacidade,
                request.Ativa
            );

            var id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(Guid id, [FromBody] AlterarSalaRequest request)
        {
            var command = new AlterarSalaCommand(
                id,
                request.Nome,
                request.Capacidade,
                request.Ativa
            );

            await mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{id:guid}/ativo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PatchActivity(Guid id)
        {
            var command = new AlterarAtividadeSalaCommand(id);

            await mediator.Send(command);

            return NoContent();
        }
    }
}
