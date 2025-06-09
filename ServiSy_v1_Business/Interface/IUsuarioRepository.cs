using ServiSy_v1_Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiSy_v1_Business.Interface
{
    public interface IUsuarioRepository
    {
        void AdicionarUsuario(Usuario usuario);
        Usuario BuscarUsuario(Guid id);
        Usuario BuscarPorEmail(string email);
        void AtualizarUsuario(Usuario usuario);
    }
}
