using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO_ORDINARIO
{
    public interface IUsuario
    {
        Usuario selectUsuarioById(string id);
        List<Usuario> selectUsuarios();
        Usuario searchUsuario(string usuario, string contrasena);
        int insertUsuario(Usuario usuario);
        int updateUsuario(Usuario usuario);
        int deleteUsuario(string id);
    }
}
