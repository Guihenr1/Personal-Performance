using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PP.Core.Controllers;
using PP.Core.DomainObjects;
using PP.Core.Enums;
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
        public async Task<List<Models.Treino>> ObterTreinos() {
            return await _context.Treino.Include(x => x.ExercicioTreino)
                       .Where(x => x.AlunoId == _user.ObterUserId()).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Models.Treino> ObterTreinoPoId(Guid id) {
            return await _context.Treino.Include(x => x.ExercicioTreino)
                .FirstOrDefaultAsync(x => x.AlunoId == _user.ObterUserId() && x.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarTreino(TreinoViewModel treino)
        {
            EhProfessor();

            if (!treino.EhValido()) return CustomResponse();

            var treinoId = Guid.NewGuid();
            _context.Treino.Add(new Models.Treino(treinoId, treino.AlunoId,
                treino.ExercicioTreino.Select(x =>
                    new ExercicioTreino(x.ExercicioId, treinoId, x.RepeticaoId)).ToList()));

            await PersistirDados();
            return CustomResponse();
        }

        [HttpPut("{treinoId}")]
        public async Task<IActionResult> AtualizarTreino(Guid treinoId, Models.Treino treino) {
            EhProfessor();

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

        private void EhProfessor()
        {
            if (Equals(_user.ObterTipo(), TipoUsuario.Professor)) throw new DomainException("Somente professores podem cadastrar treinos");
        }
    }
}