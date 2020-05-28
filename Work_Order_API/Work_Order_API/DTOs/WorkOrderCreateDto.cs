using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Work_Order_API.DTOs
{
    public class WorkOrderCreateDto
    {
        public string WorkOrderNumber { get; set; }
        public DateTime DateOpen { get; set; }
        public DateTime DateClosed { get; set; }
        public string Customer { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
