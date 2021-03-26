using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PP.Core.Data;

namespace PP.Usuario.API.Models
{
    public interface IFichaRepository : IRepository<Ficha>
    {
        void Adicionar(Ficha ficha);
        void Atualizar(Ficha ficha);
        void Remover(Ficha ficha);
        Task<IEnumerable<Ficha>> ObterTodos();
        Task<Ficha> ObterPorId(Guid id);
    }
}