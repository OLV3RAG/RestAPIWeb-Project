using Infraestructura.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class AlumnoDAO
    {
        private readonly string _connectionString;

        public AlumnoDAO()
        {
        }
        public AlumnoDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Personas> ObtenerAlumnos()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            List<Personas> alumnos = new List<Personas>();
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_ObtenerPersona";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Personas alumno = new Personas();
                        alumno.ID = reader.GetInt32(0);
                        alumno.Nombre = reader.GetString(1);
                        alumno.ApellidoPaterno = reader.GetString(2);
                        alumno.ApellidoMaterno = reader.GetString(3);
                        alumno.FechaNacimiento = reader.GetDateTime(4);
                        alumno.CURP = reader.GetString(5);
                        alumno.DireccionID = reader.GetInt32(6);
                        alumno.TipoPersonaID = reader.GetInt32(7);
                        alumno.GeneroID = reader.GetInt32(8);
                        alumnos.Add(alumno);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los alumnos: " + ex.Message);

            }
            return alumnos;
        }
    }
}
