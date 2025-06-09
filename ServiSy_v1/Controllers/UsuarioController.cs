using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiSy_v1_Business.DTOs;
using ServiSy_v1_Business.Models;
using ServiSy_v1_Business.Service;

namespace ServiSy_v1_API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(UsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult BuscarUsuario(Guid id)
        {
           var user = _usuarioService.BuscarUsuario(id);

           var userDto = _mapper.Map<UsuarioDto>(user);

            return Ok(userDto);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult CadastrarUsuario([FromBody] UsuarioCreateDto usuarioDto) 
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            _usuarioService.AdicionarUsuario(usuario);

            return Ok(usuario);
        }

        [HttpPatch]
        [Route("atualizar/{id}")]
        public IActionResult AtualizarUsuario(Guid id, [FromBody] UsuarioCreateDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);

            _usuarioService.AtualizarUsuario(id,usuario);

            return Ok();
        }

        
    }
}
