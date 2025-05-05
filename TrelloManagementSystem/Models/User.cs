namespace TrelloManagementSystem.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public ICollection<Project> Projects { get; set; } = new HashSet<Project>();
        public ICollection<ProjectTask> Tasks { get; set; } = new HashSet<ProjectTask>();




    }
}
