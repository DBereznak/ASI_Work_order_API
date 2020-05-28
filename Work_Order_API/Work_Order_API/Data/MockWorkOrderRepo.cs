using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Order_API.Models;

namespace Work_Order_API.Data
{
    public class MockWorkOrderRepo : IWorkOrderRepo
    {

        public void CreateWorkOrder(WorkOrder wo)
        {
            throw new NotImplementedException();
        }

        public void DeleteWorkOrder(WorkOrder wo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkOrder> GetAllWorkOrders()
        {

            var WorkOrders = new List<WorkOrder>
            {
                new WorkOrder{Id=0, WorkOrderNumber="6688", DateOpen=new DateTime(2020, 2, 1), DateClosed=new DateTime(2020, 4, 1), Customer="Raytheon", RegistrationNumber="N1234" },
                new WorkOrder{Id=1, WorkOrderNumber="6689", DateOpen=new DateTime(2020, 3, 1), DateClosed=new DateTime(2020, 5, 1), Customer="U.S Marines", RegistrationNumber="N5678" },
                new WorkOrder{Id=2, WorkOrderNumber="6690", DateOpen=new DateTime(2020, 4, 1),  Customer="Ben Coleman", RegistrationNumber="N9001" },
                new WorkOrder{Id=3, WorkOrderNumber="6691", DateOpen=new DateTime(2020, 5, 1), Customer="Isaac Lang", RegistrationNumber="N5432" },
            };

            return WorkOrders;
        }

        public WorkOrder GetWorkOrderByID(int id)
        {
            return new WorkOrder { Id = 3, WorkOrderNumber = "6691", DateOpen = new DateTime(2020, 5, 1), Customer = "Isaac Lang", RegistrationNumber = "N5432" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateWorkOrder(WorkOrder wo)
        {
            throw new NotImplementedException();
        }
    }
}
