namespace TrelloManagementSystem.Common.Enum
{
    [Flags]
    public enum TaskStatus
    {
        ToDo = 1,
        InProgress = 2,
        Done = 3,
        Blocked = 4,
        Archived = 5,
        Deleted = 6
    }
}
