using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiSy_v1_Business.Models
{
    public class Servico
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Prestado_Id { get; set; }
        public Usuario Prestador { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }

    }
}
