using TrelloManagementSystem.Common.Enums;

namespace TrelloManagementSystem.Features.Common
{
    public class ProjectTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TasksStatus TaskStatus { get; set; }
        public string ProjectDescription { get; set; }
    }
}
