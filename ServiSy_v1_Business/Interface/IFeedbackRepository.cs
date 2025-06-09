using ServiSy_v1_Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiSy_v1_Business.Interface
{
    public interface IFeedbackRepository
    {
        void AdicionarFeedback(Feedback feedback);
        Feedback BuscarFeedback(Guid Id);
        List<Feedback> BuscarTodosFeedback(Guid servicoId);
        void AtualizarFeedback(Feedback feedback);
        void RemoverFeedback(Guid id);
    }
}
