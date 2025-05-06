
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.CamundaService.Domain.Entities
{
    public class AssetUploadRequest
    {
        public Guid PropertyId { get; set; }
        public string PropertyStatus { get; set; }
        public decimal PropertyPrice { get; set; }
        public DateTime DateAvailable { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public string Rework { get; set; }
        public string TimerDuration { get; set; } = "PT5M";
        public string PropertyAddress { get; set; }
        public string OwnerContact { get; set; }
        public string PropertyType { get; set; }
    }
}
