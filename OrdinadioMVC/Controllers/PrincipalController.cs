using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrdinadioMVC.Models;
using DAO_ORDINARIO;

namespace OrdinadioMVC.Controllers
{
    public class PrincipalController : Controller
    {
        //
        // GET: /Principal/
        
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Home");
               
            }
            else
            {
                return View();
            }
            
        }

        [HttpGet]
        public JsonResult FindAll()
        {
            UsuarioModel um = new UsuarioModel();
            um.usuarios = new UsuarioDAO().selectUsuarios();
            return Json(um.usuarios, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult FindById(string id)
        {
            UsuarioModel um = new UsuarioModel();
            um.usuario = new UsuarioDAO().selectUsuarioById(id);
            return Json(um.usuario, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteById(string id)
        {
            UsuarioDAO usuario = new UsuarioDAO();
            int eliminado = usuario.deleteUsuario(id);
            return Json(new { 
                eli = eliminado
            });
        }

    }
}
