using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace Xome.Cascade2.CamundaService.Domain.Entities
{
    public class CamundaTaskVariable
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
}
