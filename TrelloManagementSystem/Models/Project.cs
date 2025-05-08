using TrelloManagementSystem.Common.Enums;

namespace TrelloManagementSystem.Models
{
    public class Project :BaseModel
    {
        public string Title { get; set; }
        public ProjectsStatus ProjectStatus { get; set; } = ProjectsStatus.Private;
        public ICollection<ProjectTask> Tasks { get; set; } = new HashSet<ProjectTask>();
        public ICollection<User> Users { get; set; } = new HashSet<User>();

    }
}
