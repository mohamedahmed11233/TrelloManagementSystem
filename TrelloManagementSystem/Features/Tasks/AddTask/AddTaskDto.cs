using TrelloManagementSystem.Common.Enums;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Tasks.AddTask
{
    public class AddTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public TasksStatus TaskStatus { get; set; } = TasksStatus.New;
        public int ProjectId { get; set; }
        public DateTime Deadline { get; set; } = DateTime.Now.AddDays(7);

        public int UserId { get; set; }
    }
}
