using ServiSy_v1_Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiSy_v1_Business.Interface
{
    public interface IServicoRepository
    {
        void AdicionarServico(Servico servico);
        Servico BuscarServico(Guid Id);
        List<Servico> BuscarTodosServicos(Guid prestadorId);
        void AtualizarServico(Servico servico);
        void RemoverServico(Guid id);

    }
}
