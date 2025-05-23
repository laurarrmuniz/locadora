﻿using CRUD_aplication.Models;
using CRUD_aplication.Repository.Interface;
using CRUD_aplication.Util;
using MySql.Data.MySqlClient;
using Dapper;

namespace CRUD_aplication.Repository.Implementation
{
    public class ProdutoraRepository : IProdutoraRepository
    {
        private readonly string _connectionString = Utils.GetEnvironmentVariable("SQL_CONNECTION");

        public async Task<List<ProdutoraResponse>> BuscaProdutoraAsync()
        {
            string sql = @" SELECT  id Id,
                                nome Nome
                        FROM tb_produtora
                        ORDER BY Nome ASC ";

            //Quando sair do using libera o recurso
            using var con = new MySqlConnection(_connectionString);
            var result = await con.QueryAsync<ProdutoraResponse>(sql);
            return result.ToList();
        }

        public async Task<ProdutoraResponse?> BuscaProdutoraAsync(int id)
        {
            string sql = @" SELECT  id Id,
                                nome Nome
                        FROM tb_produtora
                        ORDER BY Nome ASC";

            //Quando sair do using libera o recurso
            using var con = new MySqlConnection(_connectionString);
            return await con.QueryFirstOrDefaultAsync<ProdutoraResponse>(sql, new { id });
        }

        public async Task<bool> AdicionaProdutoraAsync(ProdutoraRequest request)
        {
            string sql = @" INSERT INTO tb_produtora
                    (nome)
                    VALUES(@Nome); ";

            using var con = new MySqlConnection(_connectionString);
            await con.ExecuteAsync(sql, request);
            return true;
        }

        public async Task<bool> AtualizarProdutoraAsync(ProdutoraRequest request, int id)
        {
            string sql = @"UPDATE tb_produtora
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

        public async Task<bool> DeletarProdutoraAsync(int id)
        {
            string sql = @" DELETE FROM tb_produtora
                        WHERE id=@id; ";

            using var con = new MySqlConnection(_connectionString);
            await con.ExecuteAsync(sql, new { id });
            return true;
        }
    }
}
