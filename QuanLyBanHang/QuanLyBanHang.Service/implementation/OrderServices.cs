using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.DataAccess;
using QuanLyBanHang.Entity;

namespace QuanLyBanHang.Service.implementation
{
    public class OrderServices : IOrderService
    {
        ApplicationDbContext _context;
        public OrderServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var order = GetById(id);
            if(order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Order> GetAll()
        {
            foreach(Order order in _context.Orders)
            {
                yield return order;
            }
        }

        public Order GetById(int id)
        {
            return _context.Orders.Where(x => x.orderID == id).FirstOrDefault();
        }

        public async Task UpdateAsSync(Order newOrder)
        {
            _context.Orders.Update(newOrder);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var order = GetById(id);
            if(order != null)
            {
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
            }
        }

    }
}
