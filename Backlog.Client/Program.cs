using System;
using Backlog.Extenstions;
namespace Backlog.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var context = new Backlog.Data.DataContext();

            foreach (var article in context.Articles) {
                if(!article.IsDeleted)
                    article.Slug = article.Title.GenerateSlug();
            }

            context.SaveChanges();

            Console.ReadLine();
        }
            
    }
}
