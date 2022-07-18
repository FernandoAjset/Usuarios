
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Usuarios.Models;

namespace Usuarios.Controllers
{
    //<[Fernando Ajset] Restricción de acceso a las acciones, para poder ingresar solo si se está autenticado.>
    [Authorize]
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //http://www.ApiUsuario.somee.com/api/empleados
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://www.ApiUsuario.somee.com/api/empleados");

            List<Empleado> empleados = JsonConvert.DeserializeObject<List<Empleado>>(json);

            if (empleados.Count > 0)
            {
                return View(empleados);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Empleado nuevoEmpleado)
        {


            if (!ModelState.IsValid)
            {
                return View(nuevoEmpleado);
            }
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://www.ApiUsuario.somee.com/api/empleados");
            var postJob = await httpClient.PostAsJsonAsync<Empleado>("empleados", nuevoEmpleado);
            var postResult = postJob.StatusCode;
            if (postResult == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("NoEncontrado");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int Id)
        {
            //http://www.ApiUsuario.somee.com/api/empleados
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"http://www.ApiUsuario.somee.com/api/empleados/{Id}");

            Empleado empleado = JsonConvert.DeserializeObject<Empleado>(json);

            if (empleado is not null)
            {
                return View(empleado);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return View(empleado);
            }
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://www.ApiUsuario.somee.com/api/empleados");
            var putJob = await httpClient.PutAsJsonAsync<Empleado>("empleados", empleado);
            var putResult = putJob.StatusCode;
            if (putResult == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("NoEncontrado");
            }
        }

        [HttpGet]
        public async Task<IActionResult> BorrarEmpleado(int Id)
        {
            //http://www.ApiUsuario.somee.com/api/empleados
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"http://www.ApiUsuario.somee.com/api/empleados/{Id}");

            Empleado empleado = JsonConvert.DeserializeObject<Empleado>(json);

            if (empleado is not null)
            {
                return View(empleado);
            }
            return View("NoEncontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Borrar(int Id)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://www.ApiUsuario.somee.com/api/");
            var deleteTask = await httpClient.DeleteAsync("empleados/" + Id.ToString());
            var result = deleteTask.StatusCode;
            if (result == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            return View("NoEncontrado");
        }


        [HttpGet]
        public async Task<IActionResult> NombreExiste(Empleado empleado)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"http://www.ApiUsuario.somee.com/api/empleados/{empleado.CodigoEmpleado}");
            Empleado respuesta = new Empleado();
            respuesta = JsonConvert.DeserializeObject<Empleado>(json);

            if (!string.IsNullOrEmpty(respuesta.CodigoEmpleado))
            {
                return Json($"Ya existe un empleado con codigo {empleado.CodigoEmpleado}");
            }
            return Json("true");
        }
    }
}
