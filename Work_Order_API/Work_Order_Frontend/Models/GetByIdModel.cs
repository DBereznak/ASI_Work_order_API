using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Work_Order_Frontend.wwwroot.Models
{
    public class GetByIdModel
    {
        [Required]
        public int Id { get; set; }
    }
}
