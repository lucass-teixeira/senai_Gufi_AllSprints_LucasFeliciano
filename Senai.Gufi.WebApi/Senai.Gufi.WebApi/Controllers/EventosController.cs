using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using Senai.Gufi.WebApi.Repositories;

namespace Senai.Gufi.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class EventosController : ControllerBase
    {
        IEventoRepository _eventoRepository { get; set; }

        public EventosController()
        {
            _eventoRepository = new EventoRepository();
        }

        [HttpGet]
        public IEnumerable<Evento> ListarEventos()
        {
            return _eventoRepository.Listar();
        }

        [HttpGet("{id}")]
        public Evento BuscarPorId(int id)
        {
            return _eventoRepository.BuscarPorId(id);

        }

        [HttpPost]
        public IActionResult CadastrarEvento(Evento novoEvento)
        {
            _eventoRepository.Cadastrar(novoEvento);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEvento(int id ,Evento eventoAtualizado)
        {
            try
            {
                _eventoRepository.Atualizar(id, eventoAtualizado);

                return StatusCode(204);
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEvento(int id)
        {
            _eventoRepository.Deletar(id);

            return Ok();
        }



    }
}