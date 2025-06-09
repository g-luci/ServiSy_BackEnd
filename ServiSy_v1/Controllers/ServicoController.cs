using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiSy_v1_Business.DTOs;
using ServiSy_v1_Business.Models;
using ServiSy_v1_Business.Service;
using System.Security.Claims;

namespace ServiSy_v1_API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    [Authorize]
    public class ServicoController : ControllerBase
    {
        private readonly ServicoService _servicoService;
        private readonly UsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public ServicoController(ServicoService servicoService, IMapper mapper, UsuarioService usuarioService)
        {
            _servicoService = servicoService;
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult AdicionarService([FromBody] ServicoCreateDto servicoDto)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null) return Unauthorized();

                var usuario = _usuarioService.BuscarUsuario(Guid.Parse(userIdClaim));
                if (usuario == null || !usuario.Prestador)
                {
                    return Forbid(); 
                }

                var servico = _mapper.Map<Servico>(servicoDto);
                _servicoService.AdicionarServico(servico, usuario.Id);

                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult BuscarServico(Guid id)
        {
            var servico = _servicoService.BuscarServico(id);
            if (servico == null)
            {
                return NotFound();
            }

            var servicoDto = _mapper.Map<ServicoDto>(servico);

            return Ok(servicoDto);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetServicos([FromQuery] Guid? prestadorId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var servicos = _servicoService.BuscarTodosPaginado(prestadorId, page, pageSize);
            var totalServicos = _servicoService.ContarTotalServicos(prestadorId);

            var servicosDto = _mapper.Map<List<ServicoDto>>(servicos);

            Response.Headers.Add("X-Total-Count", totalServicos.ToString());
            Response.Headers.Add("X-Page-Size", pageSize.ToString());
            Response.Headers.Add("X-Current-Page", page.ToString());

            return Ok(servicosDto);
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult AtualizarServico(Guid id, [FromBody] ServicoEditDto servicoDto)
        {
            var servicoAlvo = _servicoService.BuscarServico(id);
            if (servicoAlvo == null) return NotFound();

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || servicoAlvo.Prestado_Id != Guid.Parse(userIdClaim))
            {
                return Forbid();
            }

            _servicoService.AtualizarServico(id, servicoDto);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult RemoverServico(Guid id)
        {
            var servicoAlvo = _servicoService.BuscarServico(id);
            if (servicoAlvo == null)
            {
                return NotFound();
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || servicoAlvo.Prestado_Id != Guid.Parse(userIdClaim))
            {
                return Forbid(); 
            }

            _servicoService.RemoverServico(id);
            return NoContent();
        }
    }
}
