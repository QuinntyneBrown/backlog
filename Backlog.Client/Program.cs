using Backlog.Data;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Backlog.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var uow = Get().Resolve<IUow>();

            foreach(var story in uow.Stories.GetAll()
                .Where(x=>!x.IsDeleted)
                .Where(x=>!x.Epic.IsDeleted)
                .Include(x=>x.Epic)){

                Console.WriteLine();
                Console.WriteLine($"{story.Epic.Name}-{story.Name}");

                if(!string.IsNullOrEmpty(story.Description))
                    Console.WriteLine($"{StripHTML(story.Description)}");

            }

            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        public static IUnityContainer Get() {
            var container = new UnityContainer();
            container.RegisterType<IDbContext, DataContext>();
            container.RegisterType<IUow, Uow>();
            container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            return container;
        }

        public static string StripHTML(string input)
        {
            string output = Regex.Replace(input, "<.*?>", String.Empty);
            output = output.Replace("&nbsp;", " ");
            output = output.Replace(System.Environment.NewLine, " ");
            output = Regex.Replace(output, @"\t|\n|\r", " ");
            return output;
        }
    }
}
