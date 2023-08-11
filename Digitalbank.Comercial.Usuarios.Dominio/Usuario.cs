using System;
using System.Runtime.Serialization;

namespace Digitalbank.Comercial.Usuarios.Dominio
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public string Sexo { get; set; }
    }
}
