using Microsoft.AspNetCore.Mvc;

namespace Usuarios.Models
{
    public class ModificarViewModel
    {
        [Remote(action: "NombreExiste", controller: "Empleado")]
        public string CodigoEmpleado { get; set; }
    }
}
