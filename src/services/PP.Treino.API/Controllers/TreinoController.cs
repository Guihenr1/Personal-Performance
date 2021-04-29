using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PP.Core.Controllers;
using PP.Core.User;
using PP.Treino.API.Data;
using PP.Treino.API.Models;
using PP.Treino.API.ViewModels;

namespace PP.Treino.API.Controllers
{
    [Authorize]
    [Route("treino")]
    public class TreinoController : MainController
    {
        private readonly IAspNetUser _user;
        private readonly TreinoContext _context;

        public TreinoController(IAspNetUser user, TreinoContext context)
        {
            _user = user;
            _context = context;
        }

        [HttpGet]
        public async Task<Models.Treino> ObterTreino()
        {
            return await _context.Treino.Include(x => x.ExercicioTreino)
                       .FirstOrDefaultAsync(x => x.AlunoId == _user.ObterUserId())
                ?? new Models.Treino();
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarTreino(TreinoViewModel treino)
        {
            if (!treino.EhValido()) return CustomResponse();

            var treinoId = Guid.NewGuid();
            _context.Treino.Add(new Models.Treino(treinoId, _user.ObterUserId(),
                treino.ExercicioTreino.Select(x =>
                    new ExercicioTreino(x.ExercicioId, treinoId, x.RepeticaoId)).ToList()));

            await PersistirDados();
            return CustomResponse();
        }

        [HttpPut("{treinoId}")]
        public async Task<IActionResult> AtualizarTreino(Guid treinoId, Models.Treino treino) {
            // if (!treino.EhValido()) return CustomResponse();

            treino.Id = treinoId;
            _context.Treino.Update(treino);

            await PersistirDados();
            return CustomResponse();
        }

        private async Task PersistirDados() {
            var result = await _context.SaveChangesAsync();
            if (result <= 0) AdicionarErroProcessamento("Não foi possível persistir os dados no banco");
        }
    }
}