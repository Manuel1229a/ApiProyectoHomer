using ApiProyecto.Models;
using System.Linq;
using System.Web.Http;

namespace ApiProyecto.Controllers
{
    [RoutePrefix("api")]
    public class LoginController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // POST api/login
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Usuario) || string.IsNullOrWhiteSpace(request.Contraseña))
            {
                return BadRequest("Usuario y contraseña son requeridos.");
            }

            var usuario = db.Usuarios
                .FirstOrDefault(u => u.Nombre == request.Usuario && u.Contraseña == request.Contraseña);


            if (usuario == null)
            {
                return Unauthorized();
            }

            // Por ahora devolvemos datos simples
            return Ok(new
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Mensaje = "Inicio de sesión exitoso"
            });
        }
    }

    public class LoginRequest
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    }
}
