﻿using TrelloManagementSystem.Common.Enums;
using TrelloManagementSystem.Features.Common;

namespace TrelloManagementSystem.Features.Projects.Common
{
    public class ProjectRequestViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ProjectsStatus ProjectStatus { get; set; } = ProjectsStatus.Private;
        public ICollection<ProjectTaskDto> Tasks { get; set; } = new HashSet<ProjectTaskDto>();
        public ICollection<UserDto> Users { get; set; } = new HashSet<UserDto>();
    }
}
