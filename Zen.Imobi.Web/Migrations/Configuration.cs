namespace Zen.Imobi.Web.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Zen.Imobi.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Zen.Imobi.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(Zen.Imobi.Web.Models.ApplicationDbContext context)
        {
        }
    }
}