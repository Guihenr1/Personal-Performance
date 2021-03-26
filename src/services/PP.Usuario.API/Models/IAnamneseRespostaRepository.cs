using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PP.Core.Data;

namespace PP.Usuario.API.Models
{
    public interface IAnamneseRespostaRepository : IRepository<AnamneseResposta> {
        void Adicionar(AnamneseResposta anamneseResposta);
        void Atualizar(AnamneseResposta anamneseResposta);
        Task<IEnumerable<AnamneseResposta>> ObterTodos();
        Task<AnamneseResposta> ObterPorId(Guid id);
    }
}