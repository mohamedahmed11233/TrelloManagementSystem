namespace TrelloManagementSystem.Common.Enum
{
    [Flags]
    public enum ProjectStatus
    {
        Public = 1,
        Private = 2,
        Archive = 3,
        Deleted = 4,
        Completed = 5,
    }
}
