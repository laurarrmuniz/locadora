using CRUD_aplication.Models;
using CRUD_aplication.Repository.Implementation;
using CRUD_aplication.Repository.Interface;
using CRUD_aplication.Service.Interface;

namespace CRUD_aplication.Service.Implementation
{
    public class ProdutoraService : IProdutoraService
    {
        private readonly IProdutoraRepository _produtoraRepository;
        public ProdutoraService(IProdutoraRepository produtoraRepository)
        {
            _produtoraRepository = produtoraRepository;
        }
        public async Task<List<ProdutoraResponse>> BuscaProdutoraAsync()
        {
            return await _produtoraRepository.BuscaProdutoraAsync();
        }

        public async Task<ProdutoraResponse?> BuscaProdutoraAsync(int id)
        {
            return await _produtoraRepository.BuscaProdutoraAsync(id);
        }

        //public async Task<bool> AdicionaProdutoraAsync(ProdutoraRequest request)
        //{
        //    return await _produtoraRepository.AdicionaProdutoraAsync(request);
        //}

        public async Task<bool> AdicionaProdutoraAsync(ProdutoraRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Nome))
                throw new ArgumentException("O nome é obrigatório.");

            return await _produtoraRepository.AdicionaProdutoraAsync(request);
        }


        public async Task<bool> AtualizarProdutoraAsync(ProdutoraRequest request, int id)
        {
            return await _produtoraRepository.AtualizarProdutoraAsync(request, id);
        }

        public async Task<bool> DeletarProdutoraAsync(int id)
        {
            return await _produtoraRepository.DeletarProdutoraAsync(id);
        }
    }
}
