using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiSy_v1_Business.Models
{
    public class Feedback
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Nota { get; set; }
        public string? Comentario { get; set; }
        public Guid Servico_Id { get; set; }
        public Servico Servico { get; set; }
        public Guid Usuario_Id { get; set; }
        public Usuario Usuario { get; set; }
    }
}
