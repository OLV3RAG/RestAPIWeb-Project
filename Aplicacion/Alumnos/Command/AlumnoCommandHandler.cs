using Infraestructura;
using Infraestructura.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Alumnos.Queries
{
    public class AlumnoCommandHandler
    {
        private readonly IConfiguration _configuration;

        public AlumnoCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<AlumnoCommand> Handle()
        {
            List<Personas> alumnos = new List<Personas>();
            AlumnoDAO alumnoDAO = new AlumnoDAO(_configuration);
            alumnos = alumnoDAO.InsertarAlumnos();
            List<AlumnoCommand> alumnoQueries = new List<AlumnoCommand>();
            foreach (var alumno in alumnos)
            {
                alumnoQueries.Add(new AlumnoCommand
                {
                    ID = alumno.ID,
                    Nombre = alumno.Nombre,
                    ApellidoPaterno = alumno.ApellidoPaterno,
                    ApellidoMaterno = alumno.ApellidoMaterno,
                    FechaNacimiento = alumno.FechaNacimiento,
                    CURP = alumno.CURP,
                    DireccionID = alumno.DireccionID,
                    TipoPersonaID = alumno.TipoPersonaID,
                    GeneroID = alumno.GeneroID
                });
            }
            return alumnoQueries;
        }
    }
}
