using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.CamundaService.Domain.Entities
{
    public class UserTaskFieldMapping
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public List<string> AccessTaskFields { get; set; }
        // public List<string> AccessTaskFieldValues { get; set; }
    }
}
