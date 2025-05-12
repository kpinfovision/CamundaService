using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.AccountService.Application
{
    public class ExternalServiceSettings
    {
        public string CamundaClusterID { get; set; }
        public string Camunda_client_id { get; set; }
        public string  Camunda_client_secret { get; set; }
        public string Camunda_region_id { get; set; }
    }
}
