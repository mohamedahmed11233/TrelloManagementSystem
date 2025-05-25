using TrelloManagementSystem.Common.Enums;
namespace TrelloManagementSystem.Models
{
    public class ProjectTask:BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TasksStatus TaskStatus { get; set; }= TasksStatus.New;
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public DateTime Deadline { get; set; }= DateTime.Now.AddDays(7);
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
