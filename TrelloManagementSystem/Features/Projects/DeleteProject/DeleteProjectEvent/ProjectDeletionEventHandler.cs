using Hangfire;
using MediatR;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Projects.DeleteProject.DeletionOrchestrator;

namespace TrelloManagementSystem.Features.Projects.DeleteProject.DeleteProjectEvent
{
    public class ProjectDeletionEventHandler : INotificationHandler<ProjectDeletionEvent>
    {
        private readonly BaseRequestParameters _parameters;
        private readonly ILogger<ProjectDeletionEventHandler> _logger;

        public ProjectDeletionEventHandler(BaseRequestParameters parameters, ILogger<ProjectDeletionEventHandler> logger)
        {
            _parameters = parameters;
            _logger = logger;
        }

        public async Task Handle(ProjectDeletionEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                // Assuming notification contains the projectId
                var projectId = notification.projectId;

                // First delete the project through the orchestrator
                var deleteResult = await _parameters.Mediator.Send(new DeleteProjectOrchestrator(projectId), cancellationToken);

                // Then enqueue the cleanup job
                BackgroundJob.Enqueue(() => PerformCleanup(projectId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling project deletion for project ID {ProjectId}", notification);
                throw; // Or handle it differently based on your requirements
            }
        }


        public async Task PerformCleanup(int projectId)
        {
            try
            {
                // Cleanup logic for the deleted project
                var project = await _parameters.Repository.GetByIdAsync(projectId);
                if (project != null)
                {
                    await _parameters.Repository.DeleteAsync(project);
                    _logger.LogInformation("Project with ID {ProjectId} has been deleted and cleanup has been performed.", projectId);
                }
                else
                {
                    _logger.LogWarning("Project with ID {ProjectId} not found during cleanup.", projectId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during cleanup for project ID {ProjectId}", projectId);
                throw; // Hangfire will retry if configured
            }
        }
    }


}
