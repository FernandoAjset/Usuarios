using System;
using System.Collections.Generic;

#nullable disable

namespace Usuarios.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string CodigoEmpleado { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
