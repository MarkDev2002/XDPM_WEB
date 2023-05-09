using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.DataAccess;
using QuanLyBanHang.Entity;

namespace QuanLyBanHang.Service.implementation
{
    public class CustomerServices : ICustomerService
    {
        ApplicationDbContext _context;
        public CustomerServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(Customer newCustomer)
        {
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string username)
        {
            var customer = GetById(username);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            foreach(Customer customer in _context.Customers)
            {
                yield return customer;
            }
        }

        public Customer GetById(string username)
        {
            return _context.Customers.Where(x => x.nameofUser == username).FirstOrDefault();
        }

        public async Task UpdateAsSync(Customer newCustomer)
        {
            _context.Customers.Update(newCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(string username)
        {
            var customer=GetById(username);
            if(customer != null)
            {
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
