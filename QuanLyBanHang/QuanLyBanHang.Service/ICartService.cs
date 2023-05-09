using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyBanHang.Entity;
using QuanLyBanHang.Service.implementation;

namespace QuanLyBanHang.Service
{
    public interface ICartService
    {
        Task AddItemToCart(Cart newCart);
        Task DeleteAsync(Cart cart);
        Task DeleteById(string username);
        Task DeleteByProId(int ID);
        Cart GetByUserName(string username);
        IEnumerable<Cart> GetAll();
        Cart GetByProID(int ID);
        Task UpdateAsSync(Cart newCart);
        Task DeleteAll();
    }
}
