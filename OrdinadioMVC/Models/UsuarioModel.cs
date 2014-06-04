using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO_ORDINARIO;

namespace OrdinadioMVC.Models
{
    public class UsuarioModel : Controller
    {
        //
        // GET: /UsuarioModel/

        public Usuario usuario { get; set; }
        public List<Usuario> usuarios { get; set; }

    }
}
