using System.ComponentModel.DataAnnotations;

namespace BookCollection.Dto
{
    public class RatingsDto
    {
        public int Id { get; private set; }

        [Range(1, 5)]
        public int ratingValue { get; set; }
        [Required]
        public int BookId { get;  private set; }
    }
}
