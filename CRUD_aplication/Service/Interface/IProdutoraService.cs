using CRUD_aplication.Models;

namespace CRUD_aplication.Service.Interface
{
    public interface IProdutoraService
    {
        Task<List<ProdutoraResponse>> BuscaProdutoraAsync();
        Task<ProdutoraResponse?> BuscaProdutoraAsync(int id);
        Task<bool> AdicionaProdutoraAsync(ProdutoraRequest request);
        Task<bool> AtualizarProdutoraAsync(ProdutoraRequest request, int id);
        Task<bool> DeletarProdutoraAsync(int id);
    }
}
