using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IEventoRepository 
    {
        List<Evento> Listar();

        void Deletar(int id);

        void Cadastrar(Evento novoEvento);

        void Atualizar(int id, Evento eventoAtualizado);

         Evento BuscarPorId(int id);

    }
}
