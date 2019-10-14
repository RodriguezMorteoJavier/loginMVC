using System;
using System.Collections.Generic;

namespace MVC_users.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            UsuarioRol = new HashSet<UsuarioRol>();
        }

        public string Nombre { get; set; }
        public string Pass { get; set; }
        public int Id { get; set; }
        public string Userid { get; set; }

        public ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
