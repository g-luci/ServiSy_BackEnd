using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiSy_v1_Business.DTOs;
using ServiSy_v1_Business.Models;
using ServiSy_v1_Business.Service;
using System.Security.Claims;

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

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UsuarioLoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest("Requisição inválida.");
            }

            var token = _usuarioService.Autenticar(loginDto.Email, loginDto.Password);

            if (token == null)
            {
                return Unauthorized("Email ou senha inválidos.");
            }

            return Ok(new { Token = token });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult BuscarUsuario(Guid id)
        {
           var user = _usuarioService.BuscarUsuario(id);

           var userDto = _mapper.Map<UsuarioDto>(user);

            return Ok(userDto);
        }

        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] UsuarioCreateDto usuarioDto) 
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            _usuarioService.AdicionarUsuario(usuario);

            return Ok(usuario);
        }

        [HttpPatch]
        [Route("{id}")]
        [Authorize]
        public IActionResult AtualizarUsuario(Guid id, [FromBody] UsuarioCreateDto usuarioDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null || userIdClaim != id.ToString())
            {
                return Forbid();
            }

            var usuario = _mapper.Map<Usuario>(usuarioDto);

            _usuarioService.AtualizarUsuario(id,usuario);

            return Ok();
        }

        
    }
}
