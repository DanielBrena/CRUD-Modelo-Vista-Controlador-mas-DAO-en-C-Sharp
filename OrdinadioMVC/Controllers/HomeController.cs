using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrdinadioMVC.Models;
using DAO_ORDINARIO;
using OrdinadioMVC.DAO;


namespace OrdinadioMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Principal");
            }
            
        }

        [HttpPost]
        public JsonResult Index(string usuario, string contrasena)
        {
            UsuarioModel um = new UsuarioModel();
            Encriptar encriptar = new Encriptar(contrasena);
            um.usuario = new UsuarioDAO().searchUsuario(usuario, encriptar.mensaje);

            if (um.usuario != null)
            {
                Session["usuario"] = um.usuario;
                return Json(new { 
                    redirectUrl = Url.Action("Index","Principal"),
                    isRedirect = true
                });
            }
            else
            {
                return Json("No se encontro");
            }
           
        }

       

    }
}
