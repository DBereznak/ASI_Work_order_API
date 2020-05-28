using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Order_API.Models;


namespace Work_Order_API.Data
{
    public class WorkOrderContext :DbContext
    {
        public WorkOrderContext(DbContextOptions<WorkOrderContext> opt): base(opt)
        {

        }

        public DbSet<WorkOrder> WorkOrders { get; set; }
    }
}
