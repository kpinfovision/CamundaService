using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.CamundaService.Domain.Entities
{
    public class TaskFields
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public List<string> TaskMappingFields { get; set; }
    }
}
