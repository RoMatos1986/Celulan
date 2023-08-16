using Celulan.Aplication.Lider;
using Celulan.Aplication.Membro;
using Celulan.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Celulan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiderController : ControllerBase
    {
        private readonly CelulaContext _context;
        public LiderController(CelulaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CadastrarLider([FromRoute] int id, [FromBody] UsuarioLiderRequest request)
        {
            var usuarioLiderService = new UsuarioLiderService(_context);
            var sucesso = usuarioLiderService.CadastrarLider(id, request);

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
        public IActionResult ObterLideres()
        {
            var liderService = new UsuarioLiderService(_context);
            var lider = liderService.ObterLideres();

            if (lider == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(lider);
            }
        }

        [HttpGet]
        [Route("{id}")]

        public IActionResult ObterLider([FromRoute] int id)
        {
            var liderService = new UsuarioLiderService(_context);
            var lider = liderService.ObterLider(id);

            if (lider == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(lider);
            }
        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult Atualizarlider([FromRoute] int id, [FromBody] UsuarioLiderRequest request)
        {
            var liderService = new UsuarioLiderService(_context);
            var sucesso = liderService.AtualizarLider(id, request);
            if (sucesso == true)
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

        public IActionResult RemoverLider([FromRoute] int id)
        {
            var liderService = new UsuarioLiderService(_context);
            var sucesso = liderService.RemoverLider(id);
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

