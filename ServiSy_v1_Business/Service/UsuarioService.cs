using AutoMapper;
using ServiSy_v1_Business.Interface;
using ServiSy_v1_Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiSy_v1_Business.Service
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public void AdicionarUsuario(Usuario usuario) 
        {
            _usuarioRepository.AdicionarUsuario(usuario);   
        }

        public Usuario BuscarUsuario(Guid id)
        {
            return _usuarioRepository.BuscarUsuario(id);
        }

        public void AtualizarUsuario(Guid id, Usuario usuarioAtualizado)
        {
            var usuarioAlvo = _usuarioRepository.BuscarUsuario(id);


            _mapper.Map(usuarioAtualizado, usuarioAlvo);


            _usuarioRepository.AtualizarUsuario(usuarioAlvo);
        }
    }
}
