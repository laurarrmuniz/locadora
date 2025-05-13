using CRUD_aplication.Models;
using CRUD_aplication.Repository.Interface;
using CRUD_aplication.Service.Interface;

namespace CRUD_aplication.Service.Implementation
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;
        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<bool> AdicionaAsync(FilmesRequest request)
        {
            return await _filmeRepository.AdicionaAsync(request);
        }

        public async Task<List<FilmesResponse>> BuscaFilmesAsync()
        {
            return await _filmeRepository.BuscaFilmesAsync();
        }
        public async Task<bool> AtualizaAsync(FilmesRequest request, int id)
        {
            return await _filmeRepository.AtualizarAsync(request, id);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _filmeRepository.DeletarAsync(id);
        }

    }
}
