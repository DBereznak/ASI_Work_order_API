using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Work_Order_API.Models
{
    public class WorkOrder
    {
        public int Id {get; set;}
        [Required]
        [MaxLength(7)]
        public string WorkOrderNumber { get; set; }
        [Required]
        public DateTime DateOpen { get; set; }
        public DateTime DateClosed { get; set; }
        [Required]
        [MaxLength(25)]
        public string Customer { get; set; }
        [Required]
        [MaxLength(7)]
        public string RegistrationNumber { get; set; }
    }

}
