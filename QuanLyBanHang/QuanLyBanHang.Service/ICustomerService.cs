using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.Entity;

namespace QuanLyBanHang.Service
{
    public interface ICustomerService
    {
        Task CreateAsSync(Customer newCustomer);
        Task UpdateById(string username);
        Task UpdateAsSync(Customer newCustomer);
        Task DeleteById(string username);
        Customer GetById(string username);
        IEnumerable<Customer> GetAll();
        Task DeleteAsync(Customer customer);
    }
}
