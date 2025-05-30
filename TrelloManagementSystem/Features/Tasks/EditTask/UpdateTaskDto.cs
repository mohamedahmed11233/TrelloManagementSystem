﻿using TrelloManagementSystem.Common.Enums;

namespace TrelloManagementSystem.Features.Tasks.EditTask
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
