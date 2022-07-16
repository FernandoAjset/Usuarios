using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Usuarios.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Usuarios = new HashSet<Usuario>();
        }
        [NotMapped]
        public int Id { get; set; }

        //[Remote(action: "NombreExiste", controller: "Empleado")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Codigo de empleado")]
        [StringLength(maximumLength: 10, ErrorMessage = "No puede ser mayor a {1} caracteres")]
        public string CodigoEmpleado { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "No puede ser mayor a {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Titulo { get; set; }

        [StringLength(maximumLength: 15, ErrorMessage = "No puede ser mayor a {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Primer nombre")]
        public string PrimerNombre { get; set; }

        [StringLength(maximumLength: 15, ErrorMessage = "No puede ser mayor a {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Segundo nombre")]
        public string SegundoNombre { get; set; }

        [StringLength(maximumLength: 15, ErrorMessage = "No puede ser mayor a {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Primer apellido")]
        public string PrimerApellido { get; set; }

        [StringLength(maximumLength: 15, ErrorMessage = "No puede ser mayor a {1} caracteres")]
        [Display(Name = "Segundo apellido")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string SegundoApellido { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "No puede ser mayor a {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Debe ingresar una dirección de email valida")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha de nacimiento")]
        public string FechaNacimiento { get; set; }

        [StringLength(maximumLength: 15, ErrorMessage = "No puede ser mayor a {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Telefono movil")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Debe ingresar un telefono valido")]
        public string TelefonoMovil { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
