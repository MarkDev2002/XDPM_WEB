using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyBanHang.DataAccess;
using QuanLyBanHang.Entity;

namespace QuanLyBanHang.Service.implementation
{
    public class OrderDetailServices : IOrderDetailService
    {
        ApplicationDbContext _context;
        public OrderDetailServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(OrderDetail newOrderDetail)
        {
            _context.OrderDetails.Add(newOrderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
        }


        public IEnumerable<OrderDetail> GetAll()
        {
            foreach (OrderDetail orderDetail in _context.OrderDetails)
            {
                yield return orderDetail;
            }
        }

        public IEnumerable<OrderDetail> GetById(int id)
        {
            return GetAll().Where(x => x.orderID == id).ToList();
        }
        public OrderDetail GetByProId(int id)
        {
            return _context.OrderDetails.Where(x => x.proID == id).FirstOrDefault();
        }

        public decimal GetTotalOrder(int orderID)
        {
            long total = 0;
            var order = GetById(orderID);
            foreach (OrderDetail orderD in order)
            {
                total += orderD.ordtsTotal;
            }
            return total;
        }

        public decimal GetTotalOrderDetail(int proID)
        {
            var orderDetail = GetByProId(proID);
            return orderDetail.ordtsTotal = orderDetail.ordtsQuantity * orderDetail.ordtsItemPrice;
        }

        public decimal GetTotalQuantity(int orderID)
        {
            var totalQuantity = 0;
            var order = GetById(orderID);
            foreach(OrderDetail orderD in order)
            {
                totalQuantity += orderD.ordtsQuantity;
            }
            return totalQuantity;
        }

        public async Task UpdateAsSync(OrderDetail newOrderDetail)
        {
            _context.OrderDetails.Update(newOrderDetail);
            await _context.SaveChangesAsync();
        }

    }
}
