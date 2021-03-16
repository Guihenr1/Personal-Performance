using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PP.Core.Data;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Data.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly UsuarioContext _context;

        public AlunoRepository(UsuarioContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Models.Aluno aluno)
        {
            _context.Alunos.Add(aluno);
        }

        public void Atualizar(Models.Aluno aluno)
        {
            _context.Entry(aluno.Id).CurrentValues.SetValues(aluno);
        }

        public async Task<IEnumerable<Models.Aluno>> ObterTodos()
        {
            return await _context.Alunos.AsNoTracking().ToListAsync();
        }

        public Task<Models.Aluno> ObterPorEmail(string email)
        {
            return _context.Alunos.FirstOrDefaultAsync(a => a.Email.Endereco == email);
        }

        public Task<Models.Aluno> ObterPorId(Guid id) {
            return _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}