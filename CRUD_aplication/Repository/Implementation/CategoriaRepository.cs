using CRUD_aplication.Models;
using CRUD_aplication.Repository.Interface;
using CRUD_aplication.Util;
using MySql.Data.MySqlClient;
using Dapper;

namespace CRUD_aplication.Repository.Implementation
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string _connectionString = Utils.GetEnvironmentVariable("SQL_CONNECTION");
        public async Task<List<CategoriaResponse>> BuscaCategoriaAsync()
        {
            string sql = @" SELECT  id Id,
                                nome Nome
                        FROM tb_categoria
                        ORDER BY Nome ASC ";
            //Quando sair do using libera o recurso
            using var con = new MySqlConnection(_connectionString);
            var result = await con.QueryAsync<CategoriaResponse>(sql);
            return result.ToList();
        }
        public async Task<CategoriaResponse?> BuscaCategoriaAsync(int id)
        {
            string sql = @" SELECT  id Id,
                                nome Nome
                        FROM tb_categoria
                        WHERE id=@id; ";
            //Quando sair do using libera o recurso
            using var con = new MySqlConnection(_connectionString);
            return await con.QueryFirstOrDefaultAsync<CategoriaResponse>(sql, new { id });
        }
        public async Task<bool> AdicionaCategoriaAsync(CategoriaRequest request)
        {
            string sql = @" INSERT INTO tb_categoria
                    (nome)
                    VALUES(@Nome); ";
            using var con = new MySqlConnection(_connectionString);
            await con.ExecuteAsync(sql, request);
            return true;
        }
        public async Task<bool> AtualizarCategoriaAsync(CategoriaRequest request, int id)
        {
            string sql = @"UPDATE tb_categoria
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
        public async Task<bool> DeletarCategoriaAsync(int id)
        {
            string sql = @" DELETE FROM tb_categoria
                        WHERE id=@id; ";
            using var con = new MySqlConnection(_connectionString);
            await con.ExecuteAsync(sql, new { id });
            return true;
        }
    }
}