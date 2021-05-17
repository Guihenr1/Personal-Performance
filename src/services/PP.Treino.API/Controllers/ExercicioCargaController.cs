using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PP.Core.Controllers;
using PP.Core.User;
using PP.Treino.API.Data.Repositories;
using PP.Treino.API.Models;
using PP.Treino.API.ViewModels;

namespace PP.Treino.API.Controllers {
    [Authorize]
    [Route("ExercicioCarga")]
    public class ExercicioCargaController : MainController {
        private readonly IAspNetUser _user;
        private readonly IExercicioCargaRepository _exercicioCargaRepository;
        private readonly IExercicioTreinoRepository _exercicioTreinoRepository;

        public ExercicioCargaController(IExercicioCargaRepository exercicioCargaRepository, IExercicioTreinoRepository exercicioTreinoRepository, IAspNetUser user)
        {
            _exercicioCargaRepository = exercicioCargaRepository;
            _exercicioTreinoRepository = exercicioTreinoRepository;
            _user = user;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(ExercicioCargaViewModel exercicioCarga) {
            var carga = new ExercicioCarga(exercicioCarga.Carga);
            var exercicioTreino = await _exercicioTreinoRepository.ObterPorId(exercicioCarga.ExercioTreinoId, _user.ObterUserId());

            if (exercicioTreino is null)
            {
                AdicionarErroProcessamento("Exercício não encontrado");
                return CustomResponse();
            }

            carga.AssociarExercicioTreino(exercicioTreino);

            await _exercicioCargaRepository.Adicionar(carga);

            return CustomResponse();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCarga(Guid id, ExercicioCargaViewModel exercicioCarga) {
            var carga = new ExercicioCarga(exercicioCarga.Carga);
            var exercicioTreino = await _exercicioTreinoRepository.ObterPorId(exercicioCarga.ExercioTreinoId, _user.ObterUserId());

            if (exercicioTreino is null) {
                AdicionarErroProcessamento("Exercício não encontrado");
                return CustomResponse();
            }

            carga.AssociarExercicioTreino(exercicioTreino);

            await _exercicioCargaRepository.AtualizarCarga(carga, id);

            return CustomResponse();
        }
    }
}