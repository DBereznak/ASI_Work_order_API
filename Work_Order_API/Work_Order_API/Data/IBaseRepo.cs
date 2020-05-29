using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Work_Order_API.Data
{
    public interface IBaseRepo<T> where T : class
    {
        Task<bool> SaveChanges();
        Task<bool> CreateWorkOrder(T entity);
        Task<bool> DeleteWorkOrder(T entity);
        Task<bool> UpdateWorkOrder(T entity);
        Task<IList<T>> GetAllWorkOrders();
        Task<T> GetWorkOrderByID(int id);

    }
}
