using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiSy_v1_Business.DTOs
{
    public class FeedbackCreateDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, 5, ErrorMessage = "A {0} deve estar entre {1} e {2}")]
        public int Nota { get; set; }

        [StringLength(500, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string? Comentario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Servico_Id { get; set; }
    }
}
