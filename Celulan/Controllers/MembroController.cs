using Celulan.Aplication.Membro;
using Celulan.Repository;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Celulan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembroController : ControllerBase
    {
        private readonly CelulaContext _context;
        public MembroController(CelulaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CadastrarMembro([FromRoute] int id, [FromBody] UsuarioMembroRequest request)
        {
            var usuarioMembroService = new UsuarioMembroService(_context);
            var sucesso = usuarioMembroService.CadastrarMembro(id, request);

            if (sucesso == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult ObterMembros()
        {
            var membroService = new UsuarioMembroService(_context);
            var membros = membroService.ObterMembros();

            if (membros == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(membros);
            }
        }

        [HttpGet]
        [Route("{id}")]

        public IActionResult ObterMembro([FromRoute] int id)
        {
            var membroService = new UsuarioMembroService(_context);
            var membro = membroService.ObterMembro(id);

            if (membro == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(membro);
            }
        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult AtualizarMembro([FromRoute] int id, [FromBody] UsuarioMembroRequest request)
        {
            var membroService = new UsuarioMembroService(_context);
            var sucesso = membroService.AtualizarMembro(id, request);
            if(sucesso == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]

        public IActionResult RemoverMembro([FromRoute] int id)
        {
            var MembroService = new UsuarioMembroService(_context);
            var sucesso = MembroService.RemoverMembro(id);
            if (sucesso == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
