using System.Data.Entity.Migrations;
using Backlog.Data;
using Backlog.Models;
using Backlog.Services;

namespace Backlog.Migrations
{
    public class ThemeConfiguration
    {
        public static void Seed(DataContext context) {

            context.Themes.AddOrUpdate(x => x.Name, new Theme() {
                Name = "Architecture"
            });

            context.Themes.AddOrUpdate(x => x.Name, new Theme()
            {
                Name = "Styling"
            });

            context.Themes.AddOrUpdate(x => x.Name, new Theme()
            {
                Name = "Implementation"
            });

            context.Themes.AddOrUpdate(x => x.Name, new Theme()
            {
                Name = "Design"
            });

            context.SaveChanges();
        }
    }
}
