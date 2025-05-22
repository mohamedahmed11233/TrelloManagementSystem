using System.ComponentModel.DataAnnotations;
using TrelloManagementSystem.Common.Enums;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Tasks.AddTask
{
    public class AddTaskRequestViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public int ProjectId { get; set; }
        
        [Required]
        public int UserId { get; set; }

    }
}
