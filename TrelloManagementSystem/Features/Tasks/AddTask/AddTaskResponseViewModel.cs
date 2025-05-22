using System.ComponentModel.DataAnnotations;
using TrelloManagementSystem.Common.Enums;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Tasks.AddTask
{
    public class AddTaskResponseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TasksStatus TaskStatus { get; set; }
        public int ProjectId { get; set; }

        public int UserId { get; set; }
    }
}
