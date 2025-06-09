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
    public class ServicoRepository : IServicoRepository
    {
        private readonly SqlContext _Context;

        public ServicoRepository(SqlContext context)
        {
            _Context = context;
        }
        public void AdicionarServico(Servico servico)
        {
            _Context.Servicos.Add(servico);
            _Context.SaveChanges();
        }

        public void AtualizarServico(Servico servico)
        {
            _Context.Servicos.Update(servico);
            _Context.SaveChanges();
        }

        public Servico BuscarServico(Guid Id)
        {
            return _Context.Servicos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Servico> BuscarTodosPaginado(Guid? prestadorId, int pagina, int tamanhoPagina)
        {
            var query = _Context.Servicos.AsQueryable();

            if (prestadorId.HasValue)
            {
                query = query.Where(s => s.Prestado_Id == prestadorId.Value);
            }

            return query
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToList();
        }

        public int ContarTotalServico(Guid? prestadorId)
        {
            var query = _Context.Servicos.AsQueryable();

            if (prestadorId.HasValue)
            {
                query = query.Where(s => s.Prestado_Id == prestadorId.Value);
            }

            return _Context.Servicos.Count();
        }

        public void RemoverServico(Guid id)
        {
            var servicoAlvo = _Context.Servicos.Find(id);
            _Context.Servicos.Remove(servicoAlvo);
            _Context.SaveChanges();
        }
    }
}
