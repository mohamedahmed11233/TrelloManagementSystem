using System;
using System.ComponentModel;
using System.Reflection;

public enum ErrorCode
{
    // General errors (0-99)
    [Description("No error")]
    None = 0,

    [Description("An unknown error occurred")]
    Unknown = 1,

    [Description("The requested resource does not exist")]
    DoesNotExist = 2,

    [Description("Invalid input provided")]
    InvalidInput = 3,

    [Description("You are not authorized to perform this action")]
    NotAuthorized = 4,

    [Description("A server error occurred")]
    ServerError = 5,

    [Description("A database error occurred")]
    DatabaseError = 6,

    [Description("Validation failed")]
    ValidationFailed = 7,

    // Project errors (100-199)
    [Description("Project not found")]
    ProjectNotFound = 100,

    [Description("Project already exists")]
    ProjectAlreadyExists = 101,

    [Description("Failed to create project")]
    FailedCreateProject = 102,

    [Description("Failed to update project")]
    FailedUpdateProject = 103,

    [Description("Failed to delete project")]
    FailedDeleteProject = 104,

    [Description("Access to project denied")]
    ProjectAccessDenied = 105,

    [Description("Invalid project data")]
    InvalidProjectData = 106,

    // Task errors (200-299)
    [Description("Task not found")]
    TaskNotFound = 200,

    [Description("Task already exists")]
    TaskAlreadyExists = 201,

    [Description("Failed to create task")]
    FailedCreateTask = 202,

    [Description("Failed to update task")]
    FailedUpdateTask = 203,

    [Description("Failed to delete task")]
    FailedDeleteTask = 204,

    [Description("Access to task denied")]
    TaskAccessDenied = 205,

    [Description("Invalid task data")]
    InvalidTaskData = 206,

    [Description("Failed to move task")]
    TaskMoveFailed = 208,

    [Description("Failed to assign task")]
    TaskAssignmentFailed = 211,

    // User errors (300-399)
    [Description("User not found")]
    UserNotFound = 300,

    [Description("User already exists")]
    UserAlreadyExists = 301,

    [Description("Failed to create user")]
    FailedCreateUser = 302,

    [Description("Failed to update user")]
    FailedUpdateUser = 303,

    [Description("Failed to delete user")]
    FailedDeleteUser = 304,

    [Description("Access to user denied")]
    UserAccessDenied = 305,

    [Description("Invalid user data")]
    InvalidUserData = 306,

    [Description("User authentication failed")]
    UserAuthenticationFailed = 307,

    // Board/List errors (400-499)
    [Description("Board not found")]
    BoardNotFound = 400,

    [Description("Access to board denied")]
    BoardAccessDenied = 401,

    [Description("Failed to create board")]
    FailedCreateBoard = 402,

    [Description("Failed to update board")]
    FailedUpdateBoard = 403,

    [Description("Failed to delete board")]
    FailedDeleteBoard = 404,

    [Description("List not found")]
    ListNotFound = 410,

    [Description("Access to list denied")]
    ListAccessDenied = 411,

    [Description("Failed to create list")]
    FailedCreateList = 412,

    [Description("Failed to update list")]
    FailedUpdateList = 413,

    [Description("Failed to delete list")]
    FailedDeleteList = 414,

    // Integration errors (600-699)
    [Description("Integration failed")]
    IntegrationFailed = 600,

    [Description("API synchronization failed")]
    ApiSyncFailed = 601,

    // External service errors (2000-2099)
    [Description("External service unavailable")]
    ExternalServiceUnavailable = 2000,

    [Description("API call limit exceeded")]
    ApiCallLimitExceeded = 2001
}

