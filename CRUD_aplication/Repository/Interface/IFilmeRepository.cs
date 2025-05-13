using CRUD_aplication.Models;

namespace CRUD_aplication.Repository.Interface;

    public interface IFilmeRepository
    {
        Task<List<FilmesResponse>> BuscaFilmesAsync();
        Task<FilmesResponse?> BuscaFilmeAsync(int id);
        Task<bool> AdicionaAsync(FilmesRequest request);
        Task<bool> AtualizarAsync(FilmesRequest request, int id);
        Task<bool> DeletarAsync(int id);
    }

