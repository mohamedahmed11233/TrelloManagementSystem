namespace TrelloManagementSystem.Common.Enums
{
    [Flags]
    public enum ProjectsStatus
    {
        Public = 1,
        Private = 2,
        Archive = 3,
        Deleted = 4,
        Completed = 5,
    }
}
