using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PP.Core.Data;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Data.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly UsuarioContext _context;

        public ProfessorRepository(UsuarioContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Professor professor)
        {
            _context.Professores.Add(professor);
        }

        public void SituacaoProfessor(Professor professor) {
            _context.Entry(professor).Property(x => x.DataExcluido).IsModified = true;
            _context.Entry(professor).Property(x => x.Excluido).IsModified = true;
        }

        public async Task<PagedResult<Professor>> ObterTodos(int pageSize, int pageIndex) {
            var professores = await _context.Professores.AsNoTracking()
                .Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToListAsync();

            return new PagedResult<Professor> {
                List = professores,
                TotalResults = await _context.Professores.CountAsync(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }

        public Task<Professor> ObterPorEmail(string email)
        {
            return _context.Professores.FirstOrDefaultAsync(a => a.Email.Endereco == email);
        }

        public Task<Professor> ObterPorCREF(int cref) 
        {
            return _context.Professores.FirstOrDefaultAsync(a => a.CREF == cref);
        }

        public Task<Professor> ObterPorId(Guid id) {
            return _context.Professores.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Atualizar(Professor professor) {
            _context.Entry(professor).Property(x => x.Nome).IsModified = true;
            _context.Entry(professor).Property(x => x.CREF).IsModified = true;
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}