using System.Data.Entity.Migrations;
using Backlog.Data;
using Backlog.Models;
using Backlog.Infrastructure;

namespace Backlog.Migrations
{
    public class TaskStatusConfiguration
    {
        public static void Seed(DataContext context) {

            context.TaskStatuses.AddOrUpdate(x => x.Name, new TaskStatus()
            {
                Name = TaskStatuses.NOT_STARTED
            });

            context.TaskStatuses.AddOrUpdate(x => x.Name, new TaskStatus()
            {
                Name = TaskStatuses.IN_PROGRESS
            });

            context.TaskStatuses.AddOrUpdate(x => x.Name, new TaskStatus()
            {
                Name = TaskStatuses.QA
            });

            context.TaskStatuses.AddOrUpdate(x => x.Name, new TaskStatus()
            {
                Name = TaskStatuses.COMPLETE
            });

            context.SaveChanges();
        }
    }
}
