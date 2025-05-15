using CRUD_aplication.Models;
using CRUD_aplication.Repository.Interface;
using CRUD_aplication.Util;
using MySql.Data.MySqlClient;
using Dapper;

namespace CRUD_aplication.Repository.Implementation
{
    public class ElencoRepository : IElencoRepository
    {
        private readonly string _connectionString = Utils.GetEnvironmentVariable("SQL_CONNECTION");
        public async Task<List<ElencoResponse>> BuscaElencoAsync()
        {
            string sql = @" SELECT  id Id,
                                nome Nome,
                                data_nascimento DataNascimento
                        FROM tb_elenco
                        ORDER BY Nome ASC ";
            using var con = new MySqlConnection(_connectionString);
            var result = await con.QueryAsync<ElencoResponse>(sql);
            return result.ToList();
        }

        public async Task<ElencoResponse?> BuscaElencoAsync(int id)
        {
            string sql = @" SELECT  id Id,
                                nome Nome,
                                data_nascimento DataNascimento
                        FROM tb_elenco
                        WHERE id=@id; ";
            using var con = new MySqlConnection(_connectionString);
            return await con.QueryFirstOrDefaultAsync<ElencoResponse>(sql, new { id });
        }
        public async Task<bool> AdicionaElencoAsync(ElencoRequest request)
        {
            string sql = @" INSERT INTO tb_elenco
                    (nome, data_nascimento)
                    VALUES(@Nome, @DataNascimento); ";
            using var con = new MySqlConnection(_connectionString);
            await con.ExecuteAsync(sql, request);
            return true;
        }
        public async Task<bool> AtualizarElencoAsync(ElencoRequest request, int id)
        {
            string sql = @"UPDATE tb_elenco
                   SET nome = @Nome
                   WHERE id = @Id;";
            using var con = new MySqlConnection(_connectionString);
            var parametros = new
            {
                request.Nome,
                Id = id
            };
            int linhasAfetadas = await con.ExecuteAsync(sql, parametros);
            return linhasAfetadas > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            string sql = @" DELETE FROM tb_elenco
                        WHERE id=@id; ";
            using var con = new MySqlConnection(_connectionString);
            int linhasAfetadas = await con.ExecuteAsync(sql, new { id });
            return linhasAfetadas > 0;
        }

    }
}
