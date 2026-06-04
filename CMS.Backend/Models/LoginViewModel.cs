using System.ComponentModel.DataAnnotations;

namespace CMS.Backend.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tài khoản")]
        public string Email { get; set; } = string.Empty; // đang dùng cho cả Username (admin/editor01)

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}

