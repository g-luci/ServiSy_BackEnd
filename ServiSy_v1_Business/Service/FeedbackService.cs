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
    public class FeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public void AdicionarFeedback(Feedback feedback)
        {
            _feedbackRepository.AdicionarFeedback(feedback);
        }
        public Feedback BuscarFeedback(Guid Id)
        {
            return _feedbackRepository.BuscarFeedback(Id);
        }
        public List<Feedback> BuscarTodosFeedback(Guid servicoId)
        {
            return _feedbackRepository.BuscarTodosFeedback(servicoId);
        }
        public void AtualizarFeedback(Guid id, FeedbackEditDto feedbackAtualizado)
        {
            var feedbackAlvo = _feedbackRepository.BuscarFeedback(id);

            _mapper.Map(feedbackAtualizado, feedbackAlvo);

            _feedbackRepository.AtualizarFeedback(feedbackAlvo);
        }
        public void RemoverFeedback(Guid id)
        {
            _feedbackRepository.RemoverFeedback(id);
        }
    }
}
