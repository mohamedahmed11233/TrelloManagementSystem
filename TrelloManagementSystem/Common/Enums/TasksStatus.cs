namespace TrelloManagementSystem.Common.Enums
{
    [Flags]
    public enum TasksStatus
    {
        ToDo = 1,
        InProgress = 2,
        Done = 3,
        Blocked = 4,
        Archived = 5,
        Deleted = 6,
        New = 7
    }
}
