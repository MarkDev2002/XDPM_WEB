using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLyBanHang.Entity;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace QuanLyBanHang.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetail>()
                .HasKey(ct => new { ct.orderID, ct.proID });

            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "133f85fc-3e0c-4bd0-a820-d379c0bf9dc5",
                    Name = "Admin",
                    NormalizedName = "ADMIN".ToUpper()
                },
                new IdentityRole
                {
                    Id = "13ae282b-4fbc-49e6-8deb-4a5e4e8bb130",
                    Name = "Manager",
                    NormalizedName = "MANAGER".ToUpper()
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "f139186b-6419-4cb1-8c80-32755a3f7c01",
                    UserName = "VanTin",
                    Email = "nvt@gmail.com",
                    NormalizedUserName = "VANTIN".ToUpper(),
                    NormalizedEmail = "NVT@GMAIL.COM".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Admin@123")
                }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData
            (
                new IdentityUserRole<string>
                {
                    UserId = "f139186b-6419-4cb1-8c80-32755a3f7c01",
                    RoleId = "133f85fc-3e0c-4bd0-a820-d379c0bf9dc5"
                },
                new IdentityUserRole<string>
                {
                    UserId = "f139186b-6419-4cb1-8c80-32755a3f7c01",
                    RoleId = "13ae282b-4fbc-49e6-8deb-4a5e4e8bb130"
                }
            );
        }

    }
}
