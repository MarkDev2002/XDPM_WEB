using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Serialization;

namespace QuanLyBanHang.Models.User
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "User name is required")]
        [RegularExpression(@"^[a-zA-Z0-9_-]{3,16}$", ErrorMessage = "Username must be 3 to 16 characters and contain only letters, numbers, underscores, and dashes.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string passWord { get; set; }
    }
}
