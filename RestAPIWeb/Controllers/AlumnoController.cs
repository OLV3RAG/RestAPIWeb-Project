using Aplicacion.Alumnos.Queries;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost ("Alumno/Crear")]
        public IActionResult Crear([FromBody] AlumnoCommand command)
        {
            List<AlumnoCommand> alumnos = new List<AlumnoCommand>();
            AlumnoCommandHandler alcommhan = new AlumnoCommandHandler();
            alumnos = alcommhan.Handle();
            return Ok(alumnos);
        }
        
           
        
    }
}
