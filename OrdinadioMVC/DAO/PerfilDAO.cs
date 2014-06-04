using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAO_ORDINARIO
{
    public class PerfilDAO:IPerfil
    {
        public Perfil selectPerfilById(string id)
        {
            DataSource ds = new DataSource();
            DataTable dt = ds.ejecutarConsulta("SELECT * FROM perfil WHERE id = '" + id +"'" );

            Perfil perfil = null;
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow registro in dt.Rows)
                {
                    perfil = new Perfil();
                    perfil.id = registro["id"].ToString();
                    perfil.nombre = registro["nombre"].ToString();
                    perfil.descripcion = registro["descripcion"].ToString();
                    perfil.estatus = registro["estatus"].ToString();
                }
                return perfil;
            }
            else
            {
                return perfil;
            }
            



        }

        public List<Perfil> selectPerfiles()
        {
            DataSource ds = new DataSource();
            DataTable dt = ds.ejecutarConsulta("SELECT * FROM perfil");
            List<Perfil> perfiles = new List<Perfil>();
            Perfil perfil = null;
            foreach (DataRow registro in dt.Rows)
            {
                perfil = new Perfil();
                perfil.id = registro["id"].ToString();
                perfil.nombre = registro["nombre"].ToString();
                perfil.descripcion = registro["descripcion"].ToString();
                perfil.estatus = registro["estatus"].ToString();
                perfiles.Add(perfil);
            }

            return perfiles;
        }

        
    }
}
