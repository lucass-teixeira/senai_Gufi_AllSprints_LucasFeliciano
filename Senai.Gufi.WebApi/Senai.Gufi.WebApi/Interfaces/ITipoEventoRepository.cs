using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface ITipoEventoRepository
    {
        void Atualizar(int id, TipoEvento tipoEventoAtualizado);

        TipoEvento BuscarPorId(int id);

        void Cadastrar(TipoEvento novoTipoEvento);

        List<TipoEvento> ListarEventos();

        void Deletar(int id);




    }
}
