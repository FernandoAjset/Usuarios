using Newtonsoft.Json;
using Usuarios.Models;

namespace Usuarios.Servicios
{
    public interface IRepositorioUsuarios
    {
        Task<int> CrearUsuario(Usuario usuario);
        Task<Usuario> ObtenerUsuario(string nombreUsuario);
    }
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly IConfiguration configuration;
        private readonly string URLApi;

        public RepositorioUsuarios(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.URLApi = this.configuration["Direciones:API"];
        }
        public async Task<int> CrearUsuario(Usuario usuario)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(URLApi + "api/usuarios");
            var postJob = await httpClient.PostAsJsonAsync<Usuario>("usuarios", usuario);

            var identity = 0;
            return identity;
        }

        public async Task<Usuario> ObtenerUsuario(string nombreUsuario)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(URLApi + $"api/usuarios/{nombreUsuario}");
            Usuario respuesta = new Usuario();
            respuesta = JsonConvert.DeserializeObject<Usuario>(json);
            return respuesta;
        }

    }
}
