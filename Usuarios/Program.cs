using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Usuarios.Models;
using Usuarios.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

////<[Fernando Ajset] Configuración para evitar que se pueda accedar a operaciones si no está logueado >
//var politicaUsuariosAutenticados = new AuthorizationPolicyBuilder()
//    .RequireAuthenticatedUser()
//    .Build();
//builder.Services.AddControllersWithViews(opciones =>
//{
//    opciones.Filters.Add(new AuthorizeFilter(politicaUsuariosAutenticados));
//});
////<[Fernando Ajset] Configuración para uso de Cookies en aplicación>

builder.Services.AddControllersWithViews();

//<[Fernando Ajset] Configuración IdentityCore>
builder.Services.AddTransient<IRepositorioUsuarios, RepositorioUsuarios>();
builder.Services.AddTransient<IUserStore<Usuario>, UsuarioStore>();

builder.Services.AddTransient<SignInManager<Usuario>>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddIdentityCore<Usuario>(opciones =>
{
    opciones.Password.RequireDigit = false;
    opciones.Password.RequireLowercase = false;
    opciones.Password.RequireUppercase = false;
    opciones.Password.RequireNonAlphanumeric = false;
});
//<[Fernando Ajset] Configuración IdentityCore>


//<[Fernando Ajset] Configuración para uso de Cookies en aplicación y configurar path de Authorize>
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;

}).AddCookie(IdentityConstants.ApplicationScheme);
//<[Fernando Ajset] Configuración para uso de Cookies en aplicación>

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//<[Fernando Ajset] Configuración para uso de Cookies en aplicación>
app.UseAuthentication();
//<[Fernando Ajset] Configuración para uso de Cookies en aplicación>

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();
