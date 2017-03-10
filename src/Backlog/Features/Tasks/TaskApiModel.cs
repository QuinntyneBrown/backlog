using Backlog.Data.Model;
using System;

namespace Backlog.Features.Tasks
{
    public class TaskApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        public static TModel FromTask<TModel>(Task task) where
            TModel : TaskApiModel, new()
        {
            var model = new TModel();
            model.Id = task.Id;
            model.Name = task.Name;
            model.Description = task.Description;
            model.StartDate = task.StartDate;
            model.CompletedDate = task.CompletedDate;
            return model;
        }

        public static TaskApiModel FromTask(Task task)
            => FromTask<TaskApiModel>(task);        
    }
}
