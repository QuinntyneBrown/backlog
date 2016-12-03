using System;
using System.Linq;
using Backlog.Data;

namespace Backlog.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            var context = new DataContext();
            
            var roles = context.Roles.ToList();
            
            context.SaveChanges();

            Console.ReadLine();
        }
            
    }
}
