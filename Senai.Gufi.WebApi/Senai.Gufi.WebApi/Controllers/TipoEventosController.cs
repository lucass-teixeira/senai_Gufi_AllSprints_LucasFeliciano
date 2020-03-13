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

        [HttpGet("{id}")]
        public TipoEvento BuscarEventoPorId(int id)
        {
            return _tipoEventoRepository.BuscarPorId(id);
        }

        [HttpPost]
        public IActionResult CadastrarTipoEventos(TipoEvento novoTipoEvento)
        {
            _tipoEventoRepository.Cadastrar(novoTipoEvento);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarTipoEventos(int id, TipoEvento tipoEventoAtualizado)
        {
            _tipoEventoRepository.Atualizar(id, tipoEventoAtualizado);
            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _tipoEventoRepository.Deletar(id);

            return Ok();
        }
        
    }
}