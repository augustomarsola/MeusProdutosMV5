using DevIO.Business.Core.Models;
using DevIO.Business.Models.Fornecedores;
using System;

namespace DevIO.Business.Models.Produtos
{
    public class Produto : Entity
    {
        //Informar à quem pertence o produto
        public Guid ForncedorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public string Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */ //Feito para que o Entity lembre que o produto trabalhe com o Fornecedor
        public Fornecedor Fornecedor { get; set; }
    }
}
