using TrelloManagementSystem.Common.Enums;
namespace TrelloManagementSystem.Models
{
    public class ProjectTask:BaseModel
    {
        public string Title { get; set; }
        public TasksStatus TaskStatus { get; set; }
        public ICollection<Project> Projects { get; set; } = new HashSet<Project>();
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
