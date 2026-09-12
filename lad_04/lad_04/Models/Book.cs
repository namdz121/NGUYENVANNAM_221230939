using Microsoft.AspNetCore.Mvc.Rendering;

namespace lad_04.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; } = string.Empty;
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Summary { get; set; } = string.Empty;

        public List<Book> GetBookList()
        {
            return new List<Book>
            {
                new Book { Id = 1, Title = "Chi Pheo", AuthorId = 1, GenreId = 1, Image = "/image/products/b1.png", Price = 5000, TotalPage = 250 },
                new Book { Id = 2, Title = "Thi No", AuthorId = 2, GenreId = 2, Image = "/image/products/b2.png", Price = 5000, TotalPage = 250 },
                new Book { Id = 3, Title = "Chao Hanh", AuthorId = 3, GenreId = 3, Image = "/image/products/b3.png", Price = 5000, TotalPage = 250 },
                new Book { Id = 4, Title = "Tot", AuthorId = 4, GenreId = 4, Image = "/image/products/b4.png", Price = 5000, TotalPage = 250 }
            };
        }

        public Book? GetBookById(int id)
        {
            return this.GetBookList().FirstOrDefault(b => b.Id == id);
        }

        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Nam Cao" },
            new SelectListItem { Value = "2", Text = "Nguyen Du" },
            new SelectListItem { Value = "3", Text = "To Hoai" },
            new SelectListItem { Value = "4", Text = "Vu Trong Phung" },
        };

        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Truyen ngan" },
            new SelectListItem { Value = "2", Text = "Tieu thuyet" },
            new SelectListItem { Value = "3", Text = "Ky su" },
            new SelectListItem { Value = "4", Text = "Tho" },
        };
    }
}
