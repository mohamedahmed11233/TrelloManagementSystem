using MediatR;
using TrelloManagementSystem.Common.Request;

namespace TrelloManagementSystem.Features.Projects.DeleteProject.DeleteProjectEvent
{
    public record ProjectDeletionEvent(int projectId) :INotification;


}
