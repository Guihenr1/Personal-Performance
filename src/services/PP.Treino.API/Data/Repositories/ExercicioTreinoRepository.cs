using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using Microsoft.EntityFrameworkCore;
using PP.Treino.API.Models;

namespace PP.Treino.API.Data.Repositories
{
    public interface IExercicioTreinoRepository {
        Task<ExercicioTreino> ObterPorId(Guid exercicioTreinoId, Guid alunoId);
        Task AdicionarExercicioTreino(List<ExercicioTreino> exercicios);
        Task AtualizarExercicioTreino(List<ExercicioTreino> exercicios);
    }

    public class ExercicioTreinoRepository : IExercicioTreinoRepository {
        private readonly TreinoContext _context;

        public ExercicioTreinoRepository(TreinoContext context) {
            _context = context;
        }

        DbConnection ObterConexao() => _context.Database.GetDbConnection();

        public async Task<ExercicioTreino> ObterPorId(Guid exercicioTreinoId, Guid alunoId)
        {
            const string sql = @"SELECT et.Id, et.ExercicioId, et.TreinoId, et.RepeticaoId 
                                FROM ExercicioTreino et JOIN Treino t
                                ON et.TreinoId = t.Id
                                WHERE t.AlunoId = @alunoId
                                AND et.Id = @exercicioTreinoId";

            return await ObterConexao().QueryFirstOrDefaultAsync<ExercicioTreino>(sql, new { exercicioTreinoId, alunoId });
        }

        public async Task AdicionarExercicioTreino(List<ExercicioTreino> exercicios)
        {
            const string sql = @"INSERT INTO ExercicioTreino(Id, ExercicioId, TreinoId, RepeticaoId) 
                                                        VALUES (@Id, @ExercicioId, @TreinoId, @RepeticaoId)";

            foreach (var exercicio in exercicios) {
                await ExecuteAsync(sql, exercicio);
            }
        }

        public async Task AtualizarExercicioTreino(List<ExercicioTreino> exercicios) {
            const string sql = @"UPDATE ExercicioTreino SET ExercicioId = @ExercicioId, RepeticaoId = @RepeticaoId WHERE Id = @Id";

            foreach (var exercicio in exercicios) {
                await ExecuteAsync(sql, exercicio);
            }
        }


        private async Task ExecuteAsync(string sql, object parameters) {
            var linhasAfetadas = await ObterConexao().ExecuteAsync(sql, parameters);

            if (linhasAfetadas == 0)
                throw new Exception("Erro interno. Consulte o administrador");
        }
    }
}