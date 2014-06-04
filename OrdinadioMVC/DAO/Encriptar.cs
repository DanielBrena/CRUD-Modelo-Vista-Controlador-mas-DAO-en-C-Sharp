using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace OrdinadioMVC.DAO
{
    public class Encriptar : Controller
    {
        //
        // GET: /Encriptar/

        public string mensaje { get; set; }

        public Encriptar(string mensaje)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(mensaje));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            this.mensaje = sb.ToString();
        }
    }
}
