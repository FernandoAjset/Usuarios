using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Usuarios.Models
{
    public partial class EmpleadoDTO
    {
        public string Pais { get; set; }
        public string Titulo { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public string FechaNacimiento { get; set; }
        public string TelefonoMovil { get; set; }
        public IEnumerable<SelectListItem> TiposTitulo { get; set; }
    }
}
