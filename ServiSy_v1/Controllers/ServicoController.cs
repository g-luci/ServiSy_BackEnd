using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiSy_v1_Business.DTOs;
using ServiSy_v1_Business.Models;
using ServiSy_v1_Business.Service;

namespace ServiSy_v1_API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly ServicoService _servicoService;
        private readonly IMapper _mapper;

        public ServicoController(ServicoService servicoService, IMapper mapper)
        {
            _servicoService = servicoService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("adicionar")]
        public IActionResult AdicionarService([FromBody] ServicoCreateDto servicoDto)
        {
            var servico = _mapper.Map<Servico>(servicoDto);
            _servicoService.AdicionarServico(servico);

            return NoContent();
        }

        [HttpGet]
        [Route("buscar/{id}")]
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
        [Route("buscar_todos/{prestadorId}")]
        public IActionResult BuscarTodosServicos(Guid prestadorId)
        {
            var servicos = _servicoService.BuscarTodosServicos(prestadorId);
            if (servicos == null || !servicos.Any())
            {
                return NotFound();
            }

            var servicosDto = _mapper.Map<List<ServicoDto>>(servicos);

            return Ok(servicosDto);
        }

        [HttpPatch]
        [Route("atualizar/{id}")]
        public IActionResult AtualizarServico(Guid id, [FromBody] ServicoEditDto servicoDto)
        {

            _servicoService.AtualizarServico(id, servicoDto);

            return NoContent();
        }

        [HttpDelete]
        [Route("remover/{id}")]
        public IActionResult RemoverServico(Guid id)
        {
            var servico = _servicoService.BuscarServico(id);
            if (servico == null)
            {
                return NotFound();
            }
            _servicoService.RemoverServico(id);
            return NoContent();
        }
    }
}
