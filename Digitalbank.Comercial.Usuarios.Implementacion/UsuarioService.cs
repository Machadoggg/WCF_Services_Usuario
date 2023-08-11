using System.Collections.Generic;
using Digitalbank.Comercial.Usuarios.Contrato;
using Digitalbank.Comercial.Usuarios.Dominio;
using Digitalbank.Comercial.Usuarios.Fachada;
using System.ServiceModel;
using System;

namespace Digitalbank.Comercial.Usuarios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        public Usuario AgregarUsuario(Usuario usuario)
        {
            using (var instancia = new UsuarioFachada())
            {
                return instancia.AgregarUsuario(usuario);
            }
        }

        public Usuario ModificarUsuario(Usuario usuario)
        {
            using (var instancia = new UsuarioFachada())
            {
                return instancia.ModificarUsuario(usuario);
            }
        }

        public Usuario ConsultarUsuario(string idUsuario)
        {
            try
            {
                using (var instancia = new UsuarioFachada())
                {
                    return instancia.ConsultarUsuario(idUsuario);
                }
            }
            catch (Exception ex)
            {

                throw new FaultException<Error>(new Error() { CodigoError = "10001", Descripcion = "Excepción administrada por el servicio", Mensaje = ex.Message});
            }   
        }
        public Usuario EliminarUsuario(string idUsuario)
        {
            using (var instancia = new UsuarioFachada())
            {
                return instancia.EliminarUsuario(idUsuario);
            }
        }

        public IEnumerable<Usuario> ListarUsuario()
        {
            using (var instancia = new UsuarioFachada())
            {
                return instancia.ListarUsuario();
            }
        }
    }
}
