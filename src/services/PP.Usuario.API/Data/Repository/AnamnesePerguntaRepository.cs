using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PP.Core.Data;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Data.Repository
{
    public class AnamnesePerguntaRepository : IAnamnesePerguntaRepository
    {
        private readonly UsuarioContext _context;

        public AnamnesePerguntaRepository(UsuarioContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(AnamnesePergunta anamnesePergunta)
        {
            _context.AnamnesePerguntas.Add(anamnesePergunta);
        }

        public void Atualizar(AnamnesePergunta anamnesePergunta)
        {
            _context.Entry(anamnesePergunta.Id).CurrentValues.SetValues(anamnesePergunta);
        }

        public async Task<IEnumerable<AnamnesePergunta>> ObterTodos()
        {
            return await _context.AnamnesePerguntas.AsNoTracking().ToListAsync();
        }

        public Task<AnamnesePergunta> ObterPorId(Guid id) {
            return _context.AnamnesePerguntas.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}