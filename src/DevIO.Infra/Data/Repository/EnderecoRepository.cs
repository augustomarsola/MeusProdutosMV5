using System;
using System.Threading.Tasks;
using DevIO.Business.Models.Fornecedores;

namespace DevIO.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await ObterPorId(fornecedorId); //Podemos fazer desta forma pois o endereço o do produto é o mesmo do fornecedor, desta forma podemos buscar pelo ID
        }
    }
}
