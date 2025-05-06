
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.CamundaService.Domain.Entities
{
    public class CamundaProcess
    {
        public string processDefinitionKey { get; set; }
        public string processInstanceKey { get; set; }
        public string processDefinitionId { get; set; }
        public int processDefinitionVersion { get; set; }
        public object variables { get; set; }
    }
}
