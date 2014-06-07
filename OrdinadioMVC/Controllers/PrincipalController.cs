using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrdinadioMVC.Models;
using DAO_ORDINARIO;
using System.Text;
using OrdinadioMVC.DAO;

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
        public ActionResult Salir()
        {
            Session["usuario"] = null;
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public JsonResult FindAllUsuarios()
        {
            UsuarioModel um = new UsuarioModel();
            um.usuarios = new UsuarioDAO().selectUsuarios();
            return Json(um.usuarios, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Search(string s)
        {
            UsuarioModel um = new UsuarioModel();
            um.usuarios = new UsuarioDAO().search(s);
            return Json(um.usuarios, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult FindAllPerfiles()
        {
            PerfilModel pm = new PerfilModel();
            pm.perfiles = new PerfilDAO().selectPerfiles();
            return Json(pm.perfiles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult FindByIdUsuario(string id)
        {
            UsuarioModel um = new UsuarioModel();
            um.usuario = new UsuarioDAO().selectUsuarioById(id);
            return Json(um.usuario, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteByIdUsuario(string id)
        {
            UsuarioDAO usuario = new UsuarioDAO();
            int eliminado = usuario.deleteUsuario(id);
            return Json(new { 
                eli = eliminado
            });
        }

        [HttpPost]
        public JsonResult UpdateUsuario(string id, string nombre, string usuario, string contrasena, string estatus, string perfil_id)
        {
            
            Usuario usuarioObj = new Usuario();
            usuarioObj.id = id;
            usuarioObj.nombre = nombre;
            usuarioObj.usuario = usuario;
            usuarioObj.contrasena = contrasena;
            usuarioObj.estatus = estatus;
            Perfil perfil = new PerfilDAO().selectPerfilById(perfil_id);
            usuarioObj.perfil_id = perfil;

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            int update = usuarioDAO.updateUsuario(usuarioObj);
            return Json(new
            {
                upd = update
            });

        }

        [HttpPost]
        public JsonResult AddUsuario(string id, string nombre, string usuario, string contrasena, string estatus, string perfil_id)
        {

            string identificadorUnico = Guid.NewGuid().ToString();
            identificadorUnico = identificadorUnico.Replace("-", "");

            Usuario usuarioObj = new Usuario();
            usuarioObj.id = identificadorUnico;
            usuarioObj.nombre = nombre;
            usuarioObj.usuario = usuario;
            Encriptar encriptar = new Encriptar(contrasena);
            usuarioObj.contrasena = encriptar.mensaje;
            usuarioObj.estatus = estatus;
            Perfil perfil = new PerfilDAO().selectPerfilById(perfil_id);
            usuarioObj.perfil_id = perfil;

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            int add = usuarioDAO.insertUsuario(usuarioObj);
            return Json(new
            {
                ins = add
            });

        }

        [HttpPost]
        public JsonResult AddPerfil(string id, string nombre, string descripion, string estatus)
        {

            string identificadorUnico = Guid.NewGuid().ToString();
            identificadorUnico = identificadorUnico.Replace("-", "");

            Perfil perfilObj = new Perfil();
            perfilObj.id = identificadorUnico;
            perfilObj.nombre = nombre;
            perfilObj.descripcion = descripion;

            perfilObj.estatus = estatus;
            

            PerfilDAO perfilDAO = new PerfilDAO();
            int add = perfilDAO.insertPerfil(perfilObj);
            return Json(new
            {
                ins = add
            });

        }

        
    }
}
