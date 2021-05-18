using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using Microsoft.EntityFrameworkCore;
using PP.Treino.API.DTO;
using PP.Treino.API.Models;

namespace PP.Treino.API.Data.Repositories
{
    public interface ITreinoRepository {
        Task<PagedResult<TreinoDTO>> ObterTreinosAluno(Guid alunoId, int pageSize, int pageIndex);
        Task<PagedResult<TreinoDTO>> ObterTreinosAlunosProfessor(Guid professorId, int pageSize, int pageIndex);
        Task<TreinoDTO> ObterTreinoPorId(Guid treinoId);
        Task AdicionarTreino(Models.Treino treino);
        Task AtualizarTreino(Models.Treino treino);
    }

    public class TreinoRepository : ITreinoRepository {
        private readonly TreinoContext _context;
        private readonly IExercicioTreinoRepository _exercicioTreinoRepository;

        public TreinoRepository(TreinoContext context, IExercicioTreinoRepository exercicioTreinoRepository)
        {
            _context = context;
            _exercicioTreinoRepository = exercicioTreinoRepository;
        }

        DbConnection ObterConexao() => _context.Database.GetDbConnection();
        public async Task<PagedResult<TreinoDTO>> ObterTreinosAluno(Guid alunoId, int pageSize, int pageIndex)
        {
            var sql = @$"SELECT t.Id, t.AlunoId, t.DataCadastro, t.Nome 
                                FROM Treino t 
                                JOIN Aluno a ON a.Id = t.AlunoId 
                                WHERE t.AlunoId = @alunoId 
                                ORDER BY t.DataCadastro DESC
                                OFFSET {pageSize * (pageIndex - 1)} ROWS 
                                FETCH NEXT {pageSize} ROWS ONLY 
                                SELECT COUNT(Id) FROM Treino";

            var multi = await ObterConexao()
                .QueryMultipleAsync(sql, new { alunoId });

            var treinos = multi.Read<TreinoDTO>();
            var total = multi.Read<int>().FirstOrDefault();

            return new PagedResult<TreinoDTO>() {
                List = treinos,
                TotalResults = total,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }

        public async Task<PagedResult<TreinoDTO>> ObterTreinosAlunosProfessor(Guid professorId, int pageSize, int pageIndex) {
            var sql = @$"SELECT t.Id, t.AlunoId, t.DataCadastro, t.Nome 
                                FROM Treino t 
                                JOIN Aluno a ON a.Id = t.AlunoId
                                WHERE a.ProfessorId = @professorId 
                                ORDER BY t.DataCadastro DESC
                                OFFSET {pageSize * (pageIndex - 1)} ROWS 
                                FETCH NEXT {pageSize} ROWS ONLY 
                                SELECT COUNT(Id) FROM Treino";

            var multi = await ObterConexao()
                .QueryMultipleAsync(sql, new { professorId });

            var treinos = multi.Read<TreinoDTO>();
            var total = multi.Read<int>().FirstOrDefault();

            return new PagedResult<TreinoDTO>() {
                List = treinos,
                TotalResults = total,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }

        public async Task<TreinoDTO> ObterTreinoPorId(Guid treinoId) {
            const string sql = @"SELECT t.Id TreinoId, t.AlunoId, t.DataCadastro, t.Nome,  
                                et.Id ExercicioTreinoId, et.ExercicioId, et.TreinoId ExercicioTreino_TreinoId, et.RepeticaoId FROM Treino t 
                                JOIN ExercicioTreino et ON t.Id = et.TreinoId
                                JOIN Aluno a ON a.Id = t.AlunoId
                                WHERE t.Id = @treinoId 
                                ORDER BY t.DataCadastro DESC";

            var treino = await ObterConexao().QueryAsync<dynamic>(sql, new { treinoId });

            return MapearTreino(treino);
        }

        public async Task AdicionarTreino(Models.Treino treino) {
            const string sql = @"INSERT INTO Treino (Id, AlunoId, DataCadastro, Nome) VALUES (@Id, @AlunoId, @DataCadastro, @Nome)";

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
                await ExecuteAsync(sql, treino);
                await _exercicioTreinoRepository.AdicionarExercicioTreino(treino.ExercicioTreino);

                scope.Complete();
            }
        }

        public async Task AtualizarTreino(Models.Treino treino) {
            const string sql = @"UPDATE Treino SET Nome = @Nome WHERE Id = @Id";
            
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
                await ExecuteAsync(sql, treino);
                await _exercicioTreinoRepository.AtualizarExercicioTreino(treino.ExercicioTreino);

                scope.Complete();
            }
        }


        private async Task ExecuteAsync(string sql, object parameters)
        {
            var linhasAfetadas = await ObterConexao().ExecuteAsync(sql, parameters);

            if (linhasAfetadas == 0)
                throw new Exception("Erro interno. Consulte o administrador");
        }

        private TreinoDTO MapearTreino(IEnumerable<dynamic> result)
        {
            return result.Select(x => new TreinoDTO
            {
                Id = x.TreinoId,
                AlunoId = x.AlunoId,
                DataCadastro = x.DataCadastro,
                Nome = x.Nome,
                ExercicioTreino = result.Where(y => y.ExercicioTreino_TreinoId == x.TreinoId)
                    .Select(z => new ExercicioTreinoDTO {
                        Id = z.ExercicioTreinoId,
                        TreinoId = z.ExercicioTreino_TreinoId,
                        ExercicioId = z.ExercicioId,
                        RepeticaoId = z.RepeticaoId
                    }).ToList()
            }).FirstOrDefault();
        }
    }
}