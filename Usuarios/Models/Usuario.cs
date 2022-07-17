using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Usuarios.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo{0} es requerido")]
        [StringLength(maximumLength: 10, ErrorMessage = "No puede ser mayor a {1} caracteres")]      
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El campo{0} es requerido")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 20, ErrorMessage = "No puede ser mayor a {1} caracteres")]
        public string Contrasenia { get; set; }
    }
}
