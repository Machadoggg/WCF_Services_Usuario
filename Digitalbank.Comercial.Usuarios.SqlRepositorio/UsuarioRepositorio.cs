using Digitalbank.Comercial.Usuarios.Dominio;
using System.Collections.Generic;
using Digitalbank.Comercial.Usuarios.ContratoRepositorio;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Digitalbank.Comercial.Usuarios.SqlRepositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public Usuario AgregarUsuario(Usuario usuario)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("pNombre", usuario.Nombre);
                parametros.Add("pFechaNacimiento", usuario.FechaNacimiento);
                parametros.Add("pSexo", usuario.Sexo);

                var usuarioAgregado = conexion.ExecuteScalar<Usuario>("dbo.sp_agregar_usuario", param: parametros,
                    commandType: CommandType.StoredProcedure);
                return usuario;
            }
        }

        public Usuario ModificarUsuario(Usuario usuario)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("pIdUsuario", usuario.IdUsuario);
                parametros.Add("pNombre", usuario.Nombre);
                parametros.Add("pFechaNacimiento", usuario.FechaNacimiento);
                parametros.Add("pSexo", usuario.Sexo);

                var usuarioModificado = conexion.Execute("dbo.sp_modificar_usuario", param: parametros,
                    commandType: CommandType.StoredProcedure);
                return usuarioModificado > 0 ? usuario : new Usuario();
            }
        }

        public Usuario ConsultarUsuario(string idUsuario)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("pIdUsuario", idUsuario);

                var usuarioConsultado = conexion.QuerySingle<Usuario>("dbo.sp_consultar_usuario", param: parametros, 
                    commandType: CommandType.StoredProcedure);
                return usuarioConsultado;
            }
        }

        public Usuario EliminarUsuario(string idUsuario)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("pIdUsuario", idUsuario);

                var usuarioEliminado = conexion.QuerySingle<Usuario>("dbo.sp_eliminar_usuario", param: parametros,
                    commandType: CommandType.StoredProcedure);
                return usuarioEliminado;
            }
        }


        public IEnumerable<Usuario> ListarUsuario()
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var usuariosLista = conexion.Query<Usuario>("dbo.sp_listar_usuario", commandType: CommandType.StoredProcedure);
                return usuariosLista;
            }
        }
    }
}
