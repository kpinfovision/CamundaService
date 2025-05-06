using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xome.Cascade2.CamundaService.Domain.Entities;
//using System.Text.Json;
using System.Net;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Runtime;
using System.Threading.Tasks;

namespace Xome.Cascade2.CamundaService.Application.Services
{
    public class CamundaService
    {
        public async Task<CamundaProcess> StartProcess(string clusterId, string processDefinitionId, dynamic variables) // AssetUploadRequest assetUploadRequest
        {
            var requestBody = new
            {
                processDefinitionId = processDefinitionId, //"template-human-task-tutorial-1pnmbd1",                
                variables = variables
            };

            var url = $"https://dsm-1.zeebe.camunda.io:443/{clusterId}/v2/process-instances";
            HttpResponseMessage response = await GetHttpResponseMessage(url, "zeebe", requestBody);

            // Read and display response
            string responseContent = await response.Content.ReadAsStringAsync();
            CamundaProcess processRespose = new CamundaProcess();
            processRespose = JsonConvert.DeserializeObject<CamundaProcess>(responseContent);

            return processRespose;
        }

        public async Task<CamundaTask> AssignCamundaTask(string taskId, string assignee, string clusterId, string processInstanceKey)
        {
            CamundaTask task = new CamundaTask();
            var requestBody = new
            {
                assignee = assignee, //sujata.telang@infovision.com
                allowOverrideAssignment = true
            };
            
            var tasks = await GetProcessInstanceTasks(processInstanceKey, clusterId);
            var assigntask = tasks.Any() ? tasks.FirstOrDefault(t => t.id == taskId).id : string.Empty;

            if (assigntask != null)
            {
                var url = $"https://dsm-1.tasklist.camunda.io/{clusterId}/v2/user-tasks/{taskId}/assignment";
                HttpResponseMessage response = await GetHttpResponseMessage(url, "tasklist", requestBody, "POST");

                string jsonString = await response.Content.ReadAsStringAsync();
                task = JsonConvert.DeserializeObject<CamundaTask>(jsonString);
            }
            return task;
        }

        public async Task GetTaskDetails(string taskId, string clusterId)
        {
            var url = $"https://dsm-1.tasklist.camunda.io/{clusterId}/v1/tasks/{taskId}";
            HttpResponseMessage response = await GetHttpResponseMessage(url, "tasklist", new object());
        }

        public async Task<List<CamundaTask>> GetProcessInstanceTasks(string processInstanceKey, string clusterId)
        {
            var requestBody = new
            {
                processInstanceKey = processInstanceKey
            };

            var url = $"https://dsm-1.tasklist.camunda.io/{clusterId}/v1/tasks/search";
            HttpResponseMessage response = await GetHttpResponseMessage(url, "tasklist", requestBody);

            string jsonString = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<CamundaTask>>(jsonString) ?? new List<CamundaTask>();

            return tasks;
        }

        public async Task GetProcessInstanceVariables(string processInstanceKey, string clusterId)
        {
            var requestBody = new
            {
                processInstanceKey = processInstanceKey
            };

            var url = $"https://dsm-1.operate.camunda.io/{clusterId}/v1/variables/search";
            HttpResponseMessage response = await GetHttpResponseMessage(url, "operate", requestBody);
        }

        public async Task<List<CamundaTaskVariable>> GetTaskVariables(string taskId, string clusterId)
        {
            var requestBody = new { };

            var url = $"https://dsm-1.tasklist.camunda.io/{clusterId}/v1/tasks/{taskId}/variables/search";
            HttpResponseMessage response = await GetHttpResponseMessage(url, "tasklist", requestBody);

            string jsonString = await response.Content.ReadAsStringAsync();
            var variables = JsonConvert.DeserializeObject<List<CamundaTaskVariable>>(jsonString) ?? new List<CamundaTaskVariable>();

            return variables;
        }

        public async Task CompleteCamundaTask(string taskId, string clusterId, dynamic variables)
        {
            // TODO - need to check how we can make this method generalized to make any task as complete
            // currently its tightly bound to asset upload task request object
            var requestBody = new
            {
                variables = variables
            };

            var intTaskId = Convert.ToInt64(taskId);

            var url = $"https://dsm-1.tasklist.camunda.io/{clusterId}/v2/user-tasks/{intTaskId}/completion";
            await GetHttpResponseMessage(url, "tasklist", requestBody);
        }

        private async Task<HttpResponseMessage> GetHttpResponseMessage(string url, string audience, object requestBody, string method = "POST")
        {
            HttpClient _httpClient = new HttpClient();
            var accessToken = await GetAccessTokenByAudience(audience);

            // Convert object to JSON string
            string jsonString = JsonSerializer.Serialize(requestBody);

            // Create HttpContent with JSON payload
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            // Add headers (if needed)
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            // Send POST request
            HttpResponseMessage response = method == "POST" ? await _httpClient.PostAsync(url, content) : await _httpClient.PatchAsync(url, content);

            return response;
        }
        public async Task<string> GetAccessTokenByAudience(string audience)
        {
            HttpClient _httpClient = new HttpClient();
            var values = new Dictionary<string, string>
            {
                 { "grant_type", "client_credentials" },
                // { "client_id", "zFey.6BmlPYuCbN-EnPlnRDud02cLh2E" },
                //{ "client_secret", "H8-qO152.MLIiA3jFaQIIgh-DR4pgr~Gi05Yopeu9As6Mno3yxFAEbN144ZEvABB" },
                { "client_id", "4.ov6KdTVNRXE49f.GAwq9qMNFgSq915" },
                { "client_secret", "jJPMwBmzEb3XojD~OI3pHsEcrltEAljKFcyE4VC9Cq7SofcjddKuApPNiq7thsjw" },
                { "audience", $"{audience}.camunda.io" }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await _httpClient.PostAsync("https://login.cloud.camunda.io/oauth/token", content);
            var responseString = await response.Content.ReadAsStringAsync();

            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseString);
            return tokenResponse.access_token;
        }
    }
}
