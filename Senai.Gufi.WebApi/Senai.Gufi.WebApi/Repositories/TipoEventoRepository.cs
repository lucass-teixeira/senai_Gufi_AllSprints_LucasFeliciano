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
            TipoEvento tipoEventoBuscado = ctx.TipoEvento.Find(id);

            tipoEventoBuscado.Evento = tipoEventoAtualizado.Evento;
            tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;

            ctx.TipoEvento.Update(tipoEventoBuscado);

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
