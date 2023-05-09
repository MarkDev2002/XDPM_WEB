using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using QuanLyBanHang.DataAccess;
using QuanLyBanHang.Entity;

namespace QuanLyBanHang.Service.implementation
{
    public class ProductServices : IProductService
    {
        private ApplicationDbContext _context;
        public ProductServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(Product newProduct)
        {
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var product = GetById(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            foreach(Product product in _context.Products)
            {
                yield return product;
            }
        }

        public Product GetById(int id)
        {
            return _context.Products.Where(x => x.proID == id).FirstOrDefault();
        }

        public async Task UpdateAsSync(Product newProduct)
        {
            _context.Products.Update(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var product = GetById(id);
            if(product != null)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }        
        }
    }
}
