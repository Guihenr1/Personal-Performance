using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PP.Core.Controllers;
using PP.Core.DomainObjects;
using PP.Core.Enums;
using PP.Core.User;
using PP.Treino.API.Data.Repositories;
using PP.Treino.API.DTO;
using PP.Treino.API.Models;
using PP.Treino.API.ViewModels;

namespace PP.Treino.API.Controllers
{
    [Authorize]
    [Route("treino")]
    public class TreinoController : MainController
    {
        private readonly IAspNetUser _user;
        private readonly ITreinoRepository _repository;

        public TreinoController(IAspNetUser user, ITreinoRepository repository)
        {
            _user = user;
            _repository = repository;
        }

        [HttpGet("treinos-professor")]
        public async Task<PagedResult<TreinoDTO>> ObterTreinosAlunosProfessor([FromQuery] int ps = 8, [FromQuery] int page = 1) {
            EhProfessor();

            return await _repository.ObterTreinosAlunosProfessor(_user.ObterUserId(), ps, page);
        }

        [HttpGet("treinos-aluno")]
        public async Task<PagedResult<TreinoDTO>> ObterTreinosAluno([FromQuery] int ps = 8, [FromQuery] int page = 1)
        {
            return await _repository.ObterTreinosAluno(_user.ObterUserId(), ps, page);
        }

        [HttpGet("treino-id/{id}")]
        public async Task<TreinoDTO> ObterTreinoPoId(Guid id)
        {
            return await _repository.ObterTreinoPorId(id);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarTreino(TreinoViewModel treino)
        {
            EhProfessor();

            if (!treino.EhValido()) return CustomResponse();

            var treinoId = Guid.NewGuid();

            await _repository.AdicionarTreino(new Models.Treino(treinoId, treino.AlunoId, treino.Nome,
                treino.ExercicioTreino.Select(x =>
                    new ExercicioTreino(Guid.NewGuid(), x.ExercicioId, treinoId, x.RepeticaoId)).ToList()));

            return CustomResponse();
        }

        [HttpPut("{treinoId}")]
        public async Task<IActionResult> AtualizarTreino(TreinoViewModel treino, Guid treinoId) {
            EhProfessor();

            if (!treino.EhValido()) return CustomResponse();

            await _repository.AtualizarTreino(new Models.Treino(treinoId, treino.AlunoId, treino.Nome, 
                treino.ExercicioTreino.Select(x =>
                    new ExercicioTreino(x.Id, x.ExercicioId, treinoId, x.RepeticaoId)).ToList()));

            return CustomResponse();
        }

        private void EhProfessor()
        {
            if (!Equals(Enum.Parse<TipoUsuario>(_user.ObterTipo()), TipoUsuario.Professor)) 
                throw new DomainException("Acesso permitido somente a professores");
        }
    }
}