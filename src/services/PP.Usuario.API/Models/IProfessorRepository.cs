using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PP.Core.Data;

namespace PP.Usuario.API.Models
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        void Adicionar(Professor professor);
        void SituacaoProfessor(Professor professor);
        Task<IEnumerable<Professor>> ObterTodos();
        Task<Professor> ObterPorEmail(string email);
        Task<Professor> ObterPorCREF(int cref);
        Task<Professor> ObterPorId(Guid id);
    }
}