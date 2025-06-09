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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlContext _Context;

        public UsuarioRepository(SqlContext context)
        {
            _Context = context;
        }

        public void AdicionarUsuario(Usuario usuario) 
        { 
            _Context.Usuarios.Add(usuario);
            _Context.SaveChanges();
        }

        public Usuario BuscarUsuario(Guid id)
        {
            return _Context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _Context.Usuarios.Update(usuario);
            _Context.SaveChanges();
        }
    }
}
