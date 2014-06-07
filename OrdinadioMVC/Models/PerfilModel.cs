using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO_ORDINARIO;

namespace OrdinadioMVC.Models
{
    public class PerfilModel : Controller
    {
        //
        // GET: /PerfilModel/

        public Perfil perfil { get; set; }
        public List<Perfil> perfiles { get; set; }

    }
}
