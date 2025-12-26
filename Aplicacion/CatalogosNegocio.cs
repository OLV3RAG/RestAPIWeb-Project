using Infraestructura;
using Infraestructura.Entidades;
using Infraestructura.Generos;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Aplicacion
{
    public class CatalogoNegocio
    {
        private readonly IConfiguration _configuration;

        public CatalogoNegocio(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Genero> ObtenerCatalogoGen()
        {
            List<Genero> gene = new List<Genero>();
            GenerosDAO genDao = new GenerosDAO(_configuration);
            gene = genDao.ObtenerGenero();
            return gene;
        }
        public List<Materias> ObtenerCatalogoMat()
        {
            List<Materias> listaMaterias = new List<Materias>();
            MateriasDAO matDao = new MateriasDAO(_configuration);
           listaMaterias = matDao.ObtenerMaterias();
            return listaMaterias;
        }
        public List<TipoPersona> ObtenerCatalogoTipPer()
        {
            List<TipoPersona> tipPer = new List<TipoPersona>();
            TipoPersonasDAO tipPerDao = new TipoPersonasDAO(_configuration);
            tipPer = tipPerDao.ObtenerTipoPersona();
            return tipPer;
        }
    }
}
