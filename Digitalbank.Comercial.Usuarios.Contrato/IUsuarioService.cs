using Digitalbank.Comercial.Usuarios.Dominio;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Digitalbank.Comercial.Usuarios.Contrato
{
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        [Description("Servicio REST que permite agregar información de usuario")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/AgregarUsuario", BodyStyle = WebMessageBodyStyle.Bare)]
        Usuario AgregarUsuario(Usuario usuario);

        [OperationContract]
        [Description("Servicio REST que permite modificar la información de usuario")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/ModificarUsuario", BodyStyle = WebMessageBodyStyle.Bare)]
        Usuario ModificarUsuario(Usuario usuario);

        [OperationContract]
        [Description("Servicio REST que permite consultar la información de usuario")]
        [FaultContract(typeof(Error))]
        [WebGet (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ConsultarUsuario/{idUsuario}", BodyStyle = WebMessageBodyStyle.Bare)]
        Usuario ConsultarUsuario(string idUsuario);

        [OperationContract]
        [Description("Servicio REST que permite eliminae la información de un usuario")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "DELETE", UriTemplate = "/EliminarUsuario/{idUsuario}", BodyStyle = WebMessageBodyStyle.Bare)]
        Usuario EliminarUsuario(string idUsuario);


        [OperationContract]
        [Description("Servicio REST que listar la información de usuarios")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarUsuario", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Usuario> ListarUsuario();

    }
}
