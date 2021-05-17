using System;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using PP.Treino.API.Models;

namespace PP.Treino.API.Data.Repositories
{
    public interface IExercicioTreinoRepository {
        Task<ExercicioTreino> ObterPorId(Guid exercicioTreinoId, Guid alunoId);
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
    }
}