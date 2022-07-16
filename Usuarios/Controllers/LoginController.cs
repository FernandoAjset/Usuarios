using Microsoft.AspNetCore.Mvc;

namespace Usuarios.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
