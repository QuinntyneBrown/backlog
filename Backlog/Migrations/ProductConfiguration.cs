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
            var digi = new Product()
            {
                Name = "Diginet Template"
            };

            var kf = new Product()
            {
                Name = "Kids and Family Template"
            };

            context.Products.AddOrUpdate(x => x.Name, digi);

            context.Products.AddOrUpdate(x => x.Name, kf);

            foreach(var epic in context.Epics.Include(x=>x.Product))
            {

                if (epic.Name != "Games" && epic.Name != "Viz RT" && epic.Name != "Contests")
                {
                    digi.Epics.Add(epic);
                    context.SaveChanges();
                    epic.ProductId = digi.Id;
                }
                else
                {
                    kf.Epics.Add(epic);
                    context.SaveChanges();
                    epic.ProductId = kf.Id;
                }
            }

            context.SaveChanges();
        }
    }
}
