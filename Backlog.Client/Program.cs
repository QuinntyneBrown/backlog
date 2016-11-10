using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var context = new Backlog.Data.DataContext();

            var digi = context.Products.Include(x => x.Epics).Single(x => x.Id == 1);
            var kf = context.Products.Include(x => x.Epics).Single(x => x.Id == 2);

            foreach (var epic in context.Epics.Include(x => x.Product))
            {

                if (epic.Name != "Games" && epic.Name != "Viz RT" && epic.Name != "Contests")
                {
                    digi.Epics.Add(epic);
                    epic.Product = digi;
                }
                else
                {
                    kf.Epics.Add(epic);
                    epic.Product = kf;
                }
            }

            Console.ReadLine();
        }
            
    }
}
