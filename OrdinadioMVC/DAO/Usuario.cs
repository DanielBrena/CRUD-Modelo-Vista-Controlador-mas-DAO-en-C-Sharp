using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO_ORDINARIO
{
    public class Usuario
    {
        public string id { set; get; }
        public string nombre { set; get; }
        public string usuario { set; get; }
        public string contrasena { set; get; }
        public string estatus { set; get; }
        public Perfil perfil_id { set; get; }
    }
}
