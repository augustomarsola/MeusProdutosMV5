using DevIO.Infra.Data.Content;
using System.Data.Entity.Migrations;

namespace DevIO.Infra.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MeuDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
