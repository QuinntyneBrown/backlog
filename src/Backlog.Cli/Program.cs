using MediatR;
using Microsoft.Practices.Unity;
using static Backlog.UnityConfiguration;

namespace Backlog.Cli
{
    class Program
    {
        static void Main(string[] args) => GetContainer().Resolve<Program>().ProcessArgs(args);

        public void ProcessArgs(string[] args)
        {

        }

        private readonly IMediator _mediator;
    }
}
