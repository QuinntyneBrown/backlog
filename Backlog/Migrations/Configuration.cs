namespace Backlog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Backlog.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Backlog.Data.DataContext context)
        {
            //RoleConfiguration.Seed(context);
            //TaskStatusConfiguration.Seed(context);
        }
    }
}
