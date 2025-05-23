namespace TrelloManagementSystem.Features.Tasks.EditeTask
{
    public class UpdaterequetTaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}