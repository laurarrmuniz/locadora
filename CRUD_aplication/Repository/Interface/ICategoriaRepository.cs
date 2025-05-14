using CRUD_aplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_aplication.Repository.Interface
{
    public interface ICategoriaRepository
    {
        Task<List<CategoriaResponse>> BuscaCategoriaAsync();
        Task<CategoriaResponse?> BuscaCategoriaAsync(int id);
        Task<bool> AdicionaCategoriaAsync(CategoriaRequest request);
        Task<bool> AtualizarCategoriaAsync(CategoriaRequest request, int id);
        Task<bool> DeletarCategoriaAsync(int id);
    }
}
