using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Order_API.Models;

namespace Work_Order_API.Data
{
    public interface IWorkOrderRepo
    {
        bool SaveChanges();
        void CreateWorkOrder(WorkOrder wo);
        void DeleteWorkOrder(WorkOrder wo);
        void UpdateWorkOrder(WorkOrder wo);
        IEnumerable<WorkOrder> GetAllWorkOrders();
        WorkOrder GetWorkOrderByID(int id);

    }
}
