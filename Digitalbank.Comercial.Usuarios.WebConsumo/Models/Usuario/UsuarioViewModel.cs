using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Digitalbank.Comercial.Usuarios.WebConsumo.Models.Usuario
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
    }
}