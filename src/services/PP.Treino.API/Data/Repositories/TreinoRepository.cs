using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using Microsoft.EntityFrameworkCore;
using PP.Treino.API.DTO;

namespace PP.Treino.API.Data.Repositories
{
    public interface ITreinoRepository {
        DbConnection ObterConexao();
        Task<IEnumerable<TreinoDTO>> ObterTreinosAluno(Guid alunoId);
        Task<IEnumerable<TreinoDTO>> ObterTreinosAlunosProfessor(Guid professorId);
        Task<TreinoDTO> ObterTreinoPoId(Guid treinoId);
        Task AdicionarTreino(Models.Treino treino);
        Task AtualizarTreino(Models.Treino treino);
    }

    public class TreinoRepository : ITreinoRepository {
        private readonly TreinoContext _context;

        public TreinoRepository(TreinoContext context) {
            _context = context;
        }

        public DbConnection ObterConexao() => _context.Database.GetDbConnection();
        public async Task<IEnumerable<TreinoDTO>> ObterTreinosAluno(Guid alunoId)
        {
            const string sql = @"SELECT t.Id TreinoId, t.AlunoId, t.DataCadastro, 
                                et.Id ExercicioTreinoId, et.ExercicioId, et.TreinoId ExercicioTreino_TreinoId, et.RepeticaoId FROM Treino t 
                                JOIN ExercicioTreino et ON t.Id = et.TreinoId
                                WHERE t.AlunoId = @alunoId
                                ORDER BY t.DataCadastro DESC";

            var treinos = await ObterConexao().QueryAsync<dynamic>(sql, new { alunoId });

            return MapearTreino(treinos);
        }

        public async Task<IEnumerable<TreinoDTO>> ObterTreinosAlunosProfessor(Guid professorId) {
            const string sql = @"SELECT t.Id TreinoId, t.AlunoId, t.DataCadastro, 
                                et.Id ExercicioTreinoId, et.ExercicioId, et.TreinoId ExercicioTreino_TreinoId, et.RepeticaoId FROM Treino t 
                                JOIN ExercicioTreino et ON t.Id = et.TreinoId
                                JOIN Aluno a ON a.Id = t.AlunoId
                                WHERE a.ProfessorId = @professorId 
                                ORDER BY t.DataCadastro DESC";

            var treinos = await ObterConexao().QueryAsync<dynamic>(sql, new { professorId });

            return MapearTreino(treinos);
        }

        public async Task<TreinoDTO> ObterTreinoPoId(Guid treinoId) {
            const string sql = @"SELECT t.Id TreinoId, t.AlunoId, t.DataCadastro, 
                                et.Id ExercicioTreinoId, et.ExercicioId, et.TreinoId ExercicioTreino_TreinoId, et.RepeticaoId FROM Treino t 
                                JOIN ExercicioTreino et ON t.Id = et.TreinoId
                                JOIN Aluno a ON a.Id = t.AlunoId
                                WHERE t.Id = @treinoId 
                                ORDER BY t.DataCadastro DESC";

            var treino = await ObterConexao().QueryAsync<dynamic>(sql, new { treinoId });

            return MapearTreino(treino).FirstOrDefault();
        }

        public async Task AdicionarTreino(Models.Treino treino) {
            const string sqlInsertAluno = @"INSERT INTO Treino (Id, AlunoId, DataCadastro) VALUES (@Id, @AlunoId, @DataCadastro)";
            const string sqlInsertExercicioTreino = @"INSERT INTO ExercicioTreino(Id, ExercicioId, TreinoId, RepeticaoId) 
                                                        VALUES (@Id, @ExercicioId, @TreinoId, @RepeticaoId)";

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
                await ObterConexao().ExecuteAsync(sqlInsertAluno, treino);

                foreach (var exercicio in treino.ExercicioTreino) {
                    await ObterConexao().ExecuteAsync(sqlInsertExercicioTreino, exercicio);
                }

                scope.Complete();
            }
        }

        public async Task AtualizarTreino(Models.Treino treino) {
            const string sql = @"UPDATE ExercicioTreino SET ExercicioId = @ExercicioId, RepeticaoId = @RepeticaoId WHERE Id = @Id";
            
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
                foreach (var exercicio in treino.ExercicioTreino) {
                    await ObterConexao().ExecuteAsync(sql, exercicio);
                }

                scope.Complete();
            }
        }


        private IEnumerable<TreinoDTO> MapearTreino(IEnumerable<dynamic> result)
        {
            return result.Select(x => new
            {
                x.TreinoId,
                x.AlunoId,
                x.DataCadastro
            }).Distinct().Select(x => 
                new TreinoDTO{ Id = x.TreinoId, AlunoId = x.AlunoId, DataCadastro = x.DataCadastro, 
                    ExercicioTreino = result.Where(y => y.ExercicioTreino_TreinoId == x.TreinoId)
                            .Select(z => new ExercicioTreinoDTO {
                                Id = z.ExercicioTreinoId,
                                TreinoId = z.ExercicioTreino_TreinoId,
                                ExercicioId = z.ExercicioId,
                                RepeticaoId = z.RepeticaoId
                            }).ToList()
                });
        }
    }
}