using System.Data.Entity.Migrations;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Tasks;

namespace Backlog.Migrations
{
    public class TaskStatusConfiguration
    {
        public static void Seed(BacklogContext context) {

            context.TaskStatuses.AddOrUpdate(x => x.Name, new TaskStatus()
            {
                Name = "[Task Status] Not Started"
            });

            context.TaskStatuses.AddOrUpdate(x => x.Name, new TaskStatus()
            {
                Name = "[Task Status] In Progress"
            });

            context.TaskStatuses.AddOrUpdate(x => x.Name, new TaskStatus() {
                Name = "[Task Status] QA"
            });

            context.TaskStatuses.AddOrUpdate(x => x.Name, new TaskStatus()
            {
                Name = "[Task Status] Complete"
            });

            context.SaveChanges();
        }
    }
}
