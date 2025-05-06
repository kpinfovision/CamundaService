using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xome.Cascade2.CamundaService.Application.Services;
using Xome.Cascade2.CamundaService.Domain.Entities;

namespace Xome.Cascade2.CamundaService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamundaController : ControllerBase
    {
        private readonly Application.Services.CamundaService _camundaService;
        private readonly IConfiguration _configuration;
        
        public CamundaController(Application.Services.CamundaService camundaService, IConfiguration configuration) {
            _camundaService = camundaService;
            _configuration = configuration;
        }

        [HttpPost("Asset/StartProcess")]
        public async Task<CamundaProcess> StartProcess(string processDefinitionId, AssetUploadRequest assetUploadRequest)
        {
            var getCamundaClusterId = _configuration["CamundaClusterID"];
            var variables = new
            {
                propertyStatus = assetUploadRequest.PropertyStatus,
                propertyPrice = assetUploadRequest.PropertyPrice,
                dateAvailable = assetUploadRequest.DateAvailable.ToString("yyyy-MM-dd"), //dateAvailable.Replace("-","/"),
                ownerName = assetUploadRequest.OwnerName,
                ownerEmail = assetUploadRequest.OwnerEmail,
                rework = assetUploadRequest.Rework,
                timerDuration = assetUploadRequest.TimerDuration,
                propertyAddress = assetUploadRequest.PropertyAddress,
                ownerContact = assetUploadRequest.OwnerContact,
                propertyType = assetUploadRequest.PropertyType,
            };
            return await _camundaService.StartProcess(getCamundaClusterId, processDefinitionId, variables);
            // return Ok($"Process started successfully");
        }
        [HttpPost("AssignCamundaTask")]
        public async Task<CamundaTask> AssignCamundaTask(string taskId, string assignee, string processInstanceKey)
        {
            var getCamundaClusterId = _configuration["CamundaClusterID"];
            return await _camundaService.AssignCamundaTask(taskId, assignee, getCamundaClusterId, processInstanceKey);
            // return Ok($"Process started successfully");
        }
        [HttpPost("Asset/CompleteCamundaTask")]
        public async Task CompleteCamundaTask(string taskId, AssetUploadRequest assetUploadRequest)
        {
            var getCamundaClusterId = _configuration["CamundaClusterID"];
            var variables = new
            {
                propertyStatus = assetUploadRequest.PropertyStatus,
                propertyPrice = assetUploadRequest.PropertyPrice,
                dateAvailable = assetUploadRequest.DateAvailable.ToString("yyyy-MM-dd"), //dateAvailable.Replace("-","/"),
                ownerName = assetUploadRequest.OwnerName,
                ownerEmail = assetUploadRequest.OwnerEmail,
                rework = assetUploadRequest.Rework,
                timerDuration = assetUploadRequest.TimerDuration,
                propertyAddress = assetUploadRequest.PropertyAddress,
                ownerContact = assetUploadRequest.OwnerContact,
                propertyType = assetUploadRequest.PropertyType,
            };
            await _camundaService.CompleteCamundaTask(taskId, getCamundaClusterId, variables);
            // return Ok($"Process started successfully");
        }

        [HttpGet("GetCamundaTaskVariables")]
        public async Task<List<CamundaTaskVariable>> GetCamundaTaskVariables(string taskId)
        {
            var camundaClusterId = _configuration["CamundaClusterID"];
            var variables = await _camundaService.GetTaskVariables(taskId, camundaClusterId);
            return variables;
        }
    }
}
