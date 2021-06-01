using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PP.Core.Enums;
using PP.Permissao.API.Data;

namespace PP.Permissao.API.Controllers {
    [Authorize]
    [Route("permissao")]
    public class PermissaoController {
        private readonly PermissaoContext _context;

        public PermissaoController(PermissaoContext context) {
            _context = context;
        }

        [HttpGet("/tipo/{tipoUsuario}")]
        public async Task<IEnumerable<Models.Permissao>> ObterPermissoes(TipoUsuario tipoUsuario)
        {
            return await _context.Permissao.Include(x => x.Tipo)
                .Where(x => x.TipoUsuario == tipoUsuario).ToListAsync();;
        }
    }
}