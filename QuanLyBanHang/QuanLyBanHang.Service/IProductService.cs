using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.Entity;

namespace QuanLyBanHang.Service
{
    public interface IProductService
    {
        Task CreateAsSync(Product newProduct);
        Task UpdateById(int id);
        Task UpdateAsSync(Product newProduct);
        Task DeleteById(int id);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        Task DeleteAsync(Product product);
    }
}
