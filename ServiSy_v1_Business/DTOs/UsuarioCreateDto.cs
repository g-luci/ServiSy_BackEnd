using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiSy_v1_Business.DTOs
{
    public class UsuarioCreateDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter no máximo {1} caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O formato do email é inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "A {0} deve ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        public bool Prestador { get; set; } = false;
    }
}
