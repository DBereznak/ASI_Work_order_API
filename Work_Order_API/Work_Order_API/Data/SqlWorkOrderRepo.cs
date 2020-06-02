using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Order_API.Models;
using Microsoft.EntityFrameworkCore;


namespace Work_Order_API.Data
{
    public class SqlWorkOrderRepo : IWorkOrderRepo
    {
        private readonly WorkOrderContext _context;

        public SqlWorkOrderRepo(WorkOrderContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateWorkOrder(WorkOrder wo)
        {
           if(wo == null)
            {
                throw new ArgumentNullException(nameof(wo));
            }

            await _context.WorkOrders.AddAsync(wo);

            return await SaveChanges();
        }


        public async Task<bool>  DeleteWorkOrder(WorkOrder wo)
        {
            if(wo == null)
            {
                throw new ArgumentNullException(nameof(wo));
            }

            _context.WorkOrders.Remove(wo);
            return await SaveChanges();
        }

        public async Task<IList<WorkOrder>> GetAllWorkOrders()
        {
            var workOrders = await _context.WorkOrders.ToListAsync();
            return workOrders;
        }


        public async Task<WorkOrder> GetWorkOrderByID(int id)
        {
            var workOrder = await _context.WorkOrders.FindAsync(id);

            return workOrder;
        }
        public async Task<bool> UpdateWorkOrder(WorkOrder wo)
        {
            _context.WorkOrders.Update(wo);
            return await SaveChanges();
        }

        public async Task<bool> SaveChanges()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<WorkOrder> GetWorkOrderByWorkOrderNumber(string WorkOrderNumber)
        {
            //This is the way to query non primary key items
            var workOrder = await _context.WorkOrders.Where(x => x.WorkOrderNumber == WorkOrderNumber).FirstOrDefaultAsync();

            return workOrder;
        }
    }
}
