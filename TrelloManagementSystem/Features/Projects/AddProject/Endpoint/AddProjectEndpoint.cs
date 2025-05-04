using Azure;
using Microsoft.AspNetCore.Mvc;
using TrelloManagementSystem.Common.Response;

namespace TrelloManagementSystem.Features.Projects.AddProject.Endpoint
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AddProjectEndpoint : ControllerBase
    {

        //كل اند بوينت ليها كلاس لوحدها
        [HttpPost]
        public async Task<EndpointResponse<AddProjectResponseViewModel>> AddProject(AddProjectRequestViewModel request)
        {
            //  add the project
            var response = new AddProjectResponseViewModel { };
            return EndpointResponse<AddProjectResponseViewModel>.Success(response, "Project added successfully.");

        }
    }
}


















