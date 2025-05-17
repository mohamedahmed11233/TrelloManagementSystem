using TrelloManagementSystem.Common.Enums;

namespace TrelloManagementSystem.Features.Projects.UpdateProject
{
    public class UpdateProjectResponseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ProjectsStatus ProjectStatus { get; set; } = ProjectsStatus.Private;
        public string Tasks { get; set; } 
    }
}
