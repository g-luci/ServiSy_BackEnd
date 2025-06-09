using ServiSy_v1_Business.Interface;
using ServiSy_v1_Business.Models;
using ServiSy_v1_Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiSy_v1_Data.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly SqlContext _Context;

        public FeedbackRepository(SqlContext context)
        {
            _Context = context;
        }

        public void AdicionarFeedback(Feedback feedback)
        {
            _Context.Feedbacks.Add(feedback);
            _Context.SaveChanges();
        }

        public void AtualizarFeedback(Feedback feedback)
        {
            _Context.Feedbacks.Update(feedback);
            _Context.SaveChanges();
        }

        public Feedback BuscarFeedback(Guid Id)
        {
            return _Context.Feedbacks.FirstOrDefault(x => x.Id == Id);
        }

        public List<Feedback> BuscarTodosFeedback(Guid servicoId)
        {
            return _Context.Feedbacks.Where(x => x.Servico_Id == servicoId).ToList();
        }

        public void RemoverFeedback(Guid id)
        {
            var feedbackAlvo = _Context.Feedbacks.Find(id);
            _Context.Feedbacks.Remove(feedbackAlvo);
            _Context.SaveChanges();
        }
    }
}
