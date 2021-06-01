using System;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using PP.Treino.API.Models;

namespace PP.Treino.API.Data.Repositories
{
    public interface IExercicioCargaRepository {
        DbConnection ObterConexao();
        Task Adicionar(ExercicioCarga exercicioCarga);
        Task AtualizarCarga(ExercicioCarga exercicioCarga, Guid id);
    }

    public class ExercicioCargaRepository : IExercicioCargaRepository {
        private readonly TreinoContext _context;

        public ExercicioCargaRepository(TreinoContext context) {
            _context = context;
        }

        public DbConnection ObterConexao() => _context.Database.GetDbConnection();

        public async Task Adicionar(ExercicioCarga exercicioCarga)
        {
            const string sql = @"INSERT INTO ExercicioCarga (Id, Carga, DataCadastro, ExercicioTreinoId) 
                                                VALUES (@Id, @Carga, @DataCadastro, @ExercicioTreinoId)";

            await ObterConexao().ExecuteAsync(sql, new { exercicioCarga.Id, exercicioCarga.Carga, exercicioCarga.DataCadastro, 
                ExercicioTreinoId = exercicioCarga.ExercicioTreino.Id });
        }

        public async Task AtualizarCarga(ExercicioCarga exercicioCarga, Guid id) {
            const string sql = @"UPDATE ExercicioCarga SET Carga = @Carga, ExercicioTreinoId = @ExercicioTreinoId WHERE Id = @id";

            await ObterConexao().ExecuteAsync(sql, new { exercicioCarga.Carga, ExercicioTreinoId = exercicioCarga.ExercicioTreino.Id, id });
        }
    }
}