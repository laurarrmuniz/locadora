using CRUD_aplication.Models;

namespace CRUD_aplication.Repository.Interface
{
    public interface IProdutoraRepository
    {
        Task<List<ProdutoraResponse>> BuscaProdutoraAsync();
        Task<ProdutoraResponse?> BuscaProdutoraAsync(int id);
        Task<bool> AdicionaProdutoraAsync(ProdutoraRequest request);
        Task<bool> AtualizarProdutoraAsync(ProdutoraRequest request, int id);
        Task<bool> DeletarProdutoraAsync(int id);
    }
}
