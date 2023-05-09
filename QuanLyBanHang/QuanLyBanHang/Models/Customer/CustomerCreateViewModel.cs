using QuanLyBanHang.Entity;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models.Customer
{
    public class CustomerCreateViewModel
    {
        [Required(ErrorMessage = "User name is required")]
        [RegularExpression(@"^[a-zA-Z0-9_-]{3,16}$", ErrorMessage = "Username must be 3 to 16 characters and contain only letters, numbers, underscores, and dashes.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        public string cusPhone { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).+$", ErrorMessage = "Password must meet the following requirements: at least one lowercase letter, at least one uppercase letter, at least one digit, and at least one non-alphanumeric character.")]
        public string passWord { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("passWord", ErrorMessage = "Password and Confirmation Password must match.")]
        public string conFirmPassword { get; set; }

        [Required(ErrorMessage = "Name is required"), StringLength(50, MinimumLength = 2, ErrorMessage = "2 to 50 characters required")]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$", ErrorMessage = "Unvalid name")]
        public string cusFullName { get; set; }

        [Required(ErrorMessage = "Your Email is required.")]
        public string cusEmail { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Your address is required.")]
        public string cusAddress { get; set; }
    }
}
