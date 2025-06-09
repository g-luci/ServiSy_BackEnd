using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiSy_v1_Business.DTOs
{
    public class FeedbackDto
    {
        public Guid Id { get; set; }
        public int Nota { get; set; }
        public string? Comentario { get; set; }
        public Guid Servico_Id { get; set; }
        public Guid Usuario_Id { get; set; }
        public string NomeUsuario { get; set; }
    }
}
