using CRUD_aplication.Models;
using CRUD_aplication.Repository.Implementation;
using CRUD_aplication.Repository.Interface;
using CRUD_aplication.Service.Interface;

namespace CRUD_aplication.Service.Implementation
{
    public class CategoriaService: ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public Task<bool> AdicionaCategoriaAsync(CategoriaRequest request)
        {
            return _categoriaRepository.AdicionaCategoriaAsync(request);
        }
        public Task<bool> AtualizarCategoriaAsync(CategoriaRequest request, int id)
        {
            return _categoriaRepository.AtualizarCategoriaAsync(request, id);
        }
        public Task<CategoriaResponse?> BuscaCategoriaAsync(int id)
        {
            return _categoriaRepository.BuscaCategoriaAsync(id);
        }
        public Task<List<CategoriaResponse>> BuscaCategoriaAsync()
        {
            return _categoriaRepository.BuscaCategoriaAsync();
        }
        public Task<bool> DeletarCategoriaAsync(int id)
        {
            return _categoriaRepository.DeletarCategoriaAsync(id);
        }
    }
}
