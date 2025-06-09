using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiSy_v1_Business.DTOs;
using ServiSy_v1_Business.Models;
using ServiSy_v1_Business.Service;

namespace ServiSy_v1_API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService _feedbackService;
        private readonly IMapper _mapper;

        public FeedbackController(FeedbackService feedbackService, IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("adicionar")]
        public IActionResult AdicionarFeedback([FromBody] FeedbackCreateDto feedbackDto)
        {
            _feedbackService.AdicionarFeedback(_mapper.Map<Feedback>(feedbackDto));

            return Ok("FeedBack criado com sucesso");
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult BuscarFeedback(Guid id)
        {
            var feedback = _feedbackService.BuscarFeedback(id);
            if (feedback == null)
            {
                return NotFound();
            }

            var feedbackDto = _mapper.Map<FeedbackDto>(feedback);

            return Ok(feedbackDto);
        }

        [HttpGet]
        [Route("buscar_todos/{servicoId}")]
        public IActionResult BuscarTodosFeedback(Guid servicoId)
        {
            var feedbacks = _feedbackService.BuscarTodosFeedback(servicoId);
            if (feedbacks == null || !feedbacks.Any())
            {
                return NotFound();
            }

            var feedbacksDto = _mapper.Map<List<FeedbackDto>>(feedbacks);

            return Ok(feedbacksDto);
        }

        [HttpPatch]
        [Route("atualizar/{id}")]
        public IActionResult AtualizarFeedback(Guid id, [FromBody] FeedbackEditDto feedbackDto)
        {
            _feedbackService.AtualizarFeedback(id, feedbackDto);

            return Ok("Feedback atualizado");
        }

        [HttpDelete]
        [Route("remover/{id}")]
        public IActionResult RemoverFeedback(Guid id)
        {
            _feedbackService.RemoverFeedback(id);
            return NoContent();
        }
    }
}
