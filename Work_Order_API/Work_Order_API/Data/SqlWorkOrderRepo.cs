using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Order_API.Models;

namespace Work_Order_API.Data
{
    public class SqlWorkOrderRepo : IWorkOrderRepo
    {
        private readonly WorkOrderContext _context;

        public SqlWorkOrderRepo(WorkOrderContext context)
        {
            _context = context;
        }
        public void CreateWorkOrder(WorkOrder wo)
        {
           if(wo == null)
            {
                throw new ArgumentNullException(nameof(wo));
            }

            _context.WorkOrders.Add(wo);
        }

        public void DeleteWorkOrder(WorkOrder wo)
        {
            if(wo == null)
            {
                throw new ArgumentNullException(nameof(wo));
            }

            _context.WorkOrders.Remove(wo);
        }

        public IEnumerable<WorkOrder> GetAllWorkOrders()
        {
            return _context.WorkOrders.ToList();
        }

        public WorkOrder GetWorkOrderByID(int id)
        {
            return _context.WorkOrders.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateWorkOrder(WorkOrder wo)
        {
            throw new NotImplementedException();
        }
    }
}
