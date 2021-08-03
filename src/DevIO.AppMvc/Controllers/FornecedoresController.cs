using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Fornecedores.Services;
using DevIO.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DevIO.AppMvc.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedoresController()
        {
            _fornecedorService = new FornecedorService(new FornecedorRepository(), new EnderecoRepository());
        }

        public async Task<ActionResult> Index()
        {
            var fornecedor = new Fornecedor()
            {
                ////Testando a validação com campos errados
                //Nome = "",
                //Documento = "11111",
                //Endereco = new Endereco(),
                //TipoFornecedor = TipoFornecedor.PessoaFisica,
                //Ativo = true

                ////Testando a validação com campos corretos
                Nome = "Marsola",
                Documento = "23058089652",
                Endereco = new Endereco 
                {
                    Logradouro = "Rua Teste",
                    Numero = "123",
                    Complemento = "Teste",
                    Bairro = "Teste",
                    Cep = "12345678",
                    Cidade = "Teste",
                    Estado = "Teste"
                },
                TipoFornecedor = TipoFornecedor.PessoaFisica,
                Ativo = true
            };

            await _fornecedorService.Adicionar(fornecedor);

            return new EmptyResult();
        }
    }
}