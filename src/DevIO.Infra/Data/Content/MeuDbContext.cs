using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Produtos;
using DevIO.Infra.Data.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DevIO.Infra.Data.Content
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext() : base(nameOrConnectionString: "DefaultConnection")
        {
            //Desativando essas duas propriedades garantimos uma melhor perfomance da nossa aplicação
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Deletando convenções padrões que não iremos utilizar
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //Ele tenta plurazar automaticaticamente, porém é bem falho
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //Eu que decido quem deve ser deletado, deste modo ele não faz automaticamente
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); //Eu que decido quem deve ser deletado, deste modo ele não faz automaticamente

            //Configuração para modelos genéricos, de certa forma todos aqueles que não forem passados parâmetros específicos, seguirão essa linha
            modelBuilder.Properties<string>()
                .Configure(p => p
                .HasColumnType("varchar")
                .HasMaxLength(100));

            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());

            base.OnModelCreating(modelBuilder); //Garante que ele faço o resto que deve ser feito
        }
    }
}
