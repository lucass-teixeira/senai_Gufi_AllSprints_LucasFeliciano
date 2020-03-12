using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;

namespace Senai.Gufi.WebApi.Controllers
{
    [Produces("application/json")]
     
    [Route("api/[controller]")]

    [ApiController]
    public class TipoEventosController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository { get; set; }

        public TipoEventosController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }
        [HttpGet]
        public IEnumerable<TipoEvento> Listar()
        {
            return _tipoEventoRepository.ListarEventos();
        }
    }
}