using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace DAO_ORDINARIO
{
    public class UsuarioDAO:IUsuario
    {
        /*
         * Metodo que regresa un usuario por el id.
         * @param id Id del tipo string.
         * @return Usuario Regresa un usuario.
         */
        public Usuario selectUsuarioById(string id)
        {
            DataSource ds = new DataSource();
            DataTable dt = ds.ejecutarConsulta("SELECT * FROM usuario WHERE id = '" + id + "'");

            Usuario usuario = null;
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow registro in dt.Rows)
                {
                    usuario = new Usuario();
                    usuario.id = registro["id"].ToString();
                    usuario.nombre = registro["nombre"].ToString();
                    usuario.usuario = registro["usuario"].ToString();
                    usuario.contrasena = registro["contrasena"].ToString();
                    usuario.estatus = registro["estatus"].ToString();
                    PerfilDAO perfil = new PerfilDAO();
                    usuario.perfil_id = perfil.selectPerfilById(registro["perfil_id"].ToString());
                }
                return usuario;
            }
            else
            {
                return usuario;
            }

        }

        /*
         * Metodo que regresa una lista de usuarios.
         * @return List<Usuario> Lista de usuarios.
         */
        public List<Usuario> selectUsuarios()
        {
            DataSource ds = new DataSource();
            DataTable dt = ds.ejecutarConsulta("SELECT * FROM usuario ORDER BY usuario");
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario = null;

            foreach (DataRow registro in dt.Rows)
            {
                usuario = new Usuario();
                usuario.id = registro["id"].ToString();
                usuario.nombre = registro["nombre"].ToString();
                usuario.usuario = registro["usuario"].ToString();
                usuario.contrasena = registro["contrasena"].ToString();
                usuario.estatus = registro["estatus"].ToString();
                PerfilDAO perfil = new PerfilDAO();
                usuario.perfil_id = perfil.selectPerfilById(registro["perfil_id"].ToString());
                usuarios.Add(usuario);
                               
            }
            return usuarios;
        }

        /**
         * Metodo que busca un usuario por medio de su usuario y contrasena.
         * @return Usuario Usuario a regresar
         */ 
        public Usuario searchUsuario(string usuario, string contrasena)
        {
            string sql = "SELECT * FROM usuario WHERE usuario = '" + usuario 
                             +   "' AND contrasena = '" + contrasena + "'";
            DataSource ds = new DataSource();
            DataTable dt = ds.ejecutarConsulta(sql);

            Usuario usuarioO = null;
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow registro in dt.Rows)
                {
                    usuarioO = new Usuario();
                    usuarioO.id = registro["id"].ToString();
                    usuarioO.nombre = registro["nombre"].ToString();
                    usuarioO.usuario = registro["usuario"].ToString();
                    usuarioO.contrasena = registro["contrasena"].ToString();
                    usuarioO.estatus = registro["estatus"].ToString();
                    PerfilDAO perfil = new PerfilDAO();
                    usuarioO.perfil_id = perfil.selectPerfilById(registro["perfil_id"].ToString());
                }
                return usuarioO;
            }
            else
            {
                return usuarioO;
            }
        }

        /**
         * Metodo que inserta un usuario.
         * @return int Regresa 1 si fue exitosa la execucion o 0 si fallo.
         */
        public int insertUsuario(Usuario usuario)
        {
            DataSource dt = new DataSource();
            string sql = "INSERT INTO usuario  VALUES ('" + usuario.id + "', '" + usuario.nombre
                + "' ,'" + usuario.usuario + "','" + usuario.contrasena + "','" + usuario.estatus + "','" + usuario.perfil_id.id + "')";
            int resultado = dt.ejecutarActualizacion(sql);
            return resultado;
        }

        /**
         * Metodo que actuliza un usuario.
         * @return int Regresa 1 si fue exitosa la execucion o 0 si fallo.
         */
        public int updateUsuario(Usuario usuario)
        {
            DataSource ds = new DataSource();
            string sql = "UPDATE usuario SET  nombre = '" + usuario.nombre + "', usuario ='" 
                + usuario.usuario + "',  estatus = '" 
                + usuario.estatus  + "', perfil_id = '" + usuario.perfil_id.id + "' WHERE id = '" + usuario.id+"'";
            int resultado = ds.ejecutarActualizacion(sql);
            return resultado;
        }

        /**
         * Metodo que elimina un usuario.
         * @return int Regresa 1 si fue exitosa la execucion o 0 si fallo.
         */
        public int deleteUsuario(string id)
        {
            DataSource ds = new DataSource();
            string sql = "DELETE FROM usuario WHERE id = '" + id + "'";
            int resultado = ds.ejecutarActualizacion(sql);
            return resultado;
   
        }

        /**
         * Metodo que busca en los usuarios.
         * @return List<Usuario> Lista de usuarios.
         */
        public List<Usuario> search(string usuarioB)
        {
            DataSource ds = new DataSource();
            string sql = "SELECT * FROM usuario WHERE  usuario like '%"+usuarioB+"%' " +
                " ORDER BY usuario";
            DataTable dt = ds.ejecutarConsulta(sql);
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario = null;

            foreach (DataRow registro in dt.Rows)
            {
                usuario = new Usuario();
                usuario.id = registro["id"].ToString();
                usuario.nombre = registro["nombre"].ToString();
                usuario.usuario = registro["usuario"].ToString();
                usuario.contrasena = registro["contrasena"].ToString();
                usuario.estatus = registro["estatus"].ToString();
                PerfilDAO perfil = new PerfilDAO();
                usuario.perfil_id = perfil.selectPerfilById(registro["perfil_id"].ToString());
                usuarios.Add(usuario);

            }
            return usuarios;
        }
        
    }
}
