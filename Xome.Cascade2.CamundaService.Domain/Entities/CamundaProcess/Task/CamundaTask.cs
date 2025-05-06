using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.CamundaService.Domain.Entities
{
    public class CamundaTask
    {
        public string id { get; set; }
        public string name { get; set; }
        public string taskDefinitionId { get; set; }
        public string processName { get; set; }
        public string creationDate { get; set; }
        public string completionDate { get; set; }
        public string assignee { get; set; }
        public string taskState { get; set; }
        public bool isFirst { get; set; }
        public string formKey { get; set; }
        public string formId { get; set; }
        public int formVersion { get; set; }
      //  public bool? isFormEmbedded { get; set; }
        public string processDefinitionKey { get; set; }
        public string processInstanceKey { get; set; }
        public string dueDate { get; set; }
        public string followUpDate { get; set; }
        // public string[] variables { get; set; } = new string[0];
    }
}
