using System;
using System.Threading.Tasks;
using PP.Core.Data;

namespace PP.Usuario.API.Models
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        void Adicionar(Professor professor);
        void SituacaoProfessor(Professor professor);
        Task<PagedResult<Professor>> ObterTodos(int pageSize, int pageIndex);
        void Atualizar(Professor professor);
        Task<Professor> ObterPorEmail(string email);
        Task<Professor> ObterPorCREF(int cref);
        Task<Professor> ObterPorId(Guid id);
    }
}