using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            _context.Entry(aluno).Property(x => x.Nome).IsModified = true;
            _context.Entry(aluno).Property(x => x.DataNascimento).IsModified = true;
            _context.Entry(aluno).Property(x => x.ProfessorId).IsModified = true;
            _context.Entry(aluno.Endereco).Property(x => x.Cep).IsModified = true;
            _context.Entry(aluno.Endereco).Property(x => x.Logradouro).IsModified = true;
            _context.Entry(aluno.Endereco).Property(x => x.Numero).IsModified = true;
            _context.Entry(aluno.Endereco).Property(x => x.Bairro).IsModified = true;
            _context.Entry(aluno.Endereco).Property(x => x.Cidade).IsModified = true;
            _context.Entry(aluno.Endereco).Property(x => x.Complemento).IsModified = true;
            _context.Entry(aluno.Endereco).Property(x => x.EstadoId).IsModified = true;
        }

        public void SituacaoAluno(Models.Aluno aluno) {
            _context.Entry(aluno).Property(x => x.DataExcluido).IsModified = true;
            _context.Entry(aluno).Property(x => x.Excluido).IsModified = true;
        }

        public async Task<IEnumerable<Models.Aluno>> ObterTodos()
        {
            return await _context.Alunos.Include(x => x.Endereco).AsNoTracking().ToListAsync();
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