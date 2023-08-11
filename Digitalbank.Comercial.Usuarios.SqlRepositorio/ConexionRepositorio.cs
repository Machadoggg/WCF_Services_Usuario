using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Digitalbank.Comercial.Usuarios.SqlRepositorio
{
    public class ConexionRepositorio
    {
        public static string ObtenerCadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["UsuariosDB"].ToString();
        }
    }
}
