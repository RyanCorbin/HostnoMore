//namespace HostnoMore
//{
//internal interface IRepository
//{
//}
//}
using System.Collections.Generic;
using System.Threading.Tasks;
using HostnoMore.Models;

namespace HostnoMore.Services
{
    public interface IRepository
    {
        Task<IList<OrderItem>> GetItem();

        Task<IList<OrderItem>> GetItem(int numberOfItems);

        Task AddItem(OrderItem newOrderItem);

        Task RemoveItem(OrderItem removeOrderItem);
    }
}