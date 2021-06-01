using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PP.Core.Data;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Data.Repository
{
    public class FichaRepository : IFichaRepository
    {
        private readonly UsuarioContext _context;

        public FichaRepository(UsuarioContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Ficha ficha)
        {
            _context.Fichas.Add(ficha);
        }

        public void Atualizar(Ficha ficha)
        {
            _context.Entry(ficha.Id).CurrentValues.SetValues(ficha);
        }

        public async Task<IEnumerable<Ficha>> ObterTodos()
        {
            return await _context.Fichas.AsNoTracking().ToListAsync();
        }

        public Task<Ficha> ObterPorId(Guid id) {
            return _context.Fichas.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}