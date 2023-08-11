using Digitalbank.Comercial.Usuarios.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digitalbank.Comercial.Usuarios.ContratoRepositorio;
using Digitalbank.Comercial.Usuarios.SqlRepositorio;

namespace Digitalbank.Comercial.Usuarios.Fachada
{
    public class UsuarioFachada : IDisposable
    {
        public Usuario AgregarUsuario(Usuario usuario)
        {
            IUsuarioRepositorio instancia = new UsuarioRepositorio();
            return instancia.AgregarUsuario(usuario);
        }
        public Usuario ModificarUsuario(Usuario usuario)
        {
            IUsuarioRepositorio instancia = new UsuarioRepositorio();
            return instancia.ModificarUsuario(usuario);
        }
        public Usuario ConsultarUsuario(string idUsuario)
        {
            IUsuarioRepositorio instancia = new UsuarioRepositorio();
            return instancia.ConsultarUsuario(idUsuario);
        }
        public Usuario EliminarUsuario(string idUsuario)
        {
            IUsuarioRepositorio instancia = new UsuarioRepositorio();
            return instancia.EliminarUsuario(idUsuario);
        }

        public IEnumerable<Usuario> ListarUsuario()
        {
            IUsuarioRepositorio instancia = new UsuarioRepositorio();
            return instancia.ListarUsuario();
        }

       
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
