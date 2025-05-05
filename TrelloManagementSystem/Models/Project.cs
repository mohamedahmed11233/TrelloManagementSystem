using TrelloManagementSystem.Common.Enum;

namespace TrelloManagementSystem.Models
{
    public class Project :BaseModel
    {
        public string Title { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; } = new HashSet<ProjectTask>();

    }
}
