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
    public class CartServices : ICartService
    {
        private IProductService _productService;
        private readonly ApplicationDbContext _context;

        public CartServices(ApplicationDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public async Task AddItemToCart(Cart newCart)
        {
            var product = _productService.GetById(newCart.proId);
            var existingCartItem = _context.Carts.Where(ci => ci.nameofUser == newCart.nameofUser && ci.proId == newCart.proId).FirstOrDefault();

            if (existingCartItem != null)
            {
                existingCartItem.Quantity+=newCart.Quantity;
                _context.Carts.Update(existingCartItem);
            }
            else
            {
                _context.Carts.Add(newCart);
            }

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAll()
        {
            foreach (Cart cart in _context.Carts)
            {
                _context.Carts.Remove(cart);
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Cart cart)
        {
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string username)
        {
            var cart = GetByUserName(username);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteByProId(int ID)
        {
            var cart = GetByProID(ID);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }
        public Cart GetByUserName(string username)
        {
            return _context.Carts.Where(x => x.nameofUser == username).FirstOrDefault();
        }
        public Cart GetByProID(int ID)
        {
            return _context.Carts.Where(x => x.proId == ID).FirstOrDefault();
        }
        public IEnumerable<Cart> GetAll()
        {
            foreach (Cart cart in _context.Carts)
            {
                yield return cart;
            }
        }


        public async Task UpdateAsSync(Cart newCart)
        {
            _context.Carts.Update(newCart);
            await _context.SaveChangesAsync();
        }
    }
}
