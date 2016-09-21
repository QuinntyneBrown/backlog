using Backlog.Data;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Backlog.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var uow = Get().Resolve<IUow>();
            var csvFile = new StringBuilder();
            var filePath = @"C:\\Users\\Quinntyne\\Documents\\templates-backlog.txt";
            var epixs = @"C:\\Users\\Quinntyne\\Documents\\epics.txt";

            foreach (var epic in uow.Epics.GetAll()
                .Where(x=>!x.IsDeleted)
                .OrderByDescending(x=>x.Priority)
                .ThenBy(x=>x.Name)
                .Include(x=>x.Stories)){

                foreach (var story in epic.Stories.Where(s => !s.IsDeleted)) {
                    Console.WriteLine();
                    Console.WriteLine($"{story.Epic.Name}-{story.Name}");
                    var storyDescriptionPlainText = "";

                    if (!string.IsNullOrEmpty(story.Description))
                    {
                        storyDescriptionPlainText = StripHTML(story.Description);
                        Console.WriteLine($"{StripHTML(story.Description)}");
                    }

                    var newLine = string.Format($"{epic.Name}|{story.Name}|{storyDescriptionPlainText}");
                    csvFile.AppendLine(newLine);
                }
            }

            File.WriteAllText(filePath, csvFile.ToString());

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
