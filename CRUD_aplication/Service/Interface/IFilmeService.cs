using CRUD_aplication.Models;

namespace CRUD_aplication.Service.Interface
{
    public interface IFilmeService 
    {
        Task<List<FilmesResponse>> BuscaFilmesAsync();
        Task<bool> AdicionaAsync(FilmesRequest request);
        Task<bool> AtualizaAsync(FilmesRequest request, int id);
        Task<bool> DeleteAsync(int id);
    }
}
