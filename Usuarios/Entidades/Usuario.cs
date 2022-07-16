using System;
using System.Collections.Generic;

namespace Usuarios.Entidades
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public byte Estatus { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
    }
}
