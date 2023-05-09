using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.Entity;

namespace QuanLyBanHang.Service
{
    public interface IOrderService
    {
        Task CreateAsSync(Order newOrder);
        Task UpdateById(int id);
        Task UpdateAsSync(Order newOrder);
        Task DeleteById(int id);
        Order GetById(int id);
        IEnumerable<Order> GetAll();
        Task DeleteAsync(Order order);
    }
}
