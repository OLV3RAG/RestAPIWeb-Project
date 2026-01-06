using Aplicacion.Alumnos.Queries;
using Microsoft.AspNetCore.Mvc;
using RestAPIWeb.Controllers;

namespace RestAPI.Controllers
{
    public class AlumnoController : Controller
    {
        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CatalogosController> _logger;

        private IConfiguration configuration;

        public AlumnoController(ILogger<CatalogosController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost ("Alumno/Crear")]
        public IActionResult Crear([FromBody] AlumnoCommand command)
        {
            List<AlumnoCommand> alumnos = new List<AlumnoCommand>();
            AlumnoCommandHandler alcommhan = new AlumnoCommandHandler(configuration);
            alumnos = alcommhan.Handle();
            return Ok(alumnos);
        }
        
           
        
    }
}
