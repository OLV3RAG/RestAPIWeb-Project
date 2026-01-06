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

        public List<Personas> InsertarAlumnos()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            List<Personas> alumnos = new List<Personas>();

            try
            {
                using (conn)
                {
                    conn.Open();
                    Personas per = new Personas();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_InsertarPersona";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", per.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", per.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno",per.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", per.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@CURP", per.CURP);
                    cmd.Parameters.AddWithValue("@DireccionID", per.DireccionID);
                    cmd.Parameters.AddWithValue("@TipoPersonaID", per.TipoPersonaID);
                    cmd.Parameters.AddWithValue("@GeneroID", per.GeneroID);
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
                throw new Exception("Error al insertar los alumnos: " + ex.Message);
            }
            return alumnos;
        }
    }
}
