using CRUD_aplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_aplication.Repository.Interface
{
    public interface IElencoRepository
    {
        Task<List<ElencoResponse>> BuscaElencoAsync();
        Task<ElencoResponse?> BuscaElencoAsync(int id);
        Task<bool> AdicionaElencoAsync(ElencoRequest request);
        Task<bool> AtualizarElencoAsync(ElencoRequest request, int id);
        Task<bool> DeleteAsync(int id);
    }
}
