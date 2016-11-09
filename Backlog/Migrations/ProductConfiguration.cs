using System.Data.Entity.Migrations;
using Backlog.Data;
using Backlog.Models;
using Backlog.Services;
using System.Data.Entity;
using System.Linq;

namespace Backlog.Migrations
{
    public class ProductConfiguration
    {
        public static void Seed(DataContext context) {

            context.Products.AddOrUpdate(x => x.Name, new Product()
            {
                Name = "Diginet Template"
            });

            context.Products.AddOrUpdate(x => x.Name, new Product()
            {
                Name = "Kids and Family Template"
            });

            context.SaveChanges();
            var product = context.Products.Where(x => x.Name == "Diginet Template").Single();

            foreach (var epic in context.Epics.Where(x => !x.IsDeleted))
            {
                epic.ProductId = product.Id;
            }

            context.SaveChanges();
        }
    }
}
