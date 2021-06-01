using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PP.Core.Data;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Data.Repository
{
    public class BiometriaRepository : IBiometriaRepository
    {
        private readonly UsuarioContext _context;

        public BiometriaRepository(UsuarioContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Biometria biometria)
        {
            _context.Biometrias.Add(biometria);
        }

        public void Atualizar(Biometria biometria)
        {
            _context.Entry(biometria.Id).CurrentValues.SetValues(biometria);
        }

        public async Task<IEnumerable<Biometria>> ObterTodos()
        {
            return await _context.Biometrias.AsNoTracking().ToListAsync();
        }

        public Task<Biometria> ObterPorId(Guid id) {
            return _context.Biometrias.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}