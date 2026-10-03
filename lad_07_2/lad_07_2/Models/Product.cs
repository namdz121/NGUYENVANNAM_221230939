using System.ComponentModel.DataAnnotations;

namespace lad_07_2.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [MinLength(6, ErrorMessage = "Tên sản phẩm ít nhất 6 ký tự")]
        [MaxLength(150, ErrorMessage = "Tên sản phẩm tối đa 150 ký tự")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Ảnh sản phẩm phải được chọn")]
        public required string Image { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        [Range(100000, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn hoặc bằng 100000")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Giá khuyến mãi không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi không được âm")]
        public float SalePrice { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        [MaxLength(1500, ErrorMessage = "Mô tả không vượt quá 1500 ký tự")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Danh mục không được để trống")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
