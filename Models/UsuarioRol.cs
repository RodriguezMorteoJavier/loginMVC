using System;
using System.Collections.Generic;

namespace MVC_users.Models
{
    public partial class UsuarioRol
    {
        public int Idur { get; set; }
        public int? Idusuario { get; set; }
        public int? Idrol { get; set; }

        public Roles IdrolNavigation { get; set; }
        public Usuarios IdusuarioNavigation { get; set; }
    }
}
