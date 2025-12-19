using Microsoft.Extensions.Configuration;


namespace Infraestructura.AccesoBD
{
    public class AccesoBD
    {
        private readonly string _connectionString;
        public AccesoBD(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CadenaSQL");
        }
    }
}
