using AutoMapper;
using ServiSy_v1_Business.DTOs;
using ServiSy_v1_Business.Interface;
using ServiSy_v1_Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiSy_v1_Business.Service
{
    public class ServicoService
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IMapper _mapper;

        public ServicoService(IServicoRepository servicoRepository, IMapper mapper)
        {
            _servicoRepository = servicoRepository;
            _mapper = mapper;
        }

        public void AdicionarServico(Servico servico)
        {
            _servicoRepository.AdicionarServico(servico);
        }
        public Servico BuscarServico(Guid Id)
        {
            return _servicoRepository.BuscarServico(Id);
        }
        public List<Servico> BuscarTodosServicos(Guid prestadorId)
        {
            return _servicoRepository.BuscarTodosServicos(prestadorId);
        }
        public void AtualizarServico(Guid id, ServicoEditDto servicoAtualizado)
        {
            var servicoAlvo = _servicoRepository.BuscarServico(id);

            _mapper.Map(servicoAtualizado, servicoAlvo);

            _servicoRepository.AtualizarServico(servicoAlvo);
        }
        public void RemoverServico(Guid id)
        {
            _servicoRepository.RemoverServico(id);
        }
    }
}
