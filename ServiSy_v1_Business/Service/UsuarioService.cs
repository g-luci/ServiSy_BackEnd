﻿using AutoMapper;
using ServiSy_v1_Business.Interface;
using ServiSy_v1_Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace ServiSy_v1_Business.Service
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IJwtTokenService jwtTokenService)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
        }

        public string Autenticar(string email, string password)
        {
            var usuario = _usuarioRepository.BuscarPorEmail(email);
            if (usuario == null || !BC.Verify(password, usuario.Password))
            {
                throw new UnauthorizedAccessException("Email ou senha inválidos.");
            }
            return _jwtTokenService.GerarToken(usuario);
        }

        public void AdicionarUsuario(Usuario usuario) 
        {
            usuario.Password = BC.HashPassword(usuario.Password);

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

            if (!string.IsNullOrEmpty(usuarioAtualizado.Password))
            {
                usuarioAlvo.Password = BC.HashPassword(usuarioAtualizado.Password);
            }

            _usuarioRepository.AtualizarUsuario(usuarioAlvo);
        }
    }
}
