using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PP.Core.Data;

namespace PP.Usuario.API.Models
{
    public interface IAnamnesePerguntaRepository : IRepository<AnamnesePergunta> {
        void Adicionar(AnamnesePergunta anamnesePergunta);
        void Atualizar(AnamnesePergunta anamnesePergunta);
        Task<IEnumerable<AnamnesePergunta>> ObterTodos();
        Task<AnamnesePergunta> ObterPorId(Guid id);
    }
}