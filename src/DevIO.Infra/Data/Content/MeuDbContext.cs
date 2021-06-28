using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Produtos;
using System.Data.Entity;

namespace DevIO.Infra.Data.Content
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext() : base(nameOrConnectionString: "DefaultConnection")
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
    }
}
