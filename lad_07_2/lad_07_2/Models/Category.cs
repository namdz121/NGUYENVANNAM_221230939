using System.ComponentModel.DataAnnotations;

namespace lad_07_2.Models
{
    public class Category
    {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "Tên danh mục không được để trống")]
            [MinLength(6, ErrorMessage = "Tên danh mục ít nhất 6 ký tự")]
            [MaxLength(150, ErrorMessage = "Tên danh mục tối đa 150 ký tự")]
            public required string Name { get; set; }
    }
}
