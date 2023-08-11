using Digitalbank.Comercial.Usuarios.Dominio;
using System.Collections.Generic;

namespace Digitalbank.Comercial.Usuarios.ContratoRepositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario AgregarUsuario(Usuario usuario);
        Usuario ModificarUsuario(Usuario usuario);
        Usuario ConsultarUsuario(string idUsuario);
        Usuario EliminarUsuario(string idUsuario);

        IEnumerable<Usuario> ListarUsuario();
    }
}
