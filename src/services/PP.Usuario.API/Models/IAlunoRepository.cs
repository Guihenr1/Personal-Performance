using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PP.Core.Data;

namespace PP.Usuario.API.Models
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        void Adicionar(Aluno aluno);
        void Atualizar(Aluno aluno);
        Task<IEnumerable<Aluno>> ObterTodos();
        Task<Aluno> ObterPorEmail(string email);
        Task<Aluno> ObterPorId(Guid id);
    }
}