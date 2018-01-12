using Backlog.Model;

namespace Backlog.Features.Projects
{
    public class ProjectApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromProject<TModel>(Project project) where
            TModel : ProjectApiModel, new()
        {
            var model = new TModel();
            model.Id = project.Id;
            return model;
        }

        public static ProjectApiModel FromProject(Project project)
            => FromProject<ProjectApiModel>(project);

    }
}
