using TrelloManagementSystem.Common.Enums;

namespace TrelloManagementSystem.Features.Tasks.GetTaskById
{
    public class GetTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; } 

        public TasksStatus TaskStatus { get; set; }
        public string TaskStatusText => TaskStatus.ToString();

        public string ProjectTitle { get; set; }
        public string UserName { get; set; }
    }
}
