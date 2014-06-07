using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO_ORDINARIO
{
    public interface IPerfil
    {
        Perfil selectPerfilById(string id);
        List<Perfil> selectPerfiles();
        int insertPerfil(Perfil perfil);
    }
}
