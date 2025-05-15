using CRUD_aplication.Models;
using CRUD_aplication.Repository.Implementation;
using CRUD_aplication.Repository.Interface;
using CRUD_aplication.Service.Interface;

namespace CRUD_aplication.Service.Implementation
{
    public class ElencoService : IElencoService
    {
        private readonly IElencoRepository _elencoRepository;
        public ElencoService(IElencoRepository elencoRepository)
        {
            _elencoRepository = elencoRepository;
        }
        public Task<List<ElencoResponse>> BuscaElencoAsync()
        {
            return _elencoRepository.BuscaElencoAsync();
        }
        public Task<ElencoResponse?> BuscaElencoAsync(int id)
        {
            return _elencoRepository.BuscaElencoAsync(id);
        }
        public Task<bool> AdicionaElencoAsync(ElencoRequest request)
        {
            return _elencoRepository.AdicionaElencoAsync(request);
        }
        public Task<bool> AtualizarElencoAsync(ElencoRequest request, int id)
        {
            return _elencoRepository.AtualizarElencoAsync(request, id);
        }
        public Task<bool> DeleteAsync(int id)
        {
            return _elencoRepository.DeleteAsync(id);
        }
    }
}
