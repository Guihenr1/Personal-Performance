using System;
using System.Threading.Tasks;
using PP.Core.Data;

namespace PP.Usuario.API.Models
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        void Adicionar(Aluno aluno);
        void Atualizar(Aluno aluno);
        void SituacaoAluno(Aluno aluno);
        Task<PagedResult<Aluno>> ObterTodos(int pageSize, int pageIndex);
        Task<Aluno> ObterPorEmail(string email);
        Task<Aluno> ObterPorId(Guid id);
    }
}