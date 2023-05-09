using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.Entity;

namespace QuanLyBanHang.Service
{
    public interface IOrderDetailService 
    {
        Task CreateAsSync(OrderDetail newOrderDetail);
        Task UpdateAsSync(OrderDetail newOrderDetail);
        IEnumerable<OrderDetail> GetById(int id);
        OrderDetail GetByProId(int id);
        IEnumerable<OrderDetail> GetAll();
        Task DeleteAsync(OrderDetail orderDetail);
        decimal GetTotalQuantity (int orderID);
        decimal GetTotalOrderDetail (int proID);
        decimal GetTotalOrder(int orderID);
    }
}
