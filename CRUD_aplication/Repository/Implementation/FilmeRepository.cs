using CRUD_aplication.Models;
using CRUD_aplication.Repository.Interface;
using CRUD_aplication.Util;
using Dapper;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;


namespace CRUD_aplication.Repository.Implementation;

public class FilmeRepository : IFilmeRepository
{
    private readonly string _connectionString = Utils.GetEnvironmentVariable("SQL_CONNECTION");

    public async Task<List<FilmesResponse>> BuscaFilmesAsync()
    {
        string sql = @" SELECT  id Id,
                                nome Nome,
                               ano Ano,
                               id_produtora ProdutoraId
                        FROM tb_filme
                        ORDER BY Nome ASC ";

        //Quando sair do using libera o recurso
        using var con = new MySqlConnection(_connectionString);
        var result =  await con.QueryAsync<FilmesResponse>(sql);
        return result.ToList();
    }
    //Por padrão
    public async Task<FilmesResponse?> BuscaFilmeAsync(int id)
    {
        string sql = @" SELECT  id Id,
                                nome Nome,
                               ano Ano,
                               id_produtora ProdutoraId
                        FROM tb_filme
                        WHERE id = @id";

        //Quando sair do using libera o recurso
        using var con = new MySqlConnection(_connectionString);
        return await con.QueryFirstOrDefaultAsync<FilmesResponse>(sql, new {id});     
    }

    public async Task<bool> AdicionaAsync(FilmesRequest request)
    {
        string sql = @" INSERT INTO tb_filme
                    (nome, ano, id_produtora)
                    VALUES(@Nome, @Ano, @ProdutoraId); ";

        using var con = new MySqlConnection(_connectionString);
        await con.ExecuteAsync(sql, request);
        return true;
    }

    public async Task<bool> AtualizarAsync(FilmesRequest request, int id)
    {
        string sql = @"UPDATE tb_filme
                   SET nome = @Nome, ano = @Ano, id_produtora = @ProdutoraId
                   WHERE id = @Id;";

        using var con = new MySqlConnection(_connectionString);
        var parametros = new
        {
            request.Nome,
            request.Ano,
            request.ProdutoraId,
            Id = id
        };
        int linhasAfetadas = await con.ExecuteAsync(sql, parametros);
        return linhasAfetadas > 0;
    }


    public async Task<bool> DeletarAsync(int id)
    {
        string sql = @" DELETE FROM tb_filme
                        WHERE id=@id; ";

        using var con = new MySqlConnection(_connectionString);
        await con.ExecuteAsync(sql, new {id});
        return true;
    }
}

