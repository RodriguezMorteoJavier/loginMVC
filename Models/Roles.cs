using System;
using System.Collections.Generic;

namespace MVC_users.Models
{
    public partial class Roles
    {
        public Roles()
        {
            UsuarioRol = new HashSet<UsuarioRol>();
        }

        public int Idroles { get; set; }
        public string Nombrerol { get; set; }

        public ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
