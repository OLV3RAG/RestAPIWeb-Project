using Infraestructura;
using Infraestructura.Entidades;
using Microsoft.Extensions.Configuration;

namespace Aplicacion.Direcciones.Queries
{
    public class MunicipioQueryHandler
    {
        private readonly IConfiguration _configuration;

        public MunicipioQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<MunicipioQuery> Handle()
        {
            List<Municipios> municipios = new List<Municipios>();
            Localidades loc = new Localidades(_configuration);
            municipios = loc.ObtenerMunicipios();
            List<MunicipioQuery> municipioQueries = new List<MunicipioQuery>();
            foreach (var municipio in municipios)
            {
                municipioQueries.Add(new MunicipioQuery
                {
                    Num = municipio.ID,
                    Descripcion = municipio.Nombre
                });
            }
            return municipioQueries;
        }
    }
}
