using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomReservas.API.DTOs.Usuario;
using RoomReservas.Application.Commands.Usuarios.AlterarUsuario;
using RoomReservas.Application.Commands.Usuarios.CriarUsuario;
using RoomReservas.Application.Queries.Usuarios.BuscarUsuario;
using RoomReservas.Application.Queries.Usuarios.ListarUsuarios;

namespace RoomReservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IMediator mediator) : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var query = new ListarUsuariosQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new BuscarUsuarioQuery(id);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CriarUsuarioRequest request)
        {
            var command = new CriarUsuarioCommand(
                request.Nome,
                request.Email
            );

            var id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(Guid id, [FromBody] AlterarUsuarioRequest request)
        {
            var command = new AlterarUsuarioCommand(
                id,
                request.Nome,
                request.Email
            );

            await mediator.Send(command);

            return NoContent();
        }
    }
}
