using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, TipoEvento tipoEventoAtualizado)
        {
            TipoEvento eventoBuscado = ctx.TipoEvento.Find(id);

            eventoBuscado.Evento = tipoEventoAtualizado.Evento;
            eventoBuscado.IdTipoEvento = tipoEventoAtualizado.IdTipoEvento;
            eventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;

            ctx.TipoEvento.Update(tipoEventoAtualizado);

            ctx.SaveChanges();

        }

        public TipoEvento BuscarPorId(int id)
        {
            return ctx.TipoEvento.FirstOrDefault(e => e.IdTipoEvento == id);
        }


        public void Cadastrar(TipoEvento novoTipoEvento)
        {
            ctx.TipoEvento.Add(novoTipoEvento);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            
            ctx.TipoEvento.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<TipoEvento> ListarEventos()
        {
            return ctx.TipoEvento.ToList();

        }
    }
}
