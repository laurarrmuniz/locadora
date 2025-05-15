using System;
using CRUD_aplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_aplication.Service.Interface
{
    public interface IElencoService
    {
        Task<List<ElencoResponse>> BuscaElencoAsync();
        Task<ElencoResponse?> BuscaElencoAsync(int id);
        Task<bool> AdicionaElencoAsync(ElencoRequest request);
        Task<bool> AtualizarElencoAsync(ElencoRequest request, int id);
        Task<bool> DeleteAsync(int id);
    }
}


