using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PP.Core.Enums;
using PP.Core.User;
using PP.Permissao.API.Data;

namespace PP.Permissao.API.Controllers {
    [Authorize]
    [Route("permissao")]
    public class PermissaoController {
        private readonly IAspNetUser _user;
        private readonly PermissaoContext _context;

        public PermissaoController(IAspNetUser user, PermissaoContext context) {
            _user = user;
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