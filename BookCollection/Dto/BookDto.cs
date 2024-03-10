using BookCollection.Dto;
using BookCollection.Dto.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookCollection.Models
{
    public class BookDto
    {
        public int Id { get; private set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public BookType Type { get; set; }

        public double? averageRating { get; private set; }

        public int? totalRating { get; private set; }

        public List<RatingsDto> Ratings { get; set; } = new List<RatingsDto>();
    }
}
