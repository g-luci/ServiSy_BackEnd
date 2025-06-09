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
    [Route("v1/feedbacks")]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService _feedbackService;
        private readonly UsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public FeedbackController(FeedbackService feedbackService, IMapper mapper, UsuarioService usuarioService)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult AdicionarFeedback([FromBody] FeedbackCreateDto feedbackDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            _feedbackService.AdicionarFeedback(_mapper.Map<Feedback>(feedbackDto), Guid.Parse(userIdClaim));

            return Ok("FeedBack criado com sucesso");
        }

        [HttpGet]
        [Route("{id}")]
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
        [AllowAnonymous]
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
        [Route("{id}")]
        public IActionResult AtualizarFeedback(Guid id, [FromBody] FeedbackEditDto feedbackDto)
        {
            var feedbackAlvo = _feedbackService.BuscarFeedback(id);
            if (feedbackAlvo == null)
            {
                return NotFound();
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || feedbackAlvo.Usuario_Id != Guid.Parse(userIdClaim))
            {
                return Forbid();
            }

            _feedbackService.AtualizarFeedback(id, feedbackDto);

            return Ok("Feedback atualizado");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult RemoverFeedback(Guid id)
        {
            var feedbackAlvo = _feedbackService.BuscarFeedback(id);
            if (feedbackAlvo == null)
            {
                return NoContent();
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || feedbackAlvo.Usuario_Id != Guid.Parse(userIdClaim))
            {
                return Forbid();
            }

            _feedbackService.RemoverFeedback(id);
            return NoContent();
        }
    }
}
