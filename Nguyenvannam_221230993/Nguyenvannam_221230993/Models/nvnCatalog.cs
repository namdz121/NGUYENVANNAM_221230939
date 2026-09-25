using System.ComponentModel.DataAnnotations;

namespace Nguyenvannam_221230993.Models
{
    public class nvnCatalog
    {
        public int hvtId { get; set; }

        [Required]
        public string hvtCateName { get; set; }

        [Range(100, 5000)]
        public int hvtCatePrice { get; set; }

        public int hvtCateQty { get; set; }

        [RegularExpression(@".*\.(jpg|png|jpeg)$", ErrorMessage = "Ảnh phải có định dạng .jpg, .png, .jpeg")]
        public string hvtPicture { get; set; }

        public bool hvtCateActive { get; set; }
    }
}
