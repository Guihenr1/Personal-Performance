using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PP.Core.Data;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Data.Repository
{
    public class AnamneseRespostaRepository : IAnamneseRespostaRepository
    {
        private readonly UsuarioContext _context;

        public AnamneseRespostaRepository(UsuarioContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(AnamneseResposta anamneseResposta)
        {
            _context.AnamneseRespostas.Add(anamneseResposta);
        }

        public void Atualizar(AnamneseResposta anamneseResposta)
        {
            _context.Entry(anamneseResposta.Id).CurrentValues.SetValues(anamneseResposta);
        }

        public async Task<IEnumerable<AnamneseResposta>> ObterTodos()
        {
            return await _context.AnamneseRespostas.AsNoTracking().ToListAsync();
        }

        public Task<AnamneseResposta> ObterPorId(Guid id) {
            return _context.AnamneseRespostas.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}