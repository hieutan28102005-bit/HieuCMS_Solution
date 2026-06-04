using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS.Data.Entities
{
    public class CategoryProduct
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        public string Name { get; set; } = string.Empty;

        // Liên kết 1 - Nhiều tới bảng Product của bạn
        public virtual ICollection<Product>? Products { get; set; }
    }
}